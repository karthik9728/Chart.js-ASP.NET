using Blackcoffer.Domain.ChartModel;
using Blackcoffer.Domain.Model;
using Blackcoffer.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Blackcoffer.Web.Pages.Industries
{
    [BindProperties]
    public class DashboardModel : PageModel
    {
        public IEnumerable<Industry> Industries { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public int CountryCount { get; set; }

        public int RegionCount { get; set; }

        public int SectorCount { get; set; }

        public int TopicCount { get; set; }

        public int PestleCount { get; set; }

        public List<string> PieChartLabels { get; set; } = new List<string>();
        public List<int> PieChartData { get; set; } = new List<int>();

        public List<string> BarChartLabels { get; set; } = new List<string>();
        public List<int> BarChartData { get; set; } = new List<int>();

        public List<string> LineChartLabels { get; set; } = new List<string>();
        public List<int> LineChartData { get; set; } = new List<int>();

        public List<string> PieTopicChartLabels { get; set; } = new List<string>();

        public List<int> PieTopicChartData { get; set; } = new List<int>();

        public List<string> DoughnutChartLabels { get; set; } = new List<string>();
        public List<int> DoughnutChartData { get; set; } = new List<int>();

        public List<CountryIntensity> CountryIntensities { get; set; } = new List<CountryIntensity>();

        public List<RegionRelevance> RegionRelevances { get; set; } = new List<RegionRelevance>();

        public List<SectorLikelihood> SectorLikelihoods { get; set; } = new List<SectorLikelihood>();

        public List<TopicIntensity> TopicIntensities { get; set; } = new List<TopicIntensity>();

        public List<PestleRelevance> PestleRelevances { get; set; } = new List<PestleRelevance>();

        public DashboardModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            Industries = _unitOfWork.Industry.GetAll();


            //with empty country also
            //CountryIntensities = Industries
            //.GroupBy(p => p.Country)
            //.Select(g => new CountryIntensity
            //{
            //    CountryName = g.Key,
            //    Intensity = g.Sum(p => p.Intensity)
            //})
            //.ToList();

            CountryIntensities = Industries
            .Where(p => !string.IsNullOrEmpty(p.Country))
            .GroupBy(p => p.Country)
            .Select(g => new CountryIntensity
            {
                CountryName = g.Key,
                Intensity = g.Sum(p => p.Intensity)
            })
            .ToList();

            CountryCount = CountryIntensities.Count;

            foreach (var item in CountryIntensities)
            {
                PieChartLabels.Add(item.CountryName);
                PieChartData.Add(item.Intensity);
            }

            //Region and Relevance

            RegionRelevances = Industries
            .Where(p => !string.IsNullOrEmpty(p.Region))
            .GroupBy(p => p.Region)
            .Select(g => new RegionRelevance
            {
                Region = g.Key,
                Relevance = g.Sum(p => p.Relevance)
            })
            .ToList();

            RegionCount = RegionRelevances.Count;

            foreach (var item in RegionRelevances)
            {
                BarChartLabels.Add(item.Region);
                BarChartData.Add(item.Relevance);
            }

            //Sector and Likelihood

            SectorLikelihoods = Industries
            .Where(p => !string.IsNullOrEmpty(p.Sector))
            .GroupBy(p => p.Sector)
            .Select(g => new SectorLikelihood
            {
                Sector = g.Key,
                Likelihood = g.Sum(p => p.Likelihood)
            })
            .ToList();

            SectorCount = SectorLikelihoods.Count;

            foreach (var item in SectorLikelihoods)
            {
                LineChartLabels.Add(item.Sector);
                LineChartData.Add(item.Likelihood);
            }

            //Topic and Intensity

            TopicIntensities = Industries
           .Where(p => !string.IsNullOrEmpty(p.Region))
           .GroupBy(p => p.Topic)
           .Select(g => new TopicIntensity
           {
               Topic = g.Key,
               Intensity = g.Sum(p => p.Intensity)
           })
           .ToList();


            TopicCount = TopicIntensities.Count;

            foreach (var item in TopicIntensities)
            {
                PieTopicChartLabels.Add(item.Topic);
                PieTopicChartData.Add(item.Intensity);
            }

            //Pestle and Relevance

            PestleRelevances = Industries
           .Where(p => !string.IsNullOrEmpty(p.Pestle))
           .GroupBy(p => p.Pestle)
           .Select(g => new PestleRelevance
           {
               Pestle = g.Key,
               Relevance = g.Sum(p => p.Relevance)
           })
           .ToList();


            PestleCount = PestleRelevances.Count;

            foreach (var item in PestleRelevances)
            {
                DoughnutChartLabels.Add(item.Pestle);
                DoughnutChartData.Add(item.Relevance);
            }

        }
    }
}
