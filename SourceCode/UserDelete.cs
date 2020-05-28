using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class UserDelete : UserControl
    {
        public UserDelete()
        {
            InitializeComponent();
        }

        private void UserDelete_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void PopulateControls()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "iduser";
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = UserQuery.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM APPUSER WHERE iduser = '{comboBox1.SelectedValue}'");

                MessageBox.Show("Usuario eliminado correctamente");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
