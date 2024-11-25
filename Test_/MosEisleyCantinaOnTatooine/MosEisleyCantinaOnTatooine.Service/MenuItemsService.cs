﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MosEisleyCantinaOnTatooine.DTO;
using MosEisleyCantinaOnTatooine.Service.Interface;
using MosEisleyCantinaOnTatooine.Persistence;

namespace MosEisleyCantinaOnTatooine.Service
{

    public class MenuItemsService : IMenuItemsService
    {
        private readonly DbContextMenuItems _context;
        public MenuItemsService(DbContextMenuItems mosEisleyCantinaOnTatooineDb)
        {
            _context = mosEisleyCantinaOnTatooineDb;
        }

        public async Task<IEnumerable<MenuItems>> GetAllMenuItem()
        {
            var result =  _context.MenuItems.ToList();
            return  result.ToList();
        }

        public async Task<MenuItems> GetMenuItemById(int Id)
        {
            var result = _context.MenuItems.Where(x => x.Id == Id).FirstOrDefault();
            return result;
        }

        public async Task<MenuItems> AddMenuItem(MenuItems itemsDTO)
        {
            var data = new MenuItems()
            {
                Name = itemsDTO.Name,
                Description = itemsDTO.Description,
                Price = itemsDTO.Price,
                Image_Url = itemsDTO.Image_Url,
                CreatedDate = DateTime.Now
            };

            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<MenuItems> UpdateMenuItemById(int Id, MenuItems itemsDTO)
        {
            var result = _context.MenuItems.Where(x => x.Id == itemsDTO.Id).FirstOrDefault();
            result.Name = itemsDTO.Name;
            result.Description = itemsDTO.Description;
            result.Price = itemsDTO.Price;
            result.Image_Url = itemsDTO.Image_Url;

            _context.Add(result);
            _context.SaveChanges();
            return result;
        }

        public async Task<MenuItems> DeleteMenuItemById(int Id)
        {
            var result = _context.MenuItems.Where(x => x.Id == Id).FirstOrDefault();
            _context.Remove(result);
            _context.SaveChanges();
            return result;
        }
    }
}
