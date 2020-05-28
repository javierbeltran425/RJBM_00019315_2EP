using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class AddBusiness : UserControl
    {
        public AddBusiness()
        {
            InitializeComponent();
        }
        private void AddBusiness_Load(object sender, EventArgs e)
        {
            ActGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals("") || richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar campos vacíos");
                }
                else
                { 

                    ConnectionDB.ExecuteNonQuery($"INSERT INTO BUSINESS(name, description) VALUES('{textBox1.Text}', '{richTextBox1.Text}'); ");

                    MessageBox.Show("Se ha registrado el negocio");
                }

                ActGrid();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }

        public void ActGrid()
        {
            var dt = ConnectionDB.ExecuteQuery("SELECT * FROM BUSINESS;");
            dataGridView1.DataSource = dt;
            
        }

    }
}
