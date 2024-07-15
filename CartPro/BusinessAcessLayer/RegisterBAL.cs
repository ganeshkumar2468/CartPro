using CartPro.DAL;
using CartPro.Models;

namespace CartPro.BusinessAcessLayer
{
    public class RegisterBAL
    {
        private readonly CartProDbContext _cartDBContext;
        public RegisterBAL(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }
        public bool AddRegister(RegisterVM RegisterVM)
        {
            Register register = new Register();
            register.FirstName = RegisterVM.FirstName;
            register.LastName = RegisterVM.LastName;
            register.Email = RegisterVM.Email;
            register.PhoneNumber = RegisterVM.PhoneNumber;
            register.Address = RegisterVM.Address;
            register.City = RegisterVM.City;
            RegisterRepoPro registerRepo = new RegisterRepoPro(_cartDBContext);
            if (registerRepo.AddRegister(register))
            {
                return true;
            }
            return false;
        }
        public bool EditRegister(int Id, RegisterVM RegisterVM)
        {
            RegisterRepoPro registerRepo = new RegisterRepoPro(_cartDBContext);
            Register register = new Register();
            register.FirstName = RegisterVM.FirstName;
            register.LastName = RegisterVM.LastName;
            register.Email = RegisterVM.Email;
            register.PhoneNumber = RegisterVM.PhoneNumber;
            register.Address = RegisterVM.Address;
            register.City = RegisterVM.City;
            registerRepo.UpdateRegister(Id, register);
            return true;
        }
    }
}
