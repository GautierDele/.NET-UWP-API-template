using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.EntityFramework;
using WebApp.Models.Repository;

namespace WebApp.Models.DataManager
{
    public class TelephoneManager : IDataRepository<Telephone>
    {
        readonly DSDBContext _context;
        public TelephoneManager(DSDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Telephone>>> GetAll()
        {
            return await _context.Telephone.ToListAsync();
        }
        public async Task<ActionResult<Telephone>> GetById(int id)
        {
            return await _context.Telephone.FirstOrDefaultAsync(e => e.TelephoneId == id);
        }
        public async Task<ActionResult<Telephone>> GetByReference(string reference)
        {
            return await _context.Telephone.FirstOrDefaultAsync(e => e.Reference.ToUpper() == reference.ToUpper());
        }
        public async Task Add(Telephone telephone)
        {
            await _context.Telephone.AddAsync(telephone);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Telephone myTelephone, Telephone telephone)
        {
            _context.Entry(myTelephone).State = EntityState.Modified;
            myTelephone.TelephoneId = telephone.TelephoneId;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Telephone telephone)
        {
            _context.Telephone.Remove(telephone);
            await _context.SaveChangesAsync();
        }
    }
}
