using Blackcoffer.Domain.Model;
using Blackcoffer.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blackcoffer.Web.Pages.Industries
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public IEnumerable<Industry> Industries { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            Industries = _unitOfWork.Industry.GetAll();
        }
    }
}
