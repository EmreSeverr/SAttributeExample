using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SAttributeExample.Data.Repo.Abstract
{
    public interface IBaseRepository<Tentity> where Tentity : class
    {
        Task AddAsync(Tentity tentity);

        void Update(Tentity tentity);
    }
}
