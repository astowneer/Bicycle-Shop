using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;
namespace BicycleApplication.Entities.Models
{
	public class Highway : AbstractBicycle
	{
        [Range(16, 22, ErrorMessage = "Кількість швидкостей від 16 до 22")]
        public int NumberOfGears { get; set; }
        [Required(ErrorMessage = "Необхідно вказати чи складний велосипед")]
        public bool IsDropBar { get; set; }

        public Highway() { } 

		public Highway(AbstractBicycle bicycle) : base(bicycle) { }
	}
}

