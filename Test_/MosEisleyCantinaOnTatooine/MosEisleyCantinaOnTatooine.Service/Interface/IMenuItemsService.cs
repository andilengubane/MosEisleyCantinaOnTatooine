using System.Threading.Tasks;
using System.Collections.Generic;
using MosEisleyCantinaOnTatooine.DTO;

namespace MosEisleyCantinaOnTatooine.Service.Interface
{
    public interface IMenuItemsService
    {
        Task<MenuItemsDTO> AddMenuItem(MenuItemsDTO itemsDTO);
        Task<MenuItemsDTO> DeleteMenuItemById(int Id);
        Task<IEnumerable<MenuItemsDTO>> GetAllMenuItem();
        Task<MenuItemsDTO> GetMenuItemById(int Id);
        Task<MenuItemsDTO> UpdateMenuItemById(int Id, MenuItemsDTO itemsDTO);
    }
}
