using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? PilotId { get; set; }

        public int? ClientId { get; set; }

        // Propiedades de navegación
        public virtual Client Cliente { get; set; }

        public virtual Pilot Piloto { get; set; }
    }
}
