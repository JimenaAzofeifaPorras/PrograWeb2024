﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        ICategoryDAL _categoryDAL { get; }
        ISupplierDAL _supplierDAL { get; }
        IProductDAL _productDAL { get; }
        IOrderDAL _orderDAL { get; } 
        bool Complete();

    }
}
