using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Takas.Business.Abstract;
using Takas.Common.Entities.Concrete;


namespace Takas.MvcWebUI.Areas.Admin.Controllers
{
    public class AdminPart2Controller : Controller
    {
	    private ICategoryService _categoryService;

	    public AdminPart2Controller(ICategoryService categoryService)
	    {
		    _categoryService = categoryService;
	    }

	    #region
        // GET: Admin/AdminPart2
        public async Task<ActionResult> CategoryList()
        {
	        List<Category> categories;
	        try
	        {
		        categories = await _categoryService.GetList();
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw;
	        }

            return View("_PartialPageAdminPanelCategoryList", categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
	        try
	        {
		        _categoryService.Add(category);
		        return RedirectToAction("CategoryList");
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		       return new HttpNotFoundResult();
	        }
           
        }

        public ActionResult Update(int id)
        {
	        Category category;
	        try
	        {
				category = _categoryService.Get(id); return View(category);
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
				return  new HttpNotFoundResult();
		     
	        }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
	            try
	            {
		            _categoryService.Update(category);
	            }
	            catch (Exception e)
	            {
		            Console.WriteLine(e);
	            }
                return RedirectToAction("CategoryList");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Delete(int id)
        {
	        try
	        {
		       var category = _categoryService.Get(id);
			   _categoryService.Delete(category);
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        
	        }
            return RedirectToAction("CategoryList");
        }
        #endregion

        public ActionResult MessageList()
        {
            return View("_PartialPageAdminPanelMessageList");
        }

    }
}