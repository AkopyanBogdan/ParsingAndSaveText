using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsingAndSaveTextInDb.Models;

namespace ParsingAndSaveTextInDb.Controllers
{
    public class FileController : Controller
    {
        private ApplicationDbContext _context;

        public FileController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: File
        public ActionResult Index()
        {
            var db = _context.FileInformation.ToList();
            return View(db);
        }
    }
}