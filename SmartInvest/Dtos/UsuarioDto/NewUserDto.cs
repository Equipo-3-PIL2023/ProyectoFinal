namespace SmartInvest.Dtos.UsuarioDto
{
    public class NewUserDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Dni { get; set; }
        public string TipoDocumento { get; set; }
        public string Telefono { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
