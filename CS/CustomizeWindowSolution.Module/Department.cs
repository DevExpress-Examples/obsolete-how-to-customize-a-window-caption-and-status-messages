using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace WinWebSolution.Module {
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Title")]
    [ImageName("BO_Department")]
    public class Department : BaseObject {
        private string title;
        private string office;
        public Department(Session session) : base(session) { }
        public string Title {
            get { return title; }
            set { SetPropertyValue("Title", ref title, value); }
        }
        public string Office {
            get { return office; }
            set { SetPropertyValue("Office", ref office, value); }
        }
    }


}
