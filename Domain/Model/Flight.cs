using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Flight
    {
        [Key]
        public int Id_Flight { get; set; }

        public string NumeroVuelo { get; set; }
        public string Status { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public DateTime HoraSalida { get; set; }

        public DateTime HoraLlegada { get; set; }

        // Relación con las reservas
        public virtual ICollection<Booking> Bookings { get; set; }

        // ID del piloto
        public int PilotId { get; set; }
    }
}