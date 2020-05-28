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
    public partial class PassChange : Form
    {
        Form1 principal = new Form1();
        string password;
        public PassChange(Form1 form1, string pass)
        {
            InitializeComponent();
            principal = form1;
            password = pass;
        }

        private void PassChange_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void PassChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            principal.PopulateControls();
            principal.Show();
        }

        public void PopulateControls()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "iduser";
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = UserQuery.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se puede dejar campos vacíos");
            }else if(textBox1.Text != password)
            {
                MessageBox.Show("Contraseña inválida");
            }
            else
            {
                ConnectionDB.ExecuteNonQuery($"UPDATE APPUSER SET password = '{textBox2.Text}' WHERE idUser = '{comboBox1.SelectedValue}' ");
                MessageBox.Show("Contraseña actualizada");
            }
        }
    }
}
