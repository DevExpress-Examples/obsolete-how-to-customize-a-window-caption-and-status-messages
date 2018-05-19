using System;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace WinWebSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            int i;
            Department[] department = new Department[3];
            string[] departmentTitles = new string[] {
                "Development Department",
                "QA Department",
                "Sales Department"
            };
            for (i = 0; i <=2; i++)
                {
                department[i] = Session.FindObject<Department>(new BinaryOperator("Title", department[i]));
                    if(department[i] == null) {
                    department[i] = new Department(Session);
                    department[i].Title = departmentTitles[i];
                    department[i].Office = (101 + i).ToString();
                    department[i].Save();
                }
            }
            SimpleUser user = Session.FindObject<SimpleUser>(new BinaryOperator("UserName", "Sam"));
            if(user == null) {
                user = new SimpleUser(Session);
                user.UserName = "Sam";
                user.FullName = "";
            }
            user.IsAdministrator = true;
            user.SetPassword("");
            user.Save();
        }
    }
}
