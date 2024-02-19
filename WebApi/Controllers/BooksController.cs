using Application.Features.Books.Commands.Create;

using Application.Features.Books.Commands.Update;

using Application.Features.Books.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBookCommand createBookCommand)
        {
            CreatedBookResponse response = await Mediator.Send(createBookCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBookQuery getListBookQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBookListItemDto> response = await Mediator.Send(getListBookQuery);
            return Ok(response);
        }

        

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
        {
            UpdatedBookResponse response = await Mediator.Send(updateBookCommand);

            return Ok(response);
        }

        
    }
}
