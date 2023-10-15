using SmartInvest.Dtos.AccionDto;
using System.ComponentModel.DataAnnotations;

namespace SmartInvest.Models
{
    public class AccionModel
    {
        [Key] public int idAcciones { get; set; }
        public string nombre { get; set; }
        public string simbolo { get; set; }

        public AccionDto ToDo()
        {
            return new AccionDto()
            {
                nombre = nombre,
                simbolo = simbolo
            };
        }
    }
}

