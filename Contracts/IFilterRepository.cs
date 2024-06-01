using System;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.Filters;

namespace Contracts
{
	public interface IFilterRepository<T>
	{
        IReadOnlyList<ColorFilter> GetColors();
        IReadOnlyList<YearFilter> GetYears();
        IReadOnlyList<WheelFilter> GetWheels();

        List<T> Filter(List<T> bicycles, List<ColorFilter> color, List<YearFilter> year, List<WheelFilter> wheels);
    }
}

