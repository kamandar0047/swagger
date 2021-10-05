using Api1.DAL;
using Api1.DTO;
using Api1.Models;
using Api1.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
       
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult GetBook()
        {
            return Ok(_bookService.GetAllBook());
        }
       
  [HttpGet]
  [Route("{id}")]
  public ActionResult GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
      
       public ActionResult Create([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _bookService.Create(book);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id,[FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(_bookService.Edit(id, book));
        }
        [HttpDelete]
        [Route("{id}")]
       public ActionResult Delete(int id)
        {
            return Ok(_bookService.Delete(id));

        }
    }


}
