using Blackcoffer.Domain.Model;
using Blackcoffer.Infrastructure.Common;
using Blackcoffer.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackcoffer.Infrastructure.Repository
{
    public class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IndustryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Industry industry)
        {
            var objFromDb = _dbContext.Industries.FirstOrDefault(x => x.Id == industry.Id);
            if (objFromDb != null)
            {
                objFromDb.Sector = industry.Sector;
                objFromDb.Topic = industry.Topic;
                objFromDb.Title = industry.Title;
                objFromDb.Insight = industry.Insight;
                objFromDb.Url = industry.Url;
                objFromDb.Region = industry.Region;
                objFromDb.Impact = industry.Impact;
                objFromDb.Intensity = industry.Intensity;
                objFromDb.Start_Year = industry.Start_Year;
                objFromDb.End_Year = industry.End_Year;
                objFromDb.Added = industry.Added;
                objFromDb.Published = industry.Published;
                objFromDb.Country = industry.Country;
                objFromDb.Relevance = industry.Relevance;
                objFromDb.Pestle = industry.Pestle;
                objFromDb.Source = industry.Source;
                objFromDb.Likelihood = industry.Likelihood;
            }
        }
    }
}
