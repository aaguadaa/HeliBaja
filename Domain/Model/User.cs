using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // Propiedad de navegación
        public Client Cliente { get; set; }
        public Pilot Piloto { get; set; }


    }
}
