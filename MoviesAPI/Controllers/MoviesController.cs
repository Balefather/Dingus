using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System.Text.Json;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<SimpleMovie>> GetMovie(int id, int lol)
        {
            string TARGET = $"https://api.themoviedb.org/3/movie/{id}";
            const string HEADERS = "?api_key=a4173f569c8a09917f292a47d536c6c5";
            using HttpClient client = new();
            client.BaseAddress = new Uri(TARGET);
            using HttpResponseMessage response = await client.GetAsync(HEADERS);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Root? movie = JsonSerializer.Deserialize<Root>(jsonResponse);

            if (movie == null)
            {
                return NotFound();
            }

            SimpleMovie sm = new SimpleMovie() { Id = movie.id, Description = movie.tagline, Genre = movie.genres[0].name, Name = movie.title, PosterUrl = movie.poster_path };

            return sm;
        }
    }
}
