using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class AdminView : Form
    {
        private UserControl current = null;
        private Form1 principal = new Form1();
        public AdminView(Form1 form1)
        {
            InitializeComponent();
            current = userAdd1;
            principal = form1;
            ActGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Controls.Remove(current);
            current = new UserAdd();
            tableLayoutPanel4.Controls.Add(current, 0, 1);
            tableLayoutPanel4.SetColumnSpan(current, 2);
            ActGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Controls.Remove(current);
            current = new UserDelete();
            tableLayoutPanel4.Controls.Add(current, 0, 1);
            tableLayoutPanel4.SetColumnSpan(current, 2);
            ActGrid();
        }

        public void ActGrid()
        {
            tableLayoutPanel5.Controls.Remove(dataGridView1);
            var dt = ConnectionDB.ExecuteQuery("SELECT * FROM APPUSER;");
            dataGridView1.DataSource = dt;
            tableLayoutPanel5.Controls.Add(dataGridView1);
        }

        public void ActGrid2()
        {
            tableLayoutPanel6.Controls.Remove(dataGridView2);
            var dt = ConnectionDB.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " +
                $"FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " +
                $"WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser; ");
            dataGridView2.DataSource = dt;
            tableLayoutPanel6.Controls.Add(dataGridView2);
        }

        private void AdminView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            principal.PopulateControls();
            principal.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutNegocios.Controls.Remove(current);
            current = new AddBusiness();
            tableLayoutNegocios.Controls.Add(current, 0, 0);
            tableLayoutNegocios.SetColumnSpan(current, 2);
            tableLayoutNegocios.SetRowSpan(current, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutNegocios.Controls.Remove(current);
            current = new DeleteBusiness();
            tableLayoutNegocios.Controls.Add(current, 0, 0);
            tableLayoutNegocios.SetColumnSpan(current, 2);
            tableLayoutNegocios.SetRowSpan(current, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutNegocios.Controls.Remove(current);
            current = new MenuBusiness();
            tableLayoutNegocios.Controls.Add(current, 0, 0);
            tableLayoutNegocios.SetColumnSpan(current, 2);
            tableLayoutNegocios.SetRowSpan(current, 2);
        }

        private void AdminView_Load(object sender, EventArgs e)
        {
            ActGrid2();
        }
    }
}
