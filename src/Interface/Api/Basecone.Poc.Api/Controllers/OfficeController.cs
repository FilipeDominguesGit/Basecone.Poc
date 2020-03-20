using Basecone.Poc.Api.Contracts.Requests;
using Basecone.Poc.Application.Commands;
using Basecone.Poc.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basecone.Poc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OfficeDto>> CreateOffice([FromBody]CreateOfficeRequest request)
        {

            var command = new CreateOfficeCommand(request.OfficeCode);

            var response = await _mediator.Send(command);

            return CreatedAtAction("Get", "Office", new { OfficeId = response.UniqueId }, response);
        }

        [HttpGet]
        public async Task<ActionResult<List<OfficeDto>>> GetAll()
        {

            var command = new GetAllOfficesCommand();

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{officeId}")]
        public async Task<ActionResult<OfficeDto>> Get(Guid officeId)
        {

            var command = new GetOfficeByUniqueIdCommand(officeId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("{officeId}/company")]
        public async Task<ActionResult<CompanyDto>> AddCompany([FromBody] AddCompanyToOfficeRequest request, Guid officeId)
        {

            var command = new AddNewCompanyToOfficeCommand(officeId, request.CompanyCode);

            var response = await _mediator.Send(command);

            return CreatedAtAction("GetOfficeCompany", "Office", new { OfficeId = response.UniqueId, CompanyId = response.UniqueId }, response);
        }

        [HttpGet("{officeId}/company")]
        public async Task<ActionResult<List<CompanyDto>>> GetCompanies(Guid officeId)
        {

            var command = new GetAllOfficeCompaniesCommand(officeId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{officeId}/company/{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetOfficeCompany(Guid officeId, Guid companyId)
        {

            var command = new GetOfficeCompanyCommand(officeId, companyId);

            var response = await _mediator.Send(command);

            return response;
        }

    }
}