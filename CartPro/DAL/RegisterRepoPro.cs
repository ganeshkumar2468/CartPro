using CartPro.Models;

namespace CartPro.DAL
{
    public class RegisterRepoPro
    {
        private readonly CartProDbContext _cartDBContext;

        public RegisterRepoPro(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }
        public List<Register> GetRegister()
        {
            var registers = _cartDBContext.Register.ToList();
            return registers;
        }

        public Register GetRegisterId(int id)
        {
            var register = _cartDBContext.Register.FirstOrDefault(c => c.Id == id);
            return register;
        }
        public bool AddRegister(Register register)
        {
            try
            {
                _cartDBContext.Register.Add(register);
                _cartDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateRegister(int Id,Register register)
        {
            try
            {
                var data = GetRegisterId(Id);
                if (data != null)
                {
                    data.FirstName = register.FirstName;
                    data.LastName = register.LastName;
                    data.Email = register.Email;
                    data.PhoneNumber = register.PhoneNumber;
                    data.Address = register.Address;
                    data.City = register.City;
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
