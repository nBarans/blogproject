using Microsoft.AspNetCore.Mvc;
using Wissen.Bright.BlogProject.App.Entity.Services;

namespace Wissen.Bright.BlogProject.App.WebMvcUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _articleService.GetAll();
            return View(list);
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await _articleService.Get(id);
            return View(model);
        }
    }
}
