using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TenderDto>> Get() =>
            await _mediator.Send(new GetTendersQuery());

        [HttpGet("{id}")]
        public async Task<TenderDto> Get(int id) =>
            await _mediator.Send(new GetTenderQuery(id));

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
