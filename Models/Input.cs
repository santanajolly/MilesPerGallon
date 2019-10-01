using System;
using System.ComponentModel.DataAnnotations;

namespace MilesPerGallon.Models
{
    public class Input
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarModel { get; set; }
        public float MilesDriven { get; set; }

        [DataType(DataType.Date)]
        public DateTime FillUpDate { get; set; }
        public int GallonsFilled { get; set; }




    }
}
