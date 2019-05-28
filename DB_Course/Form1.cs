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
        Factory fact = new Factory("127.0.0.1", "5432", "postgres", "1", "University personnel department");

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Areq.Title_Output(fact, dgvTitles);
            if (dgvTitles.CurrentRow != null) dgvTitles.Rows[dgvTitles.CurrentRow.Index].Selected = false;
        }

        
    }
}
