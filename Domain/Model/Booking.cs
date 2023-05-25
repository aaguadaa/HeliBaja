using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Booking
    {
        [Key]
        public int Id_Booking { get; set; }
        public int Id_Client { get; set; }
        public int Id_Flight { get; set; }
        public DateTime CreatedDate { get; set; }  // Fecha de creación de la reserva
        public DateTime TourDate { get; set; }  // Fecha del tour
        public string PaymentMethod { get; set; }  // Método de pago de la reserva
        public string PaymentStatus { get; set; }  // Estado de pago de la reserva
        public string BookingStatus { get; set; }  // Estado de la reserva

        // Relación con el cliente
        public virtual Clients Client { get; set; }

        // Relación con el vuelo
        public virtual Flight Flight { get; set; }
    }
}