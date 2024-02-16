using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IOrderHelper
    {
        List<OrderViewModel> GetAll();
        OrderViewModel GetById(int id);
        OrderViewModel AddOrder(OrderViewModel OrderViewModel);
        OrderViewModel EditOrder(OrderViewModel OrderViewModel);

        void DeleteOrder(int id);
    }
}
