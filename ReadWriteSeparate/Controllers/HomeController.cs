using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadWriteSeparate.DBModel;
using ReadWriteSeparate.Models;
using System.Diagnostics;

namespace ReadWriteSeparate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            //新增-------------------
            SysUser user = new SysUser()
            {
                UserName="李二狗",
                Account="liergou",
                Password=Guid.NewGuid().ToString(),
                Phone="13345435554",
                CreateTime=DateTime.Now
            };

            Console.WriteLine($"新增,当前链接字符串为:{_dbContext.Database.GetDbConnection().ConnectionString}");
              _dbContext.ReadWrite().Add(user);
              _dbContext.SaveChanges();

            //只读--------------------------------
           var dbContext = _dbContext.Read();
         var users= _dbContext.Read().Set<SysUser>().ToList();
            Console.WriteLine($"读取SysUser,数量为:{users.Count},当前链接字符串为:{_dbContext.Database.GetDbConnection().ConnectionString}");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}