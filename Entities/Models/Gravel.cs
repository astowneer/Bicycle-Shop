using System;
using System.ComponentModel.DataAnnotations;
using Entities.Models;
namespace BicycleApplication.Entities.Models
{
	public class Gravel : AbstractBicycle
	{
        [Range(0, 1, ErrorMessage = "Ширина шини від 0 до 1")]
        public decimal TireWidth { get; set; }
        [Range(30, 50, ErrorMessage = "Ширина керма від 30 до 50")]
        public int HandlebarWidth { get; set; }

        public Gravel() { } 

		public Gravel(AbstractBicycle bicycle) : base(bicycle) { }
	}
}

