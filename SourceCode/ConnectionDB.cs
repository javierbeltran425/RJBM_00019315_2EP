using Npgsql;
using System;
using System.Data;


namespace SourceCode
{
    public static class ConnectionDB
    {
        private static string host = "127.0.0.1",
                              database = "SegundoParcial",
                              userId = "postgres",
                              password = "uca";

        private static string sConnection =
            $"Host={host};Port=5432;User Id={userId};Password={password};Database={database};";

        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(sConnection);
                DataSet ds = new DataSet();

                connection.Open();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);

                da.Fill(ds);

                connection.Close();

                return ds.Tables[0];
            }catch(Exception ex)
            {
                throw new NonRegisters("El usuario no tiene registros");
            }
            
        }

        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);

            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
