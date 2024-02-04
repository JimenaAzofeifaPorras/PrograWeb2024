using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        ISupplierService SupplierService;

        public SupplierController(ISupplierService supplierService)
        {
            SupplierService = supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierModel> Get()
        {
            return SupplierService.GetSuppliers();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public SupplierModel Get(int id)
        {
            return SupplierService.GetById(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public string Post([FromBody] SupplierModel supplier)
        {
            var result = SupplierService.AddSupplier(supplier);

            if (result)
            {
                return "Supplier Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<SupplierController>/5
        [HttpPut]
        public string Put([FromBody] SupplierModel supplier)
        {
            var result = SupplierService.UpdateSupplier(supplier);

            if (result)
            {
                return "Supplier Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            SupplierModel supplier = new SupplierModel { SupplierId = id };
            var result = SupplierService.DeteleSupplier(supplier);

            if (result)
            {
                return "Supplier Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}