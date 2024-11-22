using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MosEisleyCantinaOnTatooine.DTO;
using MosEisleyCantinaOnTatooine.Persistence;
using MosEisleyCantinaOnTatooine.Service.Interface;

namespace MosEisleyCantinaOnTatooine.Service
{

    public class MenuItemsService : IMenuItemsService
    {
        private readonly MosEisleyCantinaOnTatooineDbContext _context = new MosEisleyCantinaOnTatooineDbContext();
        public MenuItemsService(MosEisleyCantinaOnTatooineDbContext mosEisleyCantinaOnTatooineDb)
        {
            _context = mosEisleyCantinaOnTatooineDb;
        }

        public async Task<IEnumerable<MenuItemsDTO>> GetAllMenuItem()
        {
            var result =  _context.MenuItems.ToList();
            return  result.ToList();
        }

        public async Task<MenuItemsDTO> GetMenuItemById(int Id)
        {
            var result = _context.MenuItems.Where(x => x.Id == Id).FirstOrDefault();
            return result;
        }

        public async Task<MenuItemsDTO> AddMenuItem(MenuItemsDTO itemsDTO)
        {
            try
            {
                var data = new MenuItemsDTO()
                {
                    ItemName = itemsDTO.ItemName,
                    Description = itemsDTO.Description,
                    Price = itemsDTO.Price,
                    Image_Url = itemsDTO.Image_Url
                };
                _context.Add(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<MenuItemsDTO> UpdateMenuItemById(int Id, MenuItemsDTO itemsDTO)
        {
            var result = _context.MenuItems.Where(x => x.Id == itemsDTO.Id).FirstOrDefault();
            try
            {
                result.ItemName = itemsDTO.ItemName;
                result.Description = itemsDTO.Description;
                result.Price = itemsDTO.Price;
                result.Image_Url = itemsDTO.Image_Url;

                _context.Add(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<MenuItemsDTO> DeleteMenuItemById(int Id)
        {
            try
            {
                var result = _context.MenuItems.Where(x => x.Id == Id).FirstOrDefault();
                _context.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
