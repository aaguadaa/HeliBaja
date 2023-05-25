using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // Lista de inventarios que el administrador maneja
        public List<Inventory> Inventories { get; set; }

        // Lista de vuelos que el administrador maneja
        public List<Flight> Flights { get; set; }

        // Lista de reservas que el administrador maneja
        public List<Booking> Bookings { get; set; }
    }
}