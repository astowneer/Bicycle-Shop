using System;
namespace Entities.Models
{
	public class Bicycle : AbstractBicycle
	{
        public decimal TireWidth { get; set; }
        public decimal HandlebarWidth { get; set; }

        public int NumberOfGears { get; set; }
        public bool IsDropBar { get; set; }

        public string Battery { get; set; }
        public decimal Power { get; set; }

        public Bicycle() { }

        public Bicycle(AbstractBicycle bicycle, decimal tireWidth = 0,
                                                decimal handlebarWidth = 0, 
                                                int numberOfGears = 0, 
                                                bool isDropBar = false,
                                                string battery = null,
                                                decimal power = 0) 
            : base(bicycle) 
        {
            TireWidth = tireWidth;
            HandlebarWidth = handlebarWidth;
            NumberOfGears = numberOfGears;
            IsDropBar = isDropBar;
            Battery = battery;
            Power = power;
        }
	}
}

