using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Mortgage.Calculator.Interfaces;
using Mortgage.Data.DTO;
using Mortgage.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mortgage.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMortgageProspect _repo;
        private readonly IMortgageManager _mortgageManager;

        [BindProperty] public ProspectDTO ProspectDTO { get; set; }
        public IList<ProspectDTO> Prospects { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IMortgageProspect repo, IMortgageManager mortgageManager)
        {
            _repo = repo;
            _logger = logger;
            _mortgageManager = mortgageManager;
        }

        public async Task OnGetAsync()
        {
            //return Page();
            Prospects = await _repo.GetListAsync();
        }
        public async Task<ActionResult> OnPostAsync()
        {
            var pro = await _repo.GetProspectAsync(ProspectDTO.Id);

            ViewData["MortageResult"] =  _mortgageManager.MortgageCalculatorResponse(pro.Id, pro.CustomerName, pro.LoanAmount, pro.AnnualInterest, pro.LoanTerm);
            ViewData["selected"] = "disabled";
            Prospects = new List<ProspectDTO>();
            Prospects.Add(pro);
            return Page();
        }
    }
}
