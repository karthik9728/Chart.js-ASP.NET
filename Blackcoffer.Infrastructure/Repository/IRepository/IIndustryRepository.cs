using Blackcoffer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackcoffer.Infrastructure.Repository.IRepository
{
    public interface IIndustryRepository : IRepository<Industry>
    {
        void Update(Industry industry);
    }
}
