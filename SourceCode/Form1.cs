using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        public void PopulateControls()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = UserQuery.getLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User usu = (User)comboBox1.SelectedItem;
            try
            {
                if (comboBox1.SelectedValue.Equals(textBox1.Text))
                {
                    if (usu.Usertype.Equals(false))
                    {
                        UserView u = new UserView(usu, this);
                        u.Show();
                        this.Hide();
                        textBox1.Text = "";
                    }
                    else if (usu.Usertype.Equals(true))
                    {
                        AdminView admi = new AdminView(this);
                        admi.Show();
                        this.Hide();
                        textBox1.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
          
             PassChange u = new PassChange(this, comboBox1.SelectedValue.ToString());
             u.Show();
             this.Hide();
             textBox1.Text = "";

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception);
            }
        }
    }
}
