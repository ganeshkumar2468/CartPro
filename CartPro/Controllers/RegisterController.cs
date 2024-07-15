using CartPro.BusinessAcessLayer;
using CartPro.DAL;
using CartPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartPro.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CartProDbContext _cartDBContext;
        public RegisterController(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }
        public IActionResult Index()
        {
            List<RegisterVM> list = new List<RegisterVM>();
            RegisterRepoPro registerRepo = new RegisterRepoPro(_cartDBContext);
            var data = registerRepo.GetRegister();
            foreach (var item in data)
            {
                list.Add(new RegisterVM { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName, Email = item.Email, PhoneNumber = item.PhoneNumber, Address = item.Address, City = item.City });
            }
            return View(list);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterVM RegisterVM)
        {
            if (ModelState.IsValid)
            {
                RegisterBAL register = new RegisterBAL(_cartDBContext);
                if (register.AddRegister(RegisterVM))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Edit(int Id)
        {
            RegisterVM registerVM = new RegisterVM();
            RegisterRepoPro registerRepo = new RegisterRepoPro(_cartDBContext);
            var data = registerRepo.GetRegisterId(Id);
            if (data != null)
            {
                registerVM.Id = data.Id;
                registerVM.FirstName = data.FirstName;
                registerVM.LastName = data.LastName;
                registerVM.Email = data.Email;
                registerVM.PhoneNumber = data.PhoneNumber;
                registerVM.Address = data.Address;
                registerVM.City = data.City;
            }

            return View(registerVM);
        }

        [HttpPost]
        public IActionResult Edit(int Id, RegisterVM RegisterVM)
        {
            if (ModelState.IsValid)
            {
                RegisterBAL registerBAL = new RegisterBAL(_cartDBContext);
                registerBAL.EditRegister(Id, RegisterVM);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}