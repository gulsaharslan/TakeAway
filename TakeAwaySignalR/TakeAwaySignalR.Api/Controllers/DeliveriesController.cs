using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwaySignalR.Api.DAL;

namespace TakeAwaySignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly Context _context;

        public DeliveriesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllDelivery()
        {
            var values = _context.Deliveries.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
            return Ok("Kaydedildi");
        }

        [HttpPut]

        public IActionResult UpdateDelivery(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            _context.SaveChanges();
            return Ok("Güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteDelivery(int id)
        {
            var value = _context.Deliveries.Find(id);
            _context.Deliveries.Remove(value);
            _context.SaveChanges();
            return Ok("Silindi");
        }

        [HttpGet("GetDeliveryByStatusIsYolda")]
        public IActionResult GetDeliveryByStatusIsYolda()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Yolda").Count();
            return Ok(value);
        }
        [HttpGet("GetDeliveryByStatusSiparisAlindi")]
        public IActionResult GetDeliveryByStatusSiparisAlindi()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Sipariş Alındı").Count();
            return Ok(value);
        }

        [HttpGet("GetDeliveryByStatusHazırlaniyor")]
        public IActionResult GetDeliveryByStatusHazırlaniyor()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Hazırlanıyor").Count();
            return Ok(value);
        }

        [HttpGet("GetDeliveryByStatusTeslimEdildi")]
        public IActionResult GetDeliveryByStatusTeslimEdildi()
        {
            int value = _context.Deliveries.Where(x => x.Status == "Teslim Edildi").Count();
            return Ok(value);
        }

        [HttpGet("GetDeliveryTotalPrice")]
        public IActionResult GetDeliveryTotalPrice()
        {
            decimal value = _context.Deliveries.Sum(x => x.Total);
            return Ok(value);
        }

        [HttpGet("GetTotalDelivery")]
        public IActionResult GetTotalDelivery()
        {
            int value = _context.Deliveries.Count();
            return Ok(value);
        }
    }
}
