using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace TubitetClasses.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        public string FacultyName { get; set; }
        public Boolean IsDeleted { get; set; }

        public int Save()
        {
            if (this.ID == 0) //insert new record
            {
                this.ID = DAL.insertSql("insert into Faculty (FacultyName) values (@FacultyName)", new MySqlParameter("@FacultyName", this.FacultyName));
            }
            else //update record
            {
                DAL.insertSql("update Faculty set FacultyName=@FacultyName where ID=@ID",
                    new List<MySqlParameter>() {
                        new MySqlParameter("@ID",this.ID),
                        new MySqlParameter("@FacultyName",this.FacultyName)
                    });
            }

            
            return this.ID;
        }
        public void Delete()
        {
            DAL.insertSql("update Faculty set IsDeleted=1 where ID=@ID", new MySqlParameter("@ID", this.ID));
        }

        public void getFaculty()
        {
            DataTable data = DAL.readData("select * from Faculty where ID=@ID", new MySqlParameter("@ID", this.ID));
            this.FacultyName = data.Rows[0]["FacultyName"].ToString();
            this.IsDeleted = Convert.ToBoolean(data.Rows[0]["IsDeleted"].ToString());
        }

        public List<Faculty> getFaculties(string filter)
        {
            List<Faculty> result = new List<Faculty>();

            DataTable data = DAL.readData("select * from Faculty where IsDeleted=0 and FacultyName Like @filter",new MySqlParameter("@filter",'%' + filter + '%'));

            foreach (DataRow dr in data.Rows)
            {
                result.Add(
                    new Faculty()
                    {
                        ID=Convert.ToInt32(dr["ID"].ToString()),
                        FacultyName=dr["FacultyName"].ToString()
                    }
                );
            }


            return result;
        }

    }
}
