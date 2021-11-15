using Microsoft.EntityFrameworkCore;
using SAttributeExample.Data.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAttributeExample.Data.Repo.Concrate
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class
    {
        private readonly SAttributeContext _sAattributeContext;
        public BaseRepository(SAttributeContext sAattributeContext)
        {
            _sAattributeContext = sAattributeContext;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _sAattributeContext.Set<Tentity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task AddAsync(Tentity tentity)
        {
            await _sAattributeContext.Set<Tentity>().AddAsync(tentity).ConfigureAwait(false);
        }
        
        public void Update(Tentity tentity)
        {
            _sAattributeContext.Set<Tentity>().Update(tentity);
        }
    }
}
