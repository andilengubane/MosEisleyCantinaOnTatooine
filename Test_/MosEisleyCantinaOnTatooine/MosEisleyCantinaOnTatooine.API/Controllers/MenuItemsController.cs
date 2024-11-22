using System;
using System.Linq;
using log4net.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MosEisleyCantinaOnTatooine.DTO;
using MosEisleyCantinaOnTatooine.Service.Interface;

namespace MosEisleyCantinaOnTatooine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemsService _menuItemsService;
        public MenuItemsController(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService ?? throw new ArgumentNullException(nameof(menuItemsService));
        }

        /// <summary>
        /// Return all menu items in a list
        /// </summary>
        [HttpGet]
        [Route("api/MenuItems/GetAllMenuItem")]
        public async Task<IEnumerable<MenuItems>> GetAllMenuItem()
        {
            try
            {
                var result = await _menuItemsService.GetAllMenuItem();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return (IEnumerable<MenuItems>)BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/MenuItems/GetMenuItemById")]
        public async Task<MenuItems> GetMenuItemById(int Id)
        {
            var result = await _menuItemsService.GetMenuItemById(Id);
            return (MenuItems)result;
        }

        [HttpPost]
        [Route("api/MenuItems/AddMenuItem")]
        public async Task<MenuItems> AddMenuItemById(MenuItems itemsDTO)
        {
            var result = await _menuItemsService.AddMenuItem(itemsDTO);
            return (MenuItems)result;
        }

        [HttpPut]
        [Route("api/MenuItems/UpdateMenuItemById")]
        public async Task<MenuItems> UpdateMenuItemById(int Id, MenuItems itemsDTO)
        {
            var result = await _menuItemsService.UpdateMenuItemById(Id, itemsDTO);
            return (MenuItems)result;
        }

        [HttpDelete]
        [Route("api/MenuItems/DeleteMenuItemById")]
        public async Task<MenuItems> DeleteMenuItemById(int id)
        {
            var result = await _menuItemsService.DeleteMenuItemById(id);
            return (MenuItems)result;
        }
    }
}
