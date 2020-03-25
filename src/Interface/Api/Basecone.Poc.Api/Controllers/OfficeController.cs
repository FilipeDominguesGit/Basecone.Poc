using AutoMapper;
using Basecone.Poc.Api.Contracts.Requests;
using Basecone.Poc.Api.Contracts.Responses;
using Basecone.Poc.Application.Commands;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basecone.Poc.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OfficeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        /// <summary>
        /// Creates an Office.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Office
        ///     {
        ///        "officeCode"  : "Code"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>A newly created Office</returns>
        /// <response code="201">Returns the newly created office</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Office>> CreateOffice([FromBody]CreateOfficeRequest request)
        {

            var command = new CreateOfficeCommand(request.OfficeCode);

            var response = await _mediator.Send(command);

            var office = _mapper.Map<Office>(response);

            return CreatedAtAction("Get", "Office", new { OfficeId = office.UniqueId }, office);
        }

        [HttpGet]
        public async Task<ActionResult<List<OfficeDto>>> GetAll()
        {

            var command = new GetAllOfficesQuery();

            var response = await _mediator.Send(command);

            var offices = _mapper.Map<List<Office>>(response);

            return Ok(offices);
        }

        [HttpGet("{officeId}")]
        public async Task<ActionResult<Office>> Get(Guid officeId)
        {

            var query = new GetOfficeByUniqueIdQuery(officeId);

            var response = await _mediator.Send(query);

            var office = _mapper.Map<Office>(response);

            return Ok(office);
        }

        [HttpPost("{officeId}/company")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Company>> AddCompany([FromBody] AddCompanyToOfficeRequest request, Guid officeId)
        {

            var command = new AddNewCompanyToOfficeCommand(officeId, request.CompanyCode);

            var response = await _mediator.Send(command);

            var company = _mapper.Map<Company>(response);

            return CreatedAtAction("GetOfficeCompany", "Office", new { OfficeId = company.UniqueId, CompanyId = company.UniqueId }, company);
        }

        [HttpGet("{officeId}/company")]
        public async Task<ActionResult<List<Company>>> GetCompanies(Guid officeId)
        {

            var query = new GetAllOfficeCompaniesQuery(officeId);

            var response = await _mediator.Send(query);

            var companies = _mapper.Map<List<Company>>(response);

            return Ok(companies);
        }

        [HttpGet("{officeId}/company/{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetOfficeCompany(Guid officeId, Guid companyId)
        {
            var query = new GetOfficeCompanyQuery(officeId, companyId);

            var response = await _mediator.Send(query);

            var company = _mapper.Map<Company>(response);

            return Ok(company);
        }

    }
}