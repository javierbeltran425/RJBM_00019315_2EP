using System;
using System.Collections.Generic;
using System.Data;


namespace SourceCode
{
    class OrderQuery
    {
        public static List<Order> getList(int usu, int dir)
        {
            string sql = $"SELECT	ord.idorder AS NúmeroOrden, prod.name AS Producto " +
                $"FROM APPORDER ord, APPUSER usu, PRODUCT prod, ADDRESS adr " +
                $"WHERE usu.iduser = '{usu}' AND ord.idproduct = prod.idproduct AND ord.idaddress = '{dir}' " +
                $"AND adr.idaddress = '{dir}' AND adr.iduser = '{usu}'";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Order> list = new List<Order>();
            foreach (DataRow fila in dt.Rows)
            {
                Order ord = new Order();
                ord.Idorder = Convert.ToInt32(fila[0].ToString());

                list.Add(ord);
            }

            return list;
        }
    }
}
