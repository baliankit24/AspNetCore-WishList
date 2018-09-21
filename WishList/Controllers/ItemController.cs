namespace WishList.Controller
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using WishList.Data;
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(WishList.Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var itemToBeDeleted = _context.Items.Where(x => x.Id == id).FirstOrDefault();
            _context.Items.Remove(itemToBeDeleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}