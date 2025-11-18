using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System;
using System.ComponentModel.DataAnnotations;

namespace CondoLounge.Data.Entities
{

       
    public class Condo
    {
        public int Id { get; set; }

        public string CondoNumber { get; set; } 
        public string Address { get; set; }

        // FK to Building
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public int? UserId { get; set; }
        public ApplicationUser User { get; set; }



    }
}
