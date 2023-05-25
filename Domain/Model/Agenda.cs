using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Agenda
    {
        [Key]
        public int Id_Agenda { get; set; }

        public DateTime Date { get; set; }

        public int Id_Pilot { get; set; }

        public int Id_Flight { get; set; }
        public string Itinerary { get; set; }

        // Relación con el piloto
        public virtual Pilots Pilot { get; set; }

        // Relación con el vuelo
        public virtual Flight Flight { get; set; }
    }
}