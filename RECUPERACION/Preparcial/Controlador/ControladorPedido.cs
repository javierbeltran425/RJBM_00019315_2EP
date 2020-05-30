using System;
using System.Data;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorPedido
    {
        // Corrección del tipo de variable que espera el constructor de string a int
        public static DataTable GetPedidosUsuarioTable(int id)
        {
            DataTable pedidos = null;

            try
            {
                // Correccion de nombre en consulta i.nombreArticulo a i.nombreart
                pedidos = ConexionBD.EjecutarConsulta("SELECT p.idPedido, i.nombreart, p.cantidad, i.precio, (i.precio * p.cantidad) AS total" +
                                            " FROM PEDIDO p, INVENTARIO i, USUARIO u" +
                                            " WHERE p.idArticulo = i.idArticulo" +
                                            " AND p.idUsuario = u.idUsuario" +
                                            $" AND u.idUsuario = {id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return pedidos;
        }

        public static DataTable GetPedidosTable()
        {
            DataTable pedidos = null;

            try
            {
                //Corrección en la consulta i.nombreArticulo a nombreart
                pedidos = ConexionBD.EjecutarConsulta("SELECT p.idPedido, i.nombreart, p.cantidad, i.precio, (i.precio * p.cantidad) AS total " +
                                            " FROM PEDIDO p, INVENTARIO i, USUARIO u " +
                                            " WHERE p.idArticulo = i.idArticulo " +
                                            " AND p.idUsuario = u.idUsuario ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return pedidos;
        }

        // Corrección del tipo de variable idUsuario de string a int
        public static void HacerPedido(int idUsuario, string idArticulo, string cantidad)
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO PEDIDO(idUsuario, idArticulo, cantidad) " +
                    $"VALUES({idUsuario}, {idArticulo}, {cantidad})");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
