using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode
{
    class ProductQuery2
    {
        public static List<Product> getList(int id)
        {
            string sql = $"SELECT p.idProduct, p.name FROM PRODUCT p WHERE idbusiness = '{id}'";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Product> list = new List<Product>();
            foreach (DataRow fila in dt.Rows)
            {
                Product pr = new Product();
                pr.Idproduct = Convert.ToInt32(fila[0].ToString());
                pr.Name = fila[1].ToString();

                list.Add(pr);
            }

            return list;
        }
    }
}
