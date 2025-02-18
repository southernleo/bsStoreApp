﻿using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters)
        {
            var pagedResult = await _manager
                .BookService
                .GetAllBooksAsync(bookParameters, false);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedResult.metadata));

            return Ok(pagedResult.books);
        }
        [HttpGet("{id:int}")]
        public async Task <IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
           
                var book = await _manager
                    .BookService
                    .GetOneBookByIdAsync(id, false);
                if (book is null)
                {
                      throw new BookNotFoundException(id);
                }
                return Ok(book);
           
           
        }
        [ServiceFilter(typeof(ValidationFiterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
         
                var book= await  _manager.BookService.CreateOneBookAsync(bookDto);
                return StatusCode(201, book);          
        }
        [ServiceFilter(typeof (ValidationFiterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, 
            [FromBody] BookDtoForUpdate bookDto)
        {
            
                if (bookDto is null)
                    return BadRequest();
                if (!ModelState.IsValid)
                    return UnprocessableEntity();
                await _manager.BookService.UpdateOneBookAsync(id, bookDto, true);
                return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task  <IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
          
                await _manager.BookService.DeleteOneBookAsync(id, false);

                return NoContent();
           

        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
                if(bookPatch is null)
                    return BadRequest();
               
                var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);
                bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);
                TryValidateModel(result.bookDtoForUpdate);
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);
                return NoContent();
           
        }

      


    }
}
