using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;

namespace Blog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IDataResult<Category>> Get(int categoryId)
        {
           var category =  await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId,x=>x.Articles);
           
           if (category != null )
           {
               return new DataResult<Category>(ResultStatus.Success,category);
           }
           
           return new DataResult<Category>(ResultStatus.Error,"Böyle bir kategori bulunamadı",null);
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, x => x.Articles);

            if (categories.Any())
            {
                return new DataResult<IList<Category>>(ResultStatus.Success,categories);
            }
            
            return new DataResult<IList<Category>>(ResultStatus.Error,"Hiç bir kategori bulunamadı",null);
        }

        public async Task<IDataResult<IList<Category>>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted,x=>x.Articles);

            if (categories.Any())
            {
                return new DataResult<IList<Category>>(ResultStatus.Success,categories);
            }
            
            return new DataResult<IList<Category>>(ResultStatus.Error,"Hiç bir kayıt bulunamadı",null);
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> Delete(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> HardDelete(int categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}