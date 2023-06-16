using CafeApp.Data.Repository;
using CafeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IRepository<News> newsRepository;

        public NewsController(IRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var news = await newsRepository.GetAll();
            return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await newsRepository.GetById(id);

            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        [HttpPost]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            await newsRepository.Add(news);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, [FromBody] News news)
        {
            var existingNews = await newsRepository.GetById(id);

            if (existingNews == null)
            {
                return NotFound();
            }

            existingNews.Title = news.Title;
            existingNews.Content = news.Content;
            existingNews.DatePublish = DateTime.Now;

            await newsRepository.Update(existingNews);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await newsRepository.GetById(id);

            if (news == null)
            {
                return NotFound();
            }

            await newsRepository.Delete(news);
            return Ok();
        }
    }
}
