using Microsoft.AspNetCore.Mvc;
using Test_Car.Domain.Models.Base.Contracts;
using Test_Car.Domain.Services.Base;
using System.Linq.Dynamic.Core;
namespace Test_Car.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CrudControllerBase<T, Tkey> : ControllerBase
        where T : class, IEntity
    {
        #region Private Members

        private static IService<T, Tkey> _service;

        #endregion

        #region Public Constructor

        public CrudControllerBase(IService<T, Tkey> service)
        {
           _service = service;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            var data = _service.GetAll().OrderBy(nameof(IEntity<Tkey>.Id));
            return Ok(data);
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetAsync(Tkey id)
        {
            var record = await _service.Find(id);
            if (record == null)
                return NotFound(id);

            return Ok(record);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rec = await _service.Create(entity);
            return CreatedAtAction(nameof(Post), rec);
        }

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(Tkey id, T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Modify(id, entity);
            return Ok(entity);
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Tkey id)
        {
            var entity = await _service.Delete(id);

            if (entity == null)
                return NotFound(id);

            return Ok(entity);
        }

        #endregion
    }
}
