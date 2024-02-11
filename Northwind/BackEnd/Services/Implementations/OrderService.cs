using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class OrderService : IOrderService
    {

        IUnidadDeTrabajo Unidad;
        public OrderService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            Unidad = unidadDeTrabajo;
        }




        public Task<bool> Add(OrderModel order)
        {
            Unidad._orderDAL.Add(Convertir(order));
            var result = Unidad.Complete();

            return Task.FromResult(result);
        }

        OrderModel Convertir(Order order)
        {
            return new OrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
        }

        Order Convertir(OrderModel order)
        {
            return new Order
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
        }

        public Task<bool> Delete(int id)
        {
            Order order = new Order { OrderId = id };

            Unidad._orderDAL.Remove(order);
            var result = Unidad.Complete();

            return Task.FromResult(result);
        }

        public Task<OrderModel> GetById(int id)
        {
            Order order = Unidad._orderDAL.Get(id);
            return Task.FromResult(Convertir(order));
        }

        public Task<List<OrderModel>> GetOrders()
        {

            var Orders = Unidad._orderDAL.GetAll();
            List<OrderModel> lista = new List<OrderModel>();
            foreach (var order in Orders)
            {
                lista.Add(Convertir(order));
            }
            return Task.FromResult(lista);
        }

        public Task<bool> Update(OrderModel order)
        {
            Unidad._orderDAL.Update(Convertir(order));
            var result = Unidad.Complete();

            return Task.FromResult(result);
        }

    }
}