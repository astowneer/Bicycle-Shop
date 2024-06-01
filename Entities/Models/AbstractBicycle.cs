using System;
using System.ComponentModel.DataAnnotations;
using Entities.Enums;
namespace Entities.Models
{
	public abstract class AbstractBicycle
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Необхідно вказати ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необхідно вказати колір")]
        [StringLength(15, ErrorMessage = "Довжина кольору не може бути більше 8")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Необхідно вказати рік")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Необхідно вказати тип рами")]
        public FrameMaterial FrameMaterial { get; set; }

        [Required(ErrorMessage = "Необхідно вказати тип тормозу")]
        public BrakeType BrakeType { get; set; }

        [Required(ErrorMessage = "Необхідно вказати тип підвіски")]
        public PedantType PedantType { get; set; }

        [Required(ErrorMessage = "Необхідно вказати діаметр коліс")]
        public decimal DiameterOfWheel { get; set; }

        [Required(ErrorMessage = "Необхідно вказати ціну")]
        [Range(0, 999999999, ErrorMessage = "Ціна може знаходитися в межах від 0 до 999 999 999")]
        public decimal Price { get; set; }

        public AbstractBicycle() { }

		protected AbstractBicycle(AbstractBicycle bicycle)
        {
            Id = bicycle.Id;
            Name = bicycle.Name;
            Color = bicycle.Color;
            Year = bicycle.Year;
            FrameMaterial = bicycle.FrameMaterial;
            BrakeType = bicycle.BrakeType;
            PedantType = bicycle.PedantType;
            DiameterOfWheel = bicycle.DiameterOfWheel;
            Price = bicycle.Price;
        }
	}
}

