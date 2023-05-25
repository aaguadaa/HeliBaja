using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Clients
    {
        [Key]
        public int Id_Client { get; set; }

        public string Name { get; set; }

        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // Relación con las reservas del cliente
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}