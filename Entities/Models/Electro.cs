using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;
namespace BicycleApplication.Entities.Models
{
	public class Electro : AbstractBicycle
	{
        [Required(ErrorMessage = "Необхідно вказати батарею")]
        public string Battery { get; set; }
        [Range(25, 45, ErrorMessage = "Ширина шини від 25 до 45")]
        public decimal Power { get; set; }

        public Electro() { } 
        
        public Electro(AbstractBicycle bicycle) : base(bicycle) { }
	}
}

