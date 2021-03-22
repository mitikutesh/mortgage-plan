using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mortgage.Data.DTO;
using Mortgage.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data.Repository
{
    public class MortgageProspect : IMortgageProspect
    {
        private readonly MortgagePlannerContext _context;
        private IMapper _mapper;
        public MortgageProspect(MortgagePlannerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(ProspectDTO prospectDto)
        {
            if (prospectDto is null) return default;
            var prospect = _mapper.Map<ProspectDTO, Prospect>(prospectDto);

            _context.Prospects.Add(prospect);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProspectAsync(int id)
        {
            var val = await _context.Prospects.FindAsync(id);
            if (val == null)
                return default;
            _context.Remove(val);
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<bool> EditProspectAsync(ProspectDTO prospectDto)
        {
            var prospect = _mapper.Map<ProspectDTO, Prospect>(prospectDto);
            Prospect _p = null;

            _p = _context.Prospects
                .Where(s => s.Id == prospect.Id)
                .FirstOrDefault<Prospect>();
            if (_p is null) return default;

            _context.Prospects.Update(prospect);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ProspectDTO>> GetListAsync()
        {
            var prospects = await _context.Prospects.ToListAsync();
            var result =   _mapper.Map<List<Prospect>, List<ProspectDTO>> (prospects);
            return result;
        }

        public async Task<ProspectDTO> GetProspectAsync(int id)
        {
            var prospect  = await  _context.Prospects.FindAsync(id);
            return _mapper.Map<Prospect, ProspectDTO>(prospect);
        }

       
    }
}
