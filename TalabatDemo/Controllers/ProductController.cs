using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatDemo.Models;
namespace TalabatDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase //  BaseUrl/api/Product
    {

        [HttpGet]//GET:  BaseUrl/api/Product  //  لو عندي لازم اميزهم GET  مينفعش يبقى عندي كتر من واحده 
        // query هنا جاي من ال 

        public ActionResult<Product> GETALL()
        {
            return new Product()
            {
                Id = 20
            };
        }

        [HttpGet("{id}")] //GET:  BaseUrl/api/Product/id // routing  هو ال  id  هنا بعدل على المسار الاساسي خليت ال      
        // path  جاي من ال  required  هنا بقى و
        // ApiController و اللي بيعرف ده هو ال
        public ActionResult<Product> GET(int id)
        {
            return new Product()
            {
                Id = id
            };
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            return new Product();
        }
        [HttpPost("brand")]//لو مثلاً هعمل Add لـ Brand على أساس الproduct بس ما عنديش  BrandController
        //  فهحط segmant
        public ActionResult<Product> AddBrand(Product product)
        {
            return new Product();
        }
        [HttpPut] 
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return new Product();
        }
        [HttpDelete]
        public ActionResult<Product> DeleteProduct(Product product)
        {
            return new Product();
        }

    }
}
