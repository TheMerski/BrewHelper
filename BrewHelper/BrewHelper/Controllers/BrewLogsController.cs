using System;
using System.Threading;
using System.Threading.Tasks;
using BrewHelper.DTO;
using BrewHelper.Entities;
using BrewHelper.Exceptions;
using BrewHelper.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrewHelper.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrewLogsController : ControllerBase
    {
        private readonly IBrewLogModel brewLogModel;

        public BrewLogsController(IBrewLogModel brewLogModel)
        {
            this.brewLogModel = brewLogModel;
        }
        
        // GET: api/BrewLogs
        [HttpGet]
        [ProducesResponseType(typeof(GenericListResponseDTO<BrewLog>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBrewLogs(
            [FromQuery] UrlQueryParameters urlQueryParameters,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var logs = await brewLogModel.GetByPageAsync(urlQueryParameters.Limit, urlQueryParameters.Page,
                urlQueryParameters.Id, cancellationToken);

            return Ok(logs);
        }
        
        // GET: api/BrewLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrewLog>> GetBrewLog(long id)
        {
            var brewLog = await brewLogModel.GetById(id);

            if (brewLog == null)
            {
                return NotFound();
            }

            return brewLog;
        }
        
        // PUT: api/BrewLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<BrewLog>> Put(long id, BrewLog brewLog)
        {
            if (id != brewLog.Id)
            {
                return BadRequest();
            }

            if (await brewLogModel.Update(id, brewLog) == null)
            {
                return NotFound();
            }

            return brewLog;
        }
        
        // PUT: api/BrewLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BrewLog>> StartBrewLog([FromQuery] long RecipeId)
        {
            if (ModelState.IsValid && RecipeId > 0)
            {
                BrewLog log;
                try
                {
                    log = await brewLogModel.StartLog(RecipeId);
                }
                catch (RecipeNotFoundException e)
                {
                    return NotFound();
                }

                return CreatedAtAction(nameof(GetBrewLog), new { id = log.Id }, log);
            }
            else
            {
                return BadRequest();
            }
        }
        
        // PUT: api/BrewLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}/nextStep")]
        public async Task<ActionResult<BrewLog>> StartNextBrewLogStep(long id)
        {
            BrewLog log;
            try
            {
                log = await brewLogModel.StartNextStep(id);
            }
            catch (BrewLogNotFoundException e)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetBrewLog), new { id = log.Id }, log);
        }
        
        // DELETE: api/BrewLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewLog(long id)
        {
            bool removed = await brewLogModel.Delete(id);
            if (removed)
            {
                return Ok();
            }

            return NotFound();
        }

        public record UrlQueryParameters(int Limit = 50, int Page = 1, string Name = null, long[] Id = null);
    }
}