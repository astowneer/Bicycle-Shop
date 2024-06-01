using System;
using BicycleApplication.Entities.Models;
using Entities.Enums;
using Entities.Models;

namespace Shared.DataTransferObjects
{
	//public record BicycleDto(int Id, string Name, string Color, int Year, decimal DiameterOfWheels, BrakeType BrakeType, FrameMaterial FrameMaterial, PedantType PedantType, decimal Price);
    public class BicycleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal DiameterOfWheels { get; set; }
        public decimal Price { get; set; }

        public BrakeType BrakeType { get; set; }
        public PedantType PedantType { get; set; }
        public FrameMaterial FrameMaterial { get; set; }

        public BicycleDto() { }

        public BicycleDto(Bicycle bicycle)
        {
            Id = bicycle.Id;
            Name = bicycle.Name;
            Color = bicycle.Color;
            Year = bicycle.Year;
            DiameterOfWheels = bicycle.DiameterOfWheel;
            Price = bicycle.Price;
            BrakeType = bicycle.BrakeType;
            PedantType = bicycle.PedantType;
            FrameMaterial = bicycle.FrameMaterial;
        }
    }

    public class MountainDto : BicycleDto
    {
        public int NumberOfGears { get; set; }

        public MountainDto() { }

        public MountainDto(Bicycle bicycle) : base(bicycle)
        {
            NumberOfGears = bicycle.NumberOfGears;
        }
    }

    public class HighwayDto : BicycleDto
    {
        public int NumberOfGears { get; set; }
        public bool IsDropBar { get; set; }

        public HighwayDto() { }

        public HighwayDto(Bicycle bicycle) : base(bicycle)
        {
            NumberOfGears = bicycle.NumberOfGears;
            IsDropBar = bicycle.IsDropBar;
        }
    }

    public class GravelDto : BicycleDto
    {
        public decimal TireWidth { get; set; }
        public decimal HandlebarWidth { get; set; }

        public GravelDto() { }

        public GravelDto(Bicycle bicycle) : base(bicycle)
        {
            TireWidth = bicycle.TireWidth;
            HandlebarWidth = bicycle.HandlebarWidth;
        }
    }

    public class ElectroDto : BicycleDto
    {
        public string Battery { get; set; }
        public decimal Power { get; set; }

        public ElectroDto() { }

        public ElectroDto(Bicycle bicycle) : base(bicycle)
        {
            Battery = bicycle.Battery;
            Power = bicycle.Power;
        }
    }

    public record BicycleForCreationDto(string name);
	public record BicycleForUpdateDto(string name);
}

