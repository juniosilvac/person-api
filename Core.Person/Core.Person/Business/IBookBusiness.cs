﻿using Core.Person.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Person.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);

        bool Exist(long id);
    }
}
