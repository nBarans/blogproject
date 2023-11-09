using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Bright.BlogProject.App.Entity.Entities;
using Wissen.Bright.BlogProject.App.Entity.Services;
using Wissen.Bright.BlogProject.App.Entity.UnitOfWorks;
using Wissen.Bright.BlogProject.App.Entity.ViewModels;

namespace Wissen.Bright.BlogProject.App.Service.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;
        public ArticleService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ArticleViewModel>> GetAll()
        {
            //_uow.GetRepository<Article>() -> Repository<Article>'a karşılık geliyor.
            var list = await _uow.GetRepository<Article>().GetAllAsync();

            //var listModel = new List<ArticleViewModel>();

            //foreach (var item in list)
            //{
            //    listModel.Add(new()
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        Summary = item.Summary,
            //        Content = item.Content
            //    });
            //}

            return _mapper.Map<List<ArticleViewModel>>(list);  //mapping yapılmalı.
           
        }
        public async Task<ArticleViewModel> Get(int id)
        {
            var article = await _uow.GetRepository<Article>().GetById(id);
            return _mapper.Map<ArticleViewModel>(article);
        }


    }
}
