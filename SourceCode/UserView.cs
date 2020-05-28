using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class UserView : Form
    {
        User LogUsu = new User();
        int pr = 0;
        Form1 principal = new Form1();
        public UserView(User usu, Form1 form1)
        {
            InitializeComponent();
            LogUsu = usu;
            principal = form1;
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            PopulateControls();
            PopulateControls2();
            PopulateControls3();
        }

        private void UserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            principal.PopulateControls();
            principal.Show();
        }

        private void PopulateControls()
        {
            listBox1.DataSource = null;
            listBox1.ValueMember = "idbusiness";
            listBox1.DisplayMember = "name";
            listBox1.DataSource = BusinessQuery.getList();
        }

        private void PopulateControls2()
        {
            
            listBox2.DataSource = null;
            listBox2.ValueMember = "idproduct";
            listBox2.DisplayMember = "name";
            listBox2.DataSource = ProductQuery2.getList(pr);
        }

        private void PopulateControls3()
        {

            comboBox1.DataSource = null;
            comboBox1.ValueMember = "idaddress";
            comboBox1.DisplayMember = "address";
            comboBox1.DataSource = UserAddressQuery.getList(LogUsu.Iduser);
        }

        private void PopulateControls4(int dir)
        {

            listBox3.DataSource = null;
            listBox3.ValueMember = "idorder";
            listBox3.DisplayMember = "idorder";
            listBox3.DataSource = OrderQuery.getList(LogUsu.Iduser, dir);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pr = Convert.ToInt32(listBox1.SelectedValue);
            PopulateControls2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    DateTime f = DateTime.Now;
                    ConnectionDB.ExecuteNonQuery($"INSERT INTO APPORDER(createDate, idProduct, idAddress) VALUES('{f}', '{listBox2.SelectedValue}', '{comboBox1.SelectedValue}'); ");
                ActGrid();
                MessageBox.Show("Orden agregada");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se ha podido procesar su orden");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"INSERT INTO ADDRESS(iduser, address) VALUES ('{LogUsu.Iduser}', '{textBox1.Text}')");
                PopulateControls3();
                MessageBox.Show("Dirección agregada");
            }
            catch
            {
                MessageBox.Show("No se ha podido guardar la dirección");
            }
        }

        public void ActGrid()
        {

                var dt2 = ConnectionDB.ExecuteQuery($"SELECT	ord.idorder AS NumeroOrden, prod.name AS Producto, usu.username AS Cliente, adr.address " +
                    $"FROM APPORDER ord, APPUSER usu, PRODUCT prod, ADDRESS adr " +
                    $"WHERE usu.iduser = '{LogUsu.Iduser}' AND ord.idproduct = prod.idproduct AND ord.idaddress = '{comboBox1.SelectedValue}' " +
                    $"AND adr.idaddress = '{comboBox1.SelectedValue}' AND adr.iduser = '{LogUsu.Iduser}'");
                dataGridView1.DataSource = dt2;
                PopulateControls4(Convert.ToInt32(comboBox1.SelectedValue.ToString()));
      


        }


        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionDB.ExecuteNonQuery($"DELETE FROM APPORDER WHERE idOrder = '{listBox3.SelectedValue}'");
            ActGrid();
            MessageBox.Show("Orden eliminada");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConnectionDB.ExecuteNonQuery($"DELETE FROM ADDRESS WHERE idAddress = '{comboBox1.SelectedValue}'");
            PopulateControls3();
            MessageBox.Show("Dirección eliminada");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ActGrid();
            }
            catch(NonRegisters ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
