using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAjaxClient.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        /// <summary>
        /// Trang danh sách sản phẩm, view sẽ gọi AJAX đến ProductManagementAPI để load data
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Trang xem chi tiết sản phẩm, view sẽ gọi AJAX đến API để lấy chi tiết
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            ViewData["ProductId"] = id;
            return View();
        }

        /// <summary>
        /// Trang form tạo mới sản phẩm, view sẽ gửi AJAX POST đến API
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Trang form chỉnh sửa sản phẩm, view sẽ gọi AJAX GET để lấy dữ liệu và AJAX POST để cập nhật
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            ViewData["ProductId"] = id;
            return View();
        }

        /// <summary>
        /// Trang xác nhận xóa, view sẽ gửi AJAX DELETE đến API
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            ViewData["ProductId"] = id;
            return View();
        }
    }
}
