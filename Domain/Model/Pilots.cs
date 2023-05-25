using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Pilots
    {
        [Key]
        public int Id_Pilot { get; set; }

        public string Name { get; set; }

        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // Relaciones con otras entidades
        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}