using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public ICategoryDAL _categoryDAL { get; }

        public ISupplierDAL _supplierDAL { get; }

        public IProductDAL _productDAL { get; }

        public IOrderDAL _orderDAL { get; }

        private readonly NorthWindContext _context;

        public UnidadDeTrabajo(NorthWindContext northWindContext,
                                ICategoryDAL categoryDAL
                                )
        {
            _context = northWindContext;
            _categoryDAL = categoryDAL;
        }

        public UnidadDeTrabajo(NorthWindContext northWindContext,
                                ISupplierDAL supplierDAL
                                )
        {
            _context = northWindContext;
            _supplierDAL = supplierDAL;
        }

        public UnidadDeTrabajo(NorthWindContext northWindContext,
                                IProductDAL productDAL
                                )
        {
            _context = northWindContext;
            _productDAL = productDAL;
        }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
