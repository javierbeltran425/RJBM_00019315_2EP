using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class MenuBusiness : UserControl
    {
        public MenuBusiness()
        {
            InitializeComponent();
        }

        private void MenuBusiness_Load(object sender, EventArgs e)
        {
            PopulateControls();
            PopulateControls2();
            ActGrid();
        }

        private void PopulateControls()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "idbusiness";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = BusinessQuery.getList();
        }

        private void PopulateControls2()
        {
            comboBox2.DataSource = null;
            comboBox2.ValueMember = "idproduct";
            comboBox2.DisplayMember = "name";
            comboBox2.DataSource = ProductQuery.getList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"INSERT INTO PRODUCT(idbusiness, name) VALUES('{comboBox1.SelectedValue}', '{textBox1.Text}'); ");

                    MessageBox.Show("Se ha registrado el producto");
                    ActGrid();
                    PopulateControls2();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        public void ActGrid()
        {
            var dt = ConnectionDB.ExecuteQuery($"SELECT p.idProduct, p.name FROM PRODUCT p WHERE idBusiness = '{comboBox1.SelectedValue}'");
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                ConnectionDB.ExecuteNonQuery($"DELETE FROM PRODUCT WHERE idProduct = '{comboBox2.SelectedValue}'");

                MessageBox.Show("Producto eliminado correctamente");
                PopulateControls2();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
