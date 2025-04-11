using Microsoft.AspNetCore.Mvc;
using QuickServe.Models;
using QuickServe.Data;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace QuickServe.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> _ingredient;
        public IngredientController(ApplicationDbContext context)
        {
            _ingredient = new Repository<Ingredient>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ingredient.GetAllAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _ingredient.GetByIdAsync(id, new QueryOption<Ingredient>() { Includes="ProductIngredients.Product" }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await this._ingredient.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _ingredient.GetByIdAsync(id, new QueryOption<Ingredient>() { Includes = "ProductIngredients.Product" }));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Ingredient ingredient)
        {
            await _ingredient.DeleteAsync(ingredient.IngredientId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _ingredient.GetByIdAsync(id, new QueryOption<Ingredient>() { Includes = "ProductIngredients.Product" }));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IngredientId,Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredient.UpdateAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }
        

    }
}
