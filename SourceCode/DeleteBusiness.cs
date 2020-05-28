using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class DeleteBusiness : UserControl
    {
        public DeleteBusiness()
        {
            InitializeComponent();
        }

        private void DeleteBusiness_Load(object sender, EventArgs e)
        {
            PopulateControls();
            ActGrid();
        }
        private void PopulateControls()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "idbusiness";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = BusinessQuery.getList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM BUSINESS WHERE idBusiness = {comboBox1.SelectedValue}");

                MessageBox.Show("Negocio eliminado correctamente");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }

            ActGrid();
        }

        public void ActGrid()
        {
            var dt = ConnectionDB.ExecuteQuery("SELECT * FROM BUSINESS");
            dataGridView1.DataSource = dt;
        }
    }
}
