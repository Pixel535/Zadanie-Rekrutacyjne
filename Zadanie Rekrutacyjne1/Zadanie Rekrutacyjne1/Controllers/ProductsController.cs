using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Zadanie_Rekrutacyjne.Controllers.Repositories;
using Zadanie_Rekrutacyjne.Models;
using System.Xml.Linq;

namespace Zadanie_Rekrutacyjne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRep _productRep;

        public ProductsController(IProductRep productRep)
        {
            _productRep = productRep;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var acceptHeader = Request.Headers["Accept"].ToString();

            if (acceptHeader.Contains("application/xml"))
            {
                var products = _productRep.GetAll();

                var xmlData = new XDocument(
                    new XElement("ProductList",
                        products.Select(p =>
                            new XElement("Product",
                                new XElement("ID", p.ID),
                                new XElement("Name", p.Name),
                                new XElement("Price", p.Price)
                            )
                        )
                    )
                );

                return Content(xmlData.ToString(), "application/xml");
            }
            else
            {
                var products = _productRep.GetAll();
                return Ok(products);
            }
        }

        [HttpGet("{ID}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productRep.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (product == null)
            {
                return BadRequest();
            }
            _productRep.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
        }

        [HttpPut("{ID}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null || id != product.ID)
            {
                return BadRequest();
            }
            var existingProduct = _productRep.GetByID(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRep.Update(product);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public ActionResult Delete(int id)
        {
            var product = _productRep.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRep.Delete(id);
            return NoContent();
        }
    }
}
