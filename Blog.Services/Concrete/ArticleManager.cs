using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore.Metadata;
using ProgrammersBlog.Data.Abstract;

namespace Blog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId, x => x.User, x => x.Category);

            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, x => x.User, x => x.Category);

            if (articles.Any())
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted, x => x.User, x => x.Category);
            if (articles.Any())
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles =
                await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.User, x => x.Category);
            if (articles.Any())
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(x => x.Id == categoryId);
            if (result)
            {
                var articles =
                    await _unitOfWork.Articles.GetAllAsync(
                        x => x.CategoryId == categoryId && !x.IsDeleted && x.IsActive,
                        x => x.User, x => x.Category);

                if (articles.Any())
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makale bulunamadı", null);
            }
            
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);
        }

        public Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> HardDelete(int articleId)
        {
            throw new System.NotImplementedException();
        }
    }
}