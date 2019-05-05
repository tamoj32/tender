using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ITenderRepository
    {
        Task<IEnumerable<Tender>> GetAllAsync();

        Task<Tender> GetAsyncById(int id);

        Task<int> Add(Tender tender);
    }
}
