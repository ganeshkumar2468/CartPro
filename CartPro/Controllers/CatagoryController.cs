using CartPro.BusinessAcessLayer;
using CartPro.DAL;
using CartPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartPro.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly CartProDbContext _cartDBContext;
        public CatagoryController(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }
        public IActionResult Index()
        {
            List<CatagoryVM> list = new List<CatagoryVM>();
            CatagoryRepoPro catagoryRepo = new CatagoryRepoPro(_cartDBContext);
            var data = catagoryRepo.GetCatagories();
            foreach (var item in data)
            {
                list.Add(new CatagoryVM { Id = item.Id, Name = item.Name, Description = item.Description });
            }
            return View(list);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CatagoryVM catagoryVM)
        {
            if (ModelState.IsValid)
            {
                CatagoryBAL catagory = new CatagoryBAL(_cartDBContext);
                if (catagory.AddCatagory(catagoryVM))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Edit(int Id)
        {
            CatagoryVM catagoryVM = new CatagoryVM();
            CatagoryRepoPro catagoryRepo = new CatagoryRepoPro(_cartDBContext);
            var data = catagoryRepo.GetCatagoryId(Id);
            if (data != null)
            {
                catagoryVM.Id = data.Id;
                catagoryVM.Name = data.Name;
                catagoryVM.Description = data.Description;
            }

            return View(catagoryVM);
        }

        [HttpPost]
        public IActionResult Edit(int Id, CatagoryVM catagoryVM)
        {
            if (ModelState.IsValid)
            {
                CatagoryBAL catagoryBAL = new CatagoryBAL(_cartDBContext);
                catagoryBAL.EditCatagory(Id, catagoryVM);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int Id)
        {
            CatagoryVM catagoryVM = new CatagoryVM();
            CatagoryRepoPro catagoryRepo = new CatagoryRepoPro(_cartDBContext);
            var data = catagoryRepo.GetCatagoryId(Id);
            return View(catagoryVM);
        }
        [HttpPost]
        public IActionResult Delete(int Id, CatagoryVM catagoryVM)
        {
            CatagoryBAL catagoryBAL = new CatagoryBAL(_cartDBContext);
            catagoryBAL.DeleteCatagory(Id);
            return RedirectToAction("Index");
        }

    }
}

