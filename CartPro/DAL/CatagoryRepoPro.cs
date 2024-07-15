using CartPro.Models;

namespace CartPro.DAL
{
    public class CatagoryRepoPro
    {
        private readonly CartProDbContext _cartDBContext;

        public CatagoryRepoPro(CartProDbContext cartDBContext)
        {
            _cartDBContext = cartDBContext;
        }

        public List<Catagory> GetCatagories()
        {
            var catagories = _cartDBContext.Categories.ToList();
            return catagories;
        }

        public Catagory GetCatagoryId(int id)
        {
            var catagory = _cartDBContext.Categories.FirstOrDefault(c => c.Id == id);
            return catagory;
        }

        public bool AddCatagory(Catagory catagory)
        {
            try
            {
                _cartDBContext.Categories.Add(catagory);
                _cartDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCatagory(int Id, Catagory catagory)
        {
            try
            {
                var data = GetCatagoryId(Id);
                if (data != null)
                {
                    data.Name = catagory.Name;
                    data.Description = catagory.Description;
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

        public bool DeleteCatagory(int Id)
        {
            try
            {
                var data = GetCatagoryId(Id);
                if (data != null)
                {
                    _cartDBContext.Categories.Remove(data);
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
