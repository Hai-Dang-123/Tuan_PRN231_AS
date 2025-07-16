using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObjects.Entities;

namespace IdentityAjaxClient.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Trả về view danh sách sản phẩm (bạn tự làm)
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View("~/Views/Home/CreateProduct.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var client = _httpClientFactory.CreateClient();

            // Chuẩn bị dữ liệu JSON gửi đến API
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Gọi API để tạo product
            var response = await client.PostAsync("https://localhost:5001/api/products", content);

            if (response.IsSuccessStatusCode)
            {
                // Nếu tạo thành công, redirect về Index
                return RedirectToAction("Index", "Home");

            }
            else
            {
                // Nếu lỗi thì hiện lại form với thông báo lỗi
                ModelState.AddModelError(string.Empty, "Không tạo được sản phẩm, vui lòng thử lại.");
                return View(product);
            }
        }
    }
}
