using Entities.Entities;
using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class OrderHelper : IOrderHelper
    {
        IServiceRepository _repository;

        public OrderHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public OrderViewModel AddOrder(OrderViewModel OrderViewModel)
        {
            OrderViewModel order = new OrderViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Order", OrderViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return new OrderViewModel { };
        }

        OrderViewModel Convertir(Order order)
        {
            return new OrderViewModel
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

        Order Convertir(OrderViewModel order)
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




        public void DeleteOrder(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Order/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }
        }

        public OrderViewModel EditOrder(OrderViewModel OrderViewModel)
        {
            OrderViewModel order = new OrderViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Order", OrderViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                //var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return OrderViewModel;
        }

        public List<OrderViewModel> GetAll()
        {
            List<OrderViewModel> lista = new List<OrderViewModel>();
            List<Order> result = new List<Order>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Order");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Order>>(content);
            }

            foreach (var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista;
        }

        public OrderViewModel GetById(int id)
        {
            OrderViewModel Order = new OrderViewModel();
            Order resultado = new Order();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Order/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Order>(content);
            }
            Order = Convertir(resultado);
            return Order;
        }
    }
}