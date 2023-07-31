using Blackcoffer.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackcoffer.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IIndustryRepository Industry { get; }

        void Save();
    }
}
