using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreDevOps.Api.Data;
using AspNetCoreDevOps.Api.Models;

namespace AspNetCoreDevOps.Api.Controllers
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