using EnglishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishDictionary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Meaning(string word)
        {
            string meaning = Model.TrieDictionary.GetData(word);
            return Content(meaning);
        }

        public ActionResult Suggestions(string word)
        {
            List<string> suggestions = Model.TrieDictionary.GetSuggestions(word);
            JsonResult ret = Json(suggestions, JsonRequestBehavior.AllowGet);
            return ret;
        }
    }
}
