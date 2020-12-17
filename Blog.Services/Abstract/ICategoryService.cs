using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Entities.Concrete;

namespace Blog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryId);
        Task<IDataResult<IList<Category>>> GetAll(int categoryId);
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId); // IsActive false olur.
        Task<IResult> HardDelete(int categoryId); //Veri tabanından silinir.
    }
}