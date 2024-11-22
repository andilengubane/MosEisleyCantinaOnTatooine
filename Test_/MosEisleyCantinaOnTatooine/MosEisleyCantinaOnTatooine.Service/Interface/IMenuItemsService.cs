using System.Threading.Tasks;
using System.Collections.Generic;
using MosEisleyCantinaOnTatooine.DTO;

namespace MosEisleyCantinaOnTatooine.Service.Interface
{
    public interface IMenuItemsService
    {
        Task<MenuItems> AddMenuItem(MenuItems itemsDTO);
        Task<MenuItems> DeleteMenuItemById(int Id);
        Task<IEnumerable<MenuItems>> GetAllMenuItem();
        Task<MenuItems> GetMenuItemById(int Id);
        Task<MenuItems> UpdateMenuItemById(int Id, MenuItems itemsDTO);
    }
}
