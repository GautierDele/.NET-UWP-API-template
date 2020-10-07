using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.EntityFramework;
using WebApp.Models.Repository;

namespace WebApp.Controllers
{
    /// <summary>
    /// Controller to manage MyEntity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MyEntityController : ControllerBase
    {
        private readonly IDataRepository<MyEntity> _dataRepository;

        /// <summary>
        /// Constructor of MyEntityController.
        /// </summary>
        /// <param name="repository">The data repository</param>
        public MyEntityController(IDataRepository<MyEntity> repository)
        {
            _dataRepository = repository;
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>HTTP Response</returns>
        // GET: api/MyEntity
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MyEntity>>> GetAllMyEntity()
        {
            return await _dataRepository.GetAll();
        }

        /// <summary>
        /// Get an account with its id.
        /// </summary>
        /// <param name="id">The id of the account</param>
        /// <returns>HTTP Response</returns>
        // GET: api/MyEntity/ById/5
        [HttpGet("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MyEntity>> GetMyEntityById(int id)
        {
            var myEntity = await _dataRepository.GetById(id);

            if (myEntity.Value == null)
            {
                return NotFound("MyEntity not found");
            }

            return myEntity;
        }

        /// <summary>
        /// Get an account with its email.
        /// </summary>
        /// <param name="prop">The prop of the MyEntity</param>
        /// <returns>HTTP Response</returns>
        // GET: api/MyEntity/ByString/myemail@example.com
        //[HttpGet("ByString/{prop}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<MyEntity>> GetMyEntityByProp(string prop)
        //{
        //    var myEntity = await _dataRepository.GetByString(prop);

        //    if (myEntity.Value == null)
        //    {
        //        return NotFound("MyEntity not found");
        //    }

        //    return myEntity;
        //}

        /// <summary>
        /// Update an account.
        /// </summary>
        /// <param name="id">The id of the account</param>
        /// <param name="myEntity">The new information of the account</param>
        /// <returns>HTTP Response</returns>
        // PUT: api/MyEntity/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMyEntity(int id, MyEntity myEntity)
        {
            if (id != myEntity.MyEntityId)
            {
                return BadRequest("Ids not matching");
            }

            var myEntityToUpdate = await _dataRepository.GetById(id);
            if (myEntityToUpdate.Value == null)
            {
                return NotFound();
            }
            await _dataRepository.Update(myEntityToUpdate.Value, myEntity);
            return NoContent();
        }

        /// <summary>
        /// Adds an account to the database.
        /// </summary>
        /// <param name="myEntity">The new account</param>
        /// <returns>HTTP Response</returns>
        // POST: api/MyEntity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MyEntity>> PostMyEntity(MyEntity myEntity)
        {
            try
            {
                await _dataRepository.Add(myEntity);
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }
            return CreatedAtAction("PostMyEntity", new { id = myEntity.MyEntityId }, myEntity);
        }

        // DELETE: api/MyEntity/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<MyEntity>> DeleteMyEntity(int id)
        //{
        //    var myEntity = await _dataRepository.GetById(id);
        //    if (myEntity.Value == null)
        //    {
        //        return NotFound("MyEntity not found");
        //    }
        //    await _dataRepository.Delete(myEntity.Value);
        //    return myEntity;
        //}
    }
}
