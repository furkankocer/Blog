using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;

            await _unitOfWork.Articles.AddAsync(article).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success,$"{articleAddDto.Title} Başlıklı Makale Başarıyla Eklenmiştir.");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;

            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(x => _unitOfWork.SaveAsync());
            
            return new Result(ResultStatus.Success,$"{articleUpdateDto.Title} Başlıklı Makale Başarıyla Güncellenmiştir.");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article =await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,$"{article.Title} Başlıklı Makale Başarıyla Silinmiştir.");
            }
            
            return new Result(ResultStatus.Error,$" Böyle bir Makale Bulunamadı.");
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article =await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,$"{article.Title} Başlıklı Makale Başarıyla Veritabanından Silinmiştir.");
            }
            
            return new Result(ResultStatus.Error,$" Böyle bir Makale Bulunamadı.");
        }
    }
}