using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Domain
{
    public interface INumbersService
    {
        Task<Number> GetNumber();
        Task<IEnumerable<Number>> GetAllNumbers();
        Task<long> Sum(IList<Number> numbers);
        Task Clear();
    }
}