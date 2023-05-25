using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public int AddFlight(Flight flight)
        {
            // Agregar el vuelo al sistema
            int flightId = _flightRepository.Add(flight);

            // Retornar el identificador único del vuelo agregado
            return flightId;
        }

        public bool UpdateFlight(Flight flight)
        {
            // Actualizar la información del vuelo en el sistema
            bool isUpdated = _flightRepository.Update(flight);

            // Retornar si la actualización fue exitosa o no
            return isUpdated;
        }

        public bool DeleteFlight(int flightId)
        {
            // Eliminar el vuelo del sistema
            bool isDeleted = _flightRepository.Delete(flightId);

            // Retornar si la eliminación fue exitosa o no
            return isDeleted;
        }

        public Flight GetFlightById(int flightId)
        {
            // Obtener el vuelo por su identificador único
            Flight flight = _flightRepository.Get(flightId);

            // Retornar el vuelo correspondiente si existe, o null en caso contrario
            return flight;
        }

        public List<Flight> GetAdminFlights()
        {
            // Obtener todos los vuelos existentes en el sistema para uso administrativo
            List<Flight> flights = _flightRepository.GetAllFlights();

            // Retornar la lista de vuelos
            return flights;
        }

        public List<Flight> GetFlights()
        {
            // Obtener todos los vuelos disponibles en el sistema para los usuarios
            List<Flight> flights = _flightRepository.GetAvailableFlights();

            // Retornar la lista de vuelos
            return flights;
        }

        public Task<IEnumerable<Flight>> GetFlightsByBookingId(int bookingId)
        {
            // Obtener los vuelos asociados a una reserva por su identificador único
            Task<IEnumerable<Flight>> flights = _flightRepository.GetFlightsByBookingId(bookingId);

            // Retornar la colección de vuelos
            return flights;
        }

        public Task<IEnumerable<Flight>> GetFlightsByDate(DateTime date)
        {
            // Obtener los vuelos que tienen una fecha específica
            Task<IEnumerable<Flight>> flights = _flightRepository.GetFlightsByDate(date);

            // Retornar la colección de vuelos
            return flights;
        }

        public Task<IEnumerable<Flight>> GetFlightsByDateRange(DateTime startDate, DateTime endDate)
        {
            // Obtener los vuelos que se encuentran dentro de un rango de fechas
            Task<IEnumerable<Flight>> flights = _flightRepository.GetFlightsByDateRange(startDate, endDate);

            // Retornar la colección de vuelos
            return flights;
        }

        public Task<IEnumerable<Flight>> GetFlightsByPilotId(int pilotId)
        {
            // Obtener los vuelos asociados a un piloto por su identificador único
            Task<IEnumerable<Flight>> flights = _flightRepository.GetFlightsByPilotId(pilotId);

            // Retornar la colección de vuelos
            return flights;
        }

        public Task<IEnumerable<Flight>> GetFlightsByStatus(string status)
        {
            // Obtener los vuelos que tienen un estado específico
            Task<IEnumerable<Flight>> flights = _flightRepository.GetFlightsByStatus(status);

            // Retornar la colección de vuelos
            return flights;
        }
    }
}