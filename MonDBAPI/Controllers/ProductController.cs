using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonDBAPI.Models;
using MonDBAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonDBAPI.Controllers
{
    [Route("api/[controller]/[action]/")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        /// <summary>
        /// 取得全部的Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Response<IEnumerable<Product>> GetAll()
        {
            return _productRepository.GetAll();
        }

        /// <summary>
        /// 取得Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Response<Product> GetProductById(string id)
        {
            var response = _productRepository.GetProductById(id);
            var s = response.Data.Id.ToString();
            return response;
        }

        public Response<IEnumerable<Product>> GetProductsByEmail(string email)
        {
            var response = _productRepository.FindAll(email);
            return response;
        }

        /// <summary>
        /// 建立Product
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<Product> Create([FromBody]Product p)
        {
            var response = _productRepository.AddProdcut(p);
            return response;
        }


        [HttpDelete("{id:length(24)}")]
        public Response<bool> Delete(string Id)
        {
            var response = _productRepository.DeleteProduct(Id);
            return response;
        }

        /// <summary>
        /// 更新Product
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<bool> Update([FromQuery]string Id, [FromBody] Product p)
        {
            var response = _productRepository.UpdateProduct(Id, p);
            return response;
        }
    }
}
