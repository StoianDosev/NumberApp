using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
    public interface IRepository
    {
        Task<IEnumerable<Number>> GetAll();

        Task<Number> Get(int id);

        Task<Number> Create(Number number);

        Task Delete(int id);

        Task DeleteAll();
    }
}