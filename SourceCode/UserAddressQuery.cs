using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    class UserAddressQuery
    {
        public static List<UserAddress> getList(int id)
        {
            string sql = $"SELECT * FROM ADDRESS WHERE iduser = '{id}'";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<UserAddress> list = new List<UserAddress>();
            foreach (DataRow fila in dt.Rows)
            {
                UserAddress ad = new UserAddress();
                ad.Idaddress = Convert.ToInt32(fila[0].ToString());
                ad.Iduser = Convert.ToInt32(fila[1].ToString());
                ad.Address = fila[2].ToString();

                list.Add(ad);
            }

            return list;
        }
    }
}
