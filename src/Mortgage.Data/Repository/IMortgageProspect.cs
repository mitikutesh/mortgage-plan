using Mortgage.Data.DTO;
using Mortgage.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data.Repository
{
    public interface IMortgageProspect
    {
        Task<bool> AddAsync(ProspectDTO prospect);

        Task<List<ProspectDTO>> GetListAsync();

        Task<ProspectDTO> GetProspectAsync(int id);

        Task<bool> EditProspectAsync(ProspectDTO prospect);

        Task<bool> DeleteProspectAsync(int id);
    }
}
