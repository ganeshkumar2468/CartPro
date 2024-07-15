using CartPro.DAL;
using CartPro.Models;

namespace CartPro.BusinessAcessLayer
{
    public class CatagoryBAL
    {
        private readonly CartProDbContext _cartDBContext;
        public CatagoryBAL(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }

        public bool AddCatagory(CatagoryVM catagoryVM)
        {
            Catagory catagory = new Catagory();
            catagory.Name = catagoryVM.Name;
            catagory.Description = catagoryVM.Description;
            CatagoryRepoPro catagoryRepo = new CatagoryRepoPro(_cartDBContext);
            if (catagoryRepo.AddCatagory(catagory))
            {
                return true;
            }
            return false;
        }

        public bool EditCatagory(int Id, CatagoryVM catagoryVM)
        {
            CatagoryRepoPro catagoryRepo = new CatagoryRepoPro(_cartDBContext);
            Catagory catagory = new Catagory();
            catagory.Name = catagoryVM.Name;
            catagory.Description = catagoryVM.Description;
            catagoryRepo.UpdateCatagory(Id, catagory);
            return true;
        }
        public bool DeleteCatagory(int Id)
        {
            CatagoryRepoPro catagoryRepo = new CatagoryRepoPro(_cartDBContext);
            catagoryRepo.DeleteCatagory(Id);
            return true;
        }
    }
}
