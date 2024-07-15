using CartPro.DAL;
using CartPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartPro.Controllers
{
    public class RoleController : Controller
    {
        private readonly CartProDbContext _cartDBContext;

        public RoleController(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }
        public IActionResult Index()
        {
            RolesRepoPro rolesRepo = new RolesRepoPro(_cartDBContext);
            var data = rolesRepo.GetRoles();
            return View(data);
        }

        public IActionResult Create()
        {
            Role role = new Role();
            return View(role);
        }

        public IActionResult Edit(int Id)
        {
            RolesRepoPro rolesRepo = new RolesRepoPro(_cartDBContext);
            var data = rolesRepo.GetRolesById(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int id, Role role)
        {
            RolesRepoPro rolesRepo = new RolesRepoPro(_cartDBContext);
            if (rolesRepo.UpdateRole(id, role))
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            RolesRepoPro rolesRepo = new RolesRepoPro(_cartDBContext);
            rolesRepo.AddRole(role);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int Id)
        {
            RolesRepoPro rolesRepo = new RolesRepoPro(_cartDBContext);
            var data = rolesRepo.GetRolesById(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(int id, Role role)
        {
            RolesRepoPro rolesRepo = new RolesRepoPro(_cartDBContext);
            if (rolesRepo.DeleteRole(id))
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
