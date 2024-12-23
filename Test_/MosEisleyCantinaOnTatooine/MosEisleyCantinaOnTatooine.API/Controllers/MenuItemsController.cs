﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MosEisleyCantinaOnTatooine.DTO;
using MosEisleyCantinaOnTatooine.Service.Interface;
using Microsoft.Extensions.Logging;

namespace MosEisleyCantinaOnTatooine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemsService _menuItemsService;
        private readonly ILogger _logger;
        public MenuItemsController(IMenuItemsService menuItemsService, ILogger logger)
        {
            _menuItemsService = menuItemsService ?? throw new ArgumentNullException(nameof(menuItemsService));
            _logger = logger;
        }

        [HttpGet]
        [Route("api/MenuItems/GetAllMenuItem")]
        public async Task<ActionResult> GetAllMenuItem()
        {
            try
            {
                var result = await _menuItemsService.GetAllMenuItem();
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Server Error",ex.Message);
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/MenuItems/GetMenuItemById")]
        public async Task<ActionResult> GetMenuItemById(int Id)
        {
            try
            {
                var result = await _menuItemsService.GetMenuItemById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Server Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/MenuItems/AddMenuItem")]
        public async Task<ActionResult> AddMenuItemById(MenuItems itemsDTO)
        {
            try
            {
                var result = await _menuItemsService.AddMenuItem(itemsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Server Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/MenuItems/UpdateMenuItemById")]
        public async Task<ActionResult> UpdateMenuItemById(int Id, MenuItems itemsDTO)
        {
            try
            {
                var result = await _menuItemsService.UpdateMenuItemById(Id, itemsDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Server Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/MenuItems/DeleteMenuItemById")]
        public async Task<ActionResult> DeleteMenuItemById(int id)
        {
            try
            {
                var result = await _menuItemsService.DeleteMenuItemById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Server Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
