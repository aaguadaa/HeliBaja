using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Inventory
    {
        [Key]
        public int Id_Inventory { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public bool Available { get; set; }

        public bool AdminInventory { get; set; }

        public DateTime Date { get; set; }

        // Propiedad de navegación para las herramientas en el inventario
        public List<Tools> Tools { get; set; }
    }
}