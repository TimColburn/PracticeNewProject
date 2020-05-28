using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Instrumentation;

namespace PracticeNewProject.Models
{
    public class Person
    {
        public Person()
        {
            ParkingLot = new List<string>()
            {
                "A", "B", "C"
            };
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenderEnum Gender { get; set; }

        public List<string> ParkingLot { get; set; }

        public Department Department { get; set; }
        public Position Position { get; set; }
    }
}