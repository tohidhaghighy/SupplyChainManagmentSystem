using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Schm.EndUser.UI.Infrastructure.Model;

namespace Schm.EndUser.UI.Controllers
{
    public class BasketController : Controller
    {
        public async Task<List<Basket>> BasketList()
        {
            var BasketList=new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            return BasketList;
        }

        public async Task<JsonResult> AddToBasket(Basket basket)
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            if (BasketList.Where(a=>a.ItemId==basket.ItemId).Count()==0)
            {
                if (BasketList.Where(a=>a.SupplierId!=basket.SupplierId).Count()>1)
                {
                    return Json(new { status = 400, Message = "محصولات انتخابی باید مختص یک تامین کننده باشد", ProductId = basket.ItemId });
                }
                else
                {
                    BasketList.Add(basket);
                    HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(BasketList));
                    return Json(new { status = 200, Message = "با موفقیت ثبت شد", ProductId = basket.ItemId });
                }
            }
            else
            {
                return Json(new { status = 400 , message = "این محصول قبلا ثبت شده است", ProductId = basket.ItemId });
            }
        }

        public async Task<JsonResult> RemoveFromBasket(int ItemId)
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            var item= BasketList.Where(a=>a.ItemId==ItemId).FirstOrDefault();
            if (item != null)
                BasketList.Remove(item);
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(BasketList));
            return Json(new { status = 200, Message = "با موفقیت حذف شد", ProductId = ItemId });
        }

        public async Task<JsonResult> IncreaseBasket(int ItemId)
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            var item = BasketList.Where(a => a.ItemId == ItemId).FirstOrDefault();
            if (item != null)
                item.Count += 1;
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(BasketList));
            return Json(new { status = 200, Message = "با موفقیت افزوده شد", ProductId = ItemId });
        }

        public async Task<JsonResult> DecreaseBasket(int ItemId)
        {
            var BasketList = new List<Basket>();
            var basketlist = HttpContext.Session.GetString("Basket");
            if (basketlist != null)
                BasketList = JsonConvert.DeserializeObject<List<Basket>>(basketlist);
            var item = BasketList.Where(a => a.ItemId == ItemId).FirstOrDefault();
            if (item != null)
                item.Count -= 1;
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(BasketList));
            return Json(new { status = 200, Message = "با موفقیت افزوده شد", ProductId = ItemId });
        }
    }
}
