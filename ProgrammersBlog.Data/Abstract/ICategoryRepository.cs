﻿using System;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;

namespace ProgrammersBlog.Data.Abstract
{
    public interface ICategoryRepository : IEntitiyRepository<Category>
    {
    }
}