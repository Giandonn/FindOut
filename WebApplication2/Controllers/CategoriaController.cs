using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Dto;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("/api/v1.0/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] CategoriaDto categoriaDto)
        {
            if (ModelState.IsValid)
            {
                var categoria = categoriaDto.ToModel();
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return categoria;
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            var categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }

        [HttpPut("{id}")]
        public ActionResult<Categoria> Put(int id, [FromBody] CategoriaDto categoriaDto)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                ModelState.AddModelError("CategoriaId", "Id da categoria não encontrado!");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                categoria.Nome = categoriaDto.Nome;
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return categoria;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                ModelState.AddModelError("CategoriaId", "Id da categoria não encontrado!");
                return BadRequest(ModelState);
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok();
        }
    }
}
