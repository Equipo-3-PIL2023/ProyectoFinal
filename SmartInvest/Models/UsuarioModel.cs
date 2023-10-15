using SmartInvest.Dtos.UsuarioDto;
using System.ComponentModel.DataAnnotations;

namespace SmartInvest.Models
{
    public class UsuarioModel
    {
        [Key] public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int dni { get; set; }
        public string tipoDni { get; set; }
        public string telefono { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public UsuarioDto ToDto()
        {
            return new UsuarioDto()
            {
                Id = idUsuario, 
                Nombre = nombre,
                Apellido = apellido,
                Email = correo,
                Password = password,
                Dni = dni,
                TipoDocumento = tipoDni,
                Telefono = telefono,
                CodigoPostal = codigoPostal,
                Ciudad = ciudad,
                Provincia = provincia,
                Pais = pais,
                FechaNacimiento = fechaNacimiento,
            };
        }
    }
}
