using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;
namespace BicycleApplication.Entities.Models
{
	public class Mountain : AbstractBicycle
	{
        [Range(0, 12, ErrorMessage = "Кількість швидкостей від 1 до 12")]
        public int NumberOfGears { get; set; }

        public Mountain() { } 

		public Mountain(AbstractBicycle bicycle) : base(bicycle) { }
	}
}

