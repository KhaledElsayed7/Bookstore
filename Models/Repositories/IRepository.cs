using System.Collections.Generic;
namespace Bookstore.Models
   
{
    public interface IRepository<T>
    {
    List<T> GetAll();
    T GetById(int id);
    void Add(T item);
    void Edit(int id,T item);
    void Delete(int id);
        //object List();
    }
}
