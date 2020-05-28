using System;
using System.Collections.Generic;
using System.Data;


namespace SourceCode
{
    class BusinessQuery
    {
        public static List<Business> getList()
        {
            string sql = "SELECT * FROM BUSINESS";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Business> list = new List<Business>();
            foreach (DataRow fila in dt.Rows)
            {
                Business bu = new Business();
                bu.Idbusiness = Convert.ToInt32(fila[0].ToString());
                bu.Name = fila[1].ToString();
                bu.Description = fila[2].ToString();
                list.Add(bu);
            }

            return list;
        }
    }
}
