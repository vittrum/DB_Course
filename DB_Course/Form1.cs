using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Course.Repos;

namespace DB_Course
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        AdministratorRequests Areq = new AdministratorRequests();
        Factory fact = new Factory("127.0.0.1", "5432", "postgres", "1", "Viktor_db");

        private void Button1_Click(object sender, EventArgs e)
        {
            Areq.Title_Output(fact, dgv1);
            if (dgv1.CurrentRow != null) dgv1.Rows[dgv1.CurrentRow.Index].Selected = false;
        }
    }
}
