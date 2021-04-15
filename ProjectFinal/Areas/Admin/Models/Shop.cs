using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Areas.Admin.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string ShopAdress { get; set; }
        public List<ShopContent> ShopContents { get; set; }
       
        public List<ShopContent> GetCurrentShopContent(int id)
        {
            try
            {
                return this.ShopContents.Where(x => x.ShopId == id).ToList();

            }
            catch (Exception)
            {

                ShopContent shopContent = new ShopContent();
                List<ShopContent> shopContents = new List<ShopContent>();
                return shopContents;
                
            }

        }
        public void Test()
        {

        }
    }
}
