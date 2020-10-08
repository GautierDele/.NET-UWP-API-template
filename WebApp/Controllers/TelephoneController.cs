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
    /// Controller to manage Telephone
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private readonly IDataRepository<Telephone> _dataRepository;

        /// <summary>
        /// Constructor of TelephoneController.
        /// </summary>
        /// <param name="repository">The data repository</param>
        public TelephoneController(IDataRepository<Telephone> repository)
        {
            _dataRepository = repository;
        }

        /// <summary>
        /// Get all telephones
        /// </summary>
        /// <returns>HTTP Response</returns>
        // GET: api/Telephone
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Telephone>>> GetAllTelephone()
        {
            return await _dataRepository.GetAll();
        }

        /// <summary>
        /// Get an telephone with its id.
        /// </summary>
        /// <param name="id">The id of the telephone</param>
        /// <returns>HTTP Response</returns>
        // GET: api/Telephone/ById/5
        [HttpGet("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Telephone>> GetTelephoneById(int id)
        {
            var telephone = await _dataRepository.GetById(id);

            if (telephone.Value == null)
            {
                return NotFound("Telephone not found");
            }

            return telephone;
        }

        /// <summary>
        /// Get an telephone with its reference.
        /// </summary>
        /// <param name="reference">The reference of the Telephone</param>
        /// <returns>HTTP Response</returns>
        // GET: api/MyEntity/ByReference/A2215
        [HttpGet("ByReference/{reference}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Telephone>> GetTelephoneByReference(string reference)
        {
            var telephone = await _dataRepository.GetByReference(reference);

            if (telephone.Value == null)
            {
                return NotFound("Telephone not found");
            }

            return telephone;
        }

        /// <summary>
        /// Update an telephone.
        /// </summary>
        /// <param name="id">The id of the telephone</param>
        /// <param name="telephone">The new information of the telephone</param>
        /// <returns>HTTP Response</returns>
        // PUT: api/Telephone/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutTelephone(int id, Telephone telephone)
        {
            if (id != telephone.TelephoneId)
            {
                return BadRequest("Ids not matching");
            }

            var telephoneToUpdate = await _dataRepository.GetById(id);
            if (telephoneToUpdate.Value == null)
            {
                return NotFound();
            }
            await _dataRepository.Update(telephoneToUpdate.Value, telephone);
            return NoContent();
        }

        /// <summary>
        /// Adds an telephone to the database.
        /// </summary>
        /// <param name="telephone">The new telephone</param>
        /// <returns>HTTP Response</returns>
        // POST: api/Telephone
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Telephone>> PostTelephone(Telephone telephone)
        {
            try
            {
                await _dataRepository.Add(telephone);
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }
            return CreatedAtAction("PostTelephone", new { id = telephone.TelephoneId }, telephone);
        }

        // DELETE: api/Telephone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Telephone>> DeleteTelephone(int id)
        {
            var telephone = await _dataRepository.GetById(id);
            if (telephone.Value == null)
            {
                return NotFound("Telephone not found");
            }
            await _dataRepository.Delete(telephone.Value);
            return telephone;
        }
    }
}
