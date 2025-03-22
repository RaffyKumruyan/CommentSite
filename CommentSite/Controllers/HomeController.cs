using Microsoft.AspNetCore.Mvc;
using CommentSite.Models;
using Newtonsoft.Json;

namespace CommentSite.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string CommentFilePath = "App_Data/comments.json";

        public IActionResult Index()
        {
            var comments = LoadComments();
            ViewBag.Comments = comments;
            return View();
        }

        [HttpPost]
        public IActionResult PostComment(Comment comment)
        {
            if (!string.IsNullOrWhiteSpace(comment.Name) && !string.IsNullOrWhiteSpace(comment.Message))
            {
                var comments = LoadComments();
                comments.Add(comment);
                SaveComments(comments);
            }
            return RedirectToAction("Index");
        }

        private List<Comment> LoadComments()
        {
            if (!System.IO.File.Exists(CommentFilePath))
                return new List<Comment>();

            var json = System.IO.File.ReadAllText(CommentFilePath);
            return JsonConvert.DeserializeObject<List<Comment>>(json) ?? new List<Comment>();
        }

        private void SaveComments(List<Comment> comments)
        {
            var json = JsonConvert.SerializeObject(comments, Formatting.Indented);
            var dir = Path.GetDirectoryName(CommentFilePath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            System.IO.File.WriteAllText(CommentFilePath, json);
        }
    }
}