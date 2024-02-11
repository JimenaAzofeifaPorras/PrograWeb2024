using BackEnd.Models;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetOrders();
        Task<bool> Add(OrderModel order);
        Task<bool> Update(OrderModel order);
        Task<bool> Delete(int id);
        Task<OrderModel> GetById(int id);

    }
}