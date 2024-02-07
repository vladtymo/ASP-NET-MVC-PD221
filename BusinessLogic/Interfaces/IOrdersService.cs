using BusinessLogic.DTOs;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetAllByUser(string userId);
        void Create(string userId);
    }
}
