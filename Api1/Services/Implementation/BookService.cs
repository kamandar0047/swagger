using Api1.DAL;
using Api1.DTO;
using Api1.Models;
using Api1.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Services.Implementation
{
    public class BookService:IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(BookDTO book)
        {
            var newBook = _mapper.Map<Book>(book);
            _context.Book.Add(newBook);
            _context.SaveChanges();
           
        }

        public BookDTO Delete(int id)
        {
            var bookDb = _context.Book.FirstOrDefault(m => m.Id == id);
            if (bookDb is null)
                return null;
            _context.Book.Remove(bookDb);
            _context.SaveChanges();
            return _mapper.Map<BookDTO>(bookDb);

        }

        public BookDTO Edit(int id, BookDTO book)
        {
            var bookDb = _context.Book.FirstOrDefault(m => m.Id == id);
            if (bookDb is null)
                return null;
            book.Id = bookDb.Id;
            _mapper.Map(book, bookDb);
            _context.SaveChanges();
            return book;
        }

        public List<BookDTO> GetAllBook()
        {
            var book = _context.Book.ToList();
            return _mapper.Map<List<BookDTO>>(book);
        }

        public BookDTO GetBookById(int id)
        {
            var bookDb = _context.Book.FirstOrDefault(m => m.Id == id);
            if (bookDb == null)
                return null;
            return _mapper.Map<BookDTO>(bookDb);
        }

    }
}
