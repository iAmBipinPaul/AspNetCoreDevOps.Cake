using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travis_CI.Api.Data;
using Travis_CI.Api.Models;

namespace Travis_CI.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Person>> Index()
        {
            return _dbContext.People.ToList();
        }
    }
}