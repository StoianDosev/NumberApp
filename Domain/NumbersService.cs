using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Domain
{
    public class NumbersService : INumbersService
    {
        private readonly IRepository _repository;

        public NumbersService(IRepository repository)
        {
            _repository = repository;
        }

        private static Random _random = new Random();
        public async Task<Number> GetNumber()
        {
            int randomNum = _random.Next(1, 1000);


            Number number = await _repository.Create(new Number() { Value = randomNum });
            return number;
        }

        public async Task<IEnumerable<Number>> GetAllNumbers()
        {
            return await _repository.GetAll();
        }

        public async Task<long> Sum(IList<Number> numbers)
        {
            var sum = await Task.Run(() => { return numbers.Select(x => x.Value).Sum(); });
            return sum;
        }

        public async Task Clear()
        {
            await _repository.DeleteAll();
        }
    }
}
