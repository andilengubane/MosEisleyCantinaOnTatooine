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
            try
            {
                var result = _context.MenuItems.ToList();
                return result.ToList();
            }
            catch
            {
                throw new ApplicationException("Failed server error");
            }
        }

        public async Task<MenuItems> GetMenuItemById(int Id)
        {
            try
            {
                var result = _context.MenuItems.FirstOrDefault(x => x.Id == Id);
                if (result == null)
                {
                    throw new ApplicationException("Menu item not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed server error", ex);
            }
        }

        public async Task<MenuItems> AddMenuItem(MenuItems itemsDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(itemsDTO.Name) || string.IsNullOrEmpty(itemsDTO.Description))
                {
                    throw new ArgumentException("Name and Description are required.");
                }

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
            catch (ArgumentException ex)
            {
                throw new ApplicationException("Invalid input data", ex);
            }
        }

         public async Task<MenuItems> UpdateMenuItemById(int Id, MenuItems itemsDTO)
         {
             try
             {
                 var result = _context.MenuItems.FirstOrDefault(x => x.Id == Id);
                 if (result == null)
                 {
                     throw new ApplicationException("Menu item not found");
                 }

                 result.Name = itemsDTO.Name;
                 result.Description = itemsDTO.Description;
                 result.Price = itemsDTO.Price;
                 result.Image_Url = itemsDTO.Image_Url;

                 _context.Update(result);
                 await _context.SaveChangesAsync();
                 return result;
             }
             catch (Exception ex)
             {
                 throw new ApplicationException("Failed server error", ex);
             }
         }

        public async Task<MenuItems> DeleteMenuItemById(int Id)
        {
            try
            {
                var result =  _context.MenuItems.FirstOrDefault(x => x.Id == Id);
                if (result == null)
                {
                    throw new ApplicationException("Menu item not found");
                }

                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed server error", ex);
            }
        }
    }
}
