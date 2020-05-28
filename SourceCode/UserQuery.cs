using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode
{
    class UserQuery
    {
        public static List<User> getLista()
        {
            string sql = "SELECT * FROM APPUSER";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<User> list= new List<User>();
            foreach (DataRow fila in dt.Rows)
            {
                User usu = new User();
                usu.Iduser = Convert.ToInt32(fila[0].ToString());
                usu.Fullname = fila[1].ToString();
                usu.Username = fila[2].ToString();
                usu.Password = fila[3].ToString();
                usu.Usertype = Convert.ToBoolean(fila[4].ToString());
                

                list.Add(usu);
            }

            return list;
        }
    }
}
