using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Data.Entities;
using ToDoApi.Infrasturcture.Exceptions;
using ToDoApi.Resource.CategoriesResource;
using ToDoApi.Resources.CategoriesResource;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper,ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [Route("")]
        [HttpGet]

        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var category = await _categoryService.GetCategories();
                var categoryResource = _mapper.Map<IEnumerable<Categories>, IEnumerable<CategoriesResource>>(category);
                return Ok(categoryResource);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
            
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromBody] CreateCategoriesResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var category = new Categories()
                {
                    Name = resource.Name
                };
                await _categoryService.CreateCategory(category);
                return Ok(new { message = "Kateqoriya yaradıldı" });
            }
            catch (HttpException e)
            {

                return StatusCode(e.StatusCode, e.ResponseObj);
            }
            
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                var categoryResource = _mapper.Map<Categories, CategoriesResource>(category);

                return Ok(categoryResource);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id,[FromBody ]UpdateCategoryResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var categories = await _categoryService.GetCategoryById(id);
                categories.Name = resource.Name;
                await _categoryService.UpdateCategory(categories);

                return Ok(new { message="Kateoriya yeniləndi"});
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.RemoveCategory(id);
                return Ok(new { message = "Kateqoriya Silindi" });
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
            
        }
    }
}
