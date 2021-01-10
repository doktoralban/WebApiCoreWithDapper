using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCoreWithDapper.Data;

namespace WebApiCoreWithDapper.Controllers
{
    [Route("[controller]")]
    [ApiController] 
    
    public class ProductsController : ControllerBase
    {

        private readonly dbContextNW _context;
        private readonly SqlConnection connection;
        public ProductsController(dbContextNW context)
        {
            _context = context;

            connection = new SqlConnection(_context.Database.GetConnectionString());
        }


        //************************************* 
        [HttpGet]
        [Route("getAll")]
        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            string sql = "SELECT * FROM dbo.PRODUCTS";
            return await connection.QueryAsync<Products>(sql); 
            //return connection.Query<Products>(sql).ToList(); 
        }

        //*************************************
        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }






    }
}
