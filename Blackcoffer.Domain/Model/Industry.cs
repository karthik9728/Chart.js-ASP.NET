using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackcoffer.Domain.Model
{
    public class Industry
    {
        [Key]
        public int Id { get; set; }

        public string? Sector { get;set; }

        public string? Topic { get; set; }

        public string Title { get; set; }

        public string Insight { get; set; }

        public string Url { get; set; }

        public string Region { get; set; }

        public int Impact { get; set; }

        public int Intensity { get; set; }

        public DateTime? Start_Year { get; set; }

        public DateTime? End_Year { get; set; }

        public DateTime Added { get; set; }

        public DateTime Published { get; set; }

        public string? Country { get; set; }

        public int Relevance  { get; set; }

        public string Pestle  { get; set; }

        public string Source  { get; set; }

        public int Likelihood { get; set; }
    }
}
