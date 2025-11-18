using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System;
using System.ComponentModel.DataAnnotations;

namespace CondoLounge.Data.Entities
{

       
    public class Condo
    {
        public int Id { get; set; }

        [Required]
        public int CondoNumber { get; set; }
        public string Location { get; set; }

        public int BuildingId { get; set; }


        //navigation properties
        public Building building { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    }
}
