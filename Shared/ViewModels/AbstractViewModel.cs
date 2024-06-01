using Entities.Models;
using Shared.Filters;
namespace Shared.ViewModels
{
    public abstract class AbstractViewModel<T> 
    {
        public List<T> Bicycles { get; set; }
        public List<string> ImagesPath { get; set; }

        public List<ColorFilter> ColorFilter { get; set; }
        public List<YearFilter> YearFilter { get; set; }
        public List<WheelFilter> WheelFilter { get; set; }
    }
}