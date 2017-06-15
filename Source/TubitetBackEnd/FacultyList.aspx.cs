using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using TubitetClasses.Models;


namespace TubitetBackEnd
{
    public partial class FacultyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Faculty> faculties = new Faculty().getFaculties(txtFilter.Text);
            //X.Msg.Alert("UYARI", "The number of faculties is : " + faculties.Count.ToString()).Show();
            Store store = grdList.GetStore();
            store.DataSource = faculties;
            store.DataBind();
        }
        protected void btnList_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            List<Faculty> faculties = new Faculty().getFaculties(txtFilter.Text);
            //X.Msg.Alert("UYARI", "The number of faculties is : " + faculties.Count.ToString()).Show();
            Store store= grdList.GetStore();
            store.DataSource = faculties;
            store.DataBind();
        }

        protected void btnNewFacult_DirectClick(object sender, DirectEventArgs e)
        {
            ResetForm();
            wndNew.Show();
        }

        protected void btnClose_DirectClick(object sender, DirectEventArgs e)
        {
            wndNew.Close();
        }

        protected void btnSave_DirectClick(object sender, DirectEventArgs e)
        {
            if (hdnID.Value == "")
            {
                hdnID.Value = 0;
            }
            Faculty f = new Faculty()
            {
                ID=Convert.ToInt32(hdnID.Value),
                FacultyName = txtFacultyName.Text
            };

            int control = f.Save();

            if (control > 0)
            {
                X.Msg.Alert("Uyarı", "Fakülte kartı kayıt edilmiştir. Yeni bir kayıt daha yapabilirsiniz.").Show();
                ResetForm();
            }
            else
            {
                X.Msg.Alert("Uyarı", "Veri tabanına kayıt etme hatası").Show();
            }
        }

        private void ResetForm()
        {
            hdnID.Reset();
            txtFacultyName.Reset();
            txtFacultyName.Focus();
        }

       

        public void ColumnEvents(object sender,Ext.Net.DirectEventArgs e)
        {
            int ID=Convert.ToInt32(e.ExtraParams["ID"]);
            string CommandName = e.ExtraParams["CommandName"];

            switch (CommandName)
            {
                case "cmdUpdate":
                    Update(ID);
                    break;
                case "cmdDelete":
                    Delete(ID);
                    break;
            }

            

        }

        private void Update (int ID)
        {
            Faculty f = new Faculty() { ID = ID };
            f.getFaculty();

            hdnID.SetValue(f.ID);
            txtFacultyName.Text = f.FacultyName;
            wndNew.Show();
        }

        private void Delete(int ID)
        {
            Faculty f = new Faculty() { ID = ID };
            f.Delete();
            btnList_DirectClick(null, null);
        }
    }
}