using CrudRepository.Core;
using CrudRepository.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepository.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAll();
            return View(products); 
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Product());
            }
            else
            {
                try
                {
                    Product product = await _productRepository.GetById(id);
                    if (product != null)
                    {
                        return View(product);
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] = $"Product details not found with Id:{id}";
                return RedirectToAction("Index");
            } 
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        await _productRepository.Add(model);
                        TempData["successMessage"] = "Product Created Successfully!";
                    }
                    else
                    {
                        await _productRepository.Update(model);
                        TempData["successMessage"] = "Product Details Updated Successfully!";
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["errorMessage"] = "Model state is invalid!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }  
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product product = await _productRepository.GetById(id);
                if (product != null)
                {
                    return View(product);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["errorMessage"] = $"Product details not found with Id:{id}";
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productRepository.Delete(id);
                TempData["successMessage"] = "Product Deleted Successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

    }
}
