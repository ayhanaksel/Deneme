using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace TubitetClasses.Infrastructure.Migrations
{

    [Migration(1)]
    public class V01 : Migration
    {
        public override void Up()
        {
            Create.Table("Faculty")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("FacultyName").AsString(128)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Department")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("FacutyID").AsInt32().ForeignKey("Faculty","ID")
                .WithColumn("DepartmentName").AsString(128).NotNullable()
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);


            Create.Table("User")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("FacultyID").AsInt32().ForeignKey("Faculty", "ID")
                .WithColumn("DepartmentID").AsInt32().ForeignKey("Department", "ID")
                .WithColumn("Email").AsString(256).NotNullable()
                .WithColumn("Password").AsString(32).NotNullable()
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

        }

        public override void Down()
        {
      
            Delete.Table("User");
            Delete.Table("Department");
            Delete.Table("Faculty");
        }
    }
}
