using SAttributeExample.Data.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SAttributeExample.Data.Repo.Concrate
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class
    {
        private readonly SAattributeContext _sAattributeContext;
        public BaseRepository(SAattributeContext sAattributeContext)
        {
            _sAattributeContext = sAattributeContext;
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
