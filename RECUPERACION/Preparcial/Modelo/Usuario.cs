namespace Preparcial.Modelo
{
    public class Usuario
    {

        // Correción del tipo de variable de IdUsuario de string a int y se quitaron los setters por que no son necesarios para este caso
        public int IdUsuario { get;}

        public string NombreUsuario { get;}

        public string Contrasena { get;}

        public bool Admin { get;}

        // Correción del tipo de variable de IdUsuario de string a int
        public Usuario(int idUsuario, string nombreUsuario, string contrasenia, bool admin)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasenia;
            Admin = admin;
        }
    }
}
