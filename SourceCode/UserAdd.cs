using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class UserAdd : UserControl
    {
        public UserAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool type = false;

            try
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar campos vacíos");
                }
                else
                {

                    if (radioButton1.Checked)
                    {
                        type = false;
                    }
                    else if (radioButton2.Checked)
                    {
                        type = true;
                    }

                    string query = $"INSERT INTO APPUSER (fullname, username, password, usertype) " +
                                   $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox2.Text}', {type}); ";

                    ConnectionDB.ExecuteNonQuery(query);

                    MessageBox.Show("Se ha registrado al usuario");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
