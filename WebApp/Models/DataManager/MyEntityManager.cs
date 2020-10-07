using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.EntityFramework;
using WebApp.Models.Repository;

namespace WebApp.Models.DataManager
{
    public class MyEntityManager : IDataRepository<MyEntity>
    {
        readonly DSDBContext _context;
        public MyEntityManager(DSDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<MyEntity>>> GetAll()
        {
            return await _context.MyEntity.ToListAsync();
        }
        public async Task<ActionResult<MyEntity>> GetById(int id)
        {
            return await _context.MyEntity.FirstOrDefaultAsync(e => e.MyEntityId == id);
        }
        //public async Task<ActionResult<MyEntity>> GetByString(string prop)
        //{
        //    return await _context.MyEntity.FirstOrDefaultAsync(e => e.Prop.ToUpper() == prop.ToUpper());
        //}
        public async Task Add(MyEntity entity)
        {
            await _context.MyEntity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(MyEntity myEntity, MyEntity entity)
        {
            _context.Entry(myEntity).State = EntityState.Modified;
            myEntity.MyEntityId = entity.MyEntityId;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(MyEntity myEntity)
        {
            _context.MyEntity.Remove(myEntity);
            await _context.SaveChangesAsync();
        }
    }
}
