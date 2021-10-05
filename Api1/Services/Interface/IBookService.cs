using Api1.DAL;
using Api1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Services.Interface
{
  
  public interface IBookService
    {
        List<BookDTO> GetAllBook();
        BookDTO GetBookById(int id);
  void Create(BookDTO book);
      BookDTO Edit(int id,BookDTO book);
        BookDTO Delete(int id);

    }
}
