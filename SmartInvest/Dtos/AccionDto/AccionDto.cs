using System.ComponentModel.DataAnnotations.Schema;

namespace SmartInvest.Dtos.AccionDto
{
    [Table ("Acciones")]
    public class AccionDto
    {
        public int idAccion {  get; set; }
        public string nombre { get; set; }
        public string simbolo { get; set; }
    }
}
