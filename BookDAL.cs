using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work1
{
    interface BookDAL
    {
        //get
        Book getById(int id);
        //create
        void add(Book obj);
        //update
        void update(Book obj);
        //delete
        void delete(Book obj);
        //get all
        List<Book> getAll();
     
    }
}
