using SmartInvest.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SmartInvest.Models
{
    public class UserModel
    {
        [Key] public int? idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int dni { get; set; }
        public string tipoDni { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                Id = idUsuario ?? throw new Exception("El id no puede ser null"),
                Nombre = nombre,
                Apellido = apellido,
                Email = correo,
                Password = password,
                Dni = dni,
                TipoDocumento = tipoDni,
                CodigoPostal = codigoPostal,
                Ciudad = ciudad,
                Provincia = provincia,
                Pais = pais,
                FechaNacimiento = fechaNacimiento,
            };
        }
    }
}
