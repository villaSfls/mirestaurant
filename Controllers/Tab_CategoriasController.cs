using System.Collections.Generic;
using System.Linq;
using Restaurant.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{ 
    [Route("api/v1/[controller]")]
    public class Tab_CategoriassController : Controller
    {
        private readonly RestaurantDbContext _context;

        public Tab_CategoriasController(RestaurantDbContext context)
        {
            _context = context; 
        }
    
        [HttpGet]
        public List<Tab_Categoria> Get(){
            return _context.Tab_Categoria.ToList();

        }
        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetTab_CategoriaById(int id){
        
        var Tab_Categoria= this._context.Tab_Categoria.SingleOrDefault(ct=> ct.Id_Tab_Categoria==id);
            if(Tab_Categoria != null){
                return Ok(Tab_Categoria);
            }else{
                return NotFound();
            }

        }

        //Search by Name 
        [HttpGet("{name}")]
        public IActionResult GetTab_CategoriaByName(string name){
        var info = this._context.Tab_Categoria.SingleOrDefault(ct => ct.Name == name);

            if(info == null){
                return new NoContentResult();
            }else {
                return Ok(info);
            }
        }
        //AddTab_Categoria
        [HttpPost]
        public IActionResult AddTab_Categoria([FromBody] Tab_Categoria Tab_Categoria){
        
        if(!this.ModelState.IsValid){
            return BadRequest();
        }
            this._context.Tab_Categoria.Add(Tab_Categoria);
            this._context.SaveChanges();
            return Created($"Tab_Categoria/{Tab_Categoria.Id_Tab_Categoria}", Tab_Categoria);
        }        
        //UpdateTab_Categoria
        [HttpPut("{id}")]
        public IActionResult PutTab_Categoria(int id, [FromBody] Tab_Categoria Tab_Categoria){

        var target = _context.Tab_Categoria.FirstOrDefault(ct=> ct.Id_Tab_Categoria == id);
            if(target == null)
            {
                return NotFound();
            }
            else
            {
                target.Id_Tab_Categoria = Tab_Categoria.Id_Tab_Categoria;
                target.Nom_Categoria = Tab_Categoria.Nom_Categoria;
                target.Last_Foto= Tab_Categoria.Foto;
               //
                _context.Tab_Categoria.Update(target);
                _context.SaveChanges();
                return new NoContentResult();
            }

        }
        //Delete Tab_Categoria
        [HttpDelete("{id}")]
        public IActionResult DeleteTab_Categoria(int id){
            var target = _context.Tab_Categoria.FirstOrDefault(ct=> ct.Id_Tab_Categoria == id);
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            else{
                _context.Tab_Categoria.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
