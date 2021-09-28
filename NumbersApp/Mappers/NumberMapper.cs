using Data.Models;
using NumbersApp.Models;

namespace NumbersApp.Mappers
{
    public static class NumberMapper
    {
        public static NumberDto MapDto(Number model)
        {
            return new NumberDto{Id = model.Id, Value = model.Value};
        }

        public static Number MapModel(NumberDto dto)
        {
            return new Number{Id = dto.Id, Value = dto.Value};
        }
    }
}