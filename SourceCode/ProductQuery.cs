using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    class ProductQuery
    {
        public static List<Product> getList()
        {
            string sql = "SELECT * FROM PRODUCT";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Product> list = new List<Product>();
            foreach (DataRow fila in dt.Rows)
            {
                Product pr = new Product();
                pr.Idproduct = Convert.ToInt32(fila[0].ToString());
                pr.Idbusiness = Convert.ToInt32(fila[1].ToString());
                pr.Name = fila[2].ToString();

                list.Add(pr);
            }

            return list;
        }
    }
}
