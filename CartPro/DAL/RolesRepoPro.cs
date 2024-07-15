using CartPro.Models;

namespace CartPro.DAL
{
    public class RolesRepoPro
    {
        private readonly CartProDbContext _cartDBContext;

        public RolesRepoPro(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }

        public List<Role> GetRoles()
        {
            var roles = _cartDBContext.Roles.ToList();
            return roles;
        }

        public Role GetRolesById(int id)
        {
            var role = _cartDBContext.Roles.FirstOrDefault(c => c.Id == id);
            return role;
        }

        public bool AddRole(Role role)
        {
            try
            {
                _cartDBContext.Roles.Add(role);
                _cartDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRole(int Id, Role role)
        {
            try
            {
                var data = GetRolesById(Id);
                if (data != null)
                {
                    data.Name = role.Name;
                    _cartDBContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(int Id)
        {
            try
            {
                var data = GetRolesById(Id);
                if (data != null)
                {
                    _cartDBContext.Roles.Remove(data);
                    _cartDBContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
