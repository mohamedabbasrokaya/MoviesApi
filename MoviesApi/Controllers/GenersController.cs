using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.dtos;
using MoviesApi.Model;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenersController : ControllerBase
    {
        private ApplicationDBContext _Dbcontext;
        public GenersController(ApplicationDBContext Dbcontext)
        {
            _Dbcontext = Dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var geners = await _Dbcontext.Generas.ToListAsync();
            return Ok(geners);
        }
        [HttpPost]
        public async Task<IActionResult> createasync(createGeneraDto dto)
        {
            var gener = new Genera { Name=dto.Name };
            await _Dbcontext.Generas.AddAsync(gener);
            _Dbcontext.SaveChanges();
            return Ok(gener);
            
        }
    }
}
