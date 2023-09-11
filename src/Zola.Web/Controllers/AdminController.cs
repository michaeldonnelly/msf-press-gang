using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Zola.Database;
using Zola.Database.Models;
using Zola.MsfClient;
using Zola.Web.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using System.Collections.Generic;

namespace Zola.Web.Controllers
{
	public class AdminController : Controller
	{
		private readonly ILogger<AdminController> _logger;
        private readonly MsfDbContext _msfDbContext;
        private readonly ApiSettings _apiSettings;

        public AdminController(ILogger<AdminController> logger, MsfDbContext dbContext, IConfiguration configuration)
        {
            _logger = logger;
            _msfDbContext = dbContext;
            _apiSettings = new(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            string tableName = "Users";
            IEnumerable<object> set = (IEnumerable<object>)_msfDbContext.GetType().GetProperty(tableName).GetValue(_msfDbContext, null);
            int recordCount = set.Count();
            Console.WriteLine($"Records in {tableName}: {recordCount}");

            return View();
        }
    }
}

