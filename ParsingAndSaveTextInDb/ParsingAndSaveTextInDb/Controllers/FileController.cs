using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        private string[] SearchWord(string[] sentences, string word, string[] result)
        {
            int i = 0;
            foreach (string item in sentences)
            {
                if (item.Contains(word))
                {
                    result[i] = item;
                    i++;
                }
            }
            return result;
        }

        private int CountOfWord(string encoded, string word)
        {
            int count = 0;
            foreach (Match item in Regex.Matches(encoded, word, RegexOptions.IgnoreCase))
                ++count;

            return count;
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, string word)
        {
            if (upload != null)
            {
                // получаєм ім'я файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // зберігаємо файл в папку Files в проекті
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));

                string content = System.IO.File.ReadAllText(Server.MapPath("~/Files/" + fileName));

                string[] sentences = content.Split('.');
                string[] result = new string[sentences.Length - 1];

                result = SearchWord(sentences, word, result);

                foreach (var sentence in result)
                {
                    if (sentence != null)
                    {
                        int countOfWord = CountOfWord(sentence, word);

                    }
                }
            }
            return RedirectToAction("Index");
        }

        // GET: File
        public ActionResult Index()
        {
            var db = _context.FileInformation.ToList();
            return View(db);
        }
    }
}