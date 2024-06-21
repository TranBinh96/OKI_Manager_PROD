using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using OKI.TOOL.IR.CHECK.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKI.TOOL.IR.CHECK
{
    public partial class XtraLogin : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraLogin()
        {
            InitializeComponent();
         /*   panel1.Visible = false*/;
        }


        private void btnLogin_CheckedChanged(object sender, EventArgs e)
        {
            User user = new User(txtUserName.Text, txtPassword.Text);
            if (user != null)
            {
                navigationFrame1.SelectedPage = navigationPageAdmin;
            }
        }
    }
}
