using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{ 
    [Route("api/v1/[controller]")]
    public class Tab_UnidadesController : Controller
    {
        private readonly RestaurantDbContext _context;

        public Tab_UnidadesController(RestaurantDbContext context)
        {
            _context = context; 
        }
    
        [HttpGet]
        public List<Tab_Unidad> Get(){
            return _context.Tab_Unidades.ToList();

        }
        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetTab_UnidadById(int id){
        
        var Tab_Unidad= this._context.Tab_Unidad.SingleOrDefault(ct=> ct.Id_Tab_Unidad ==id);
            if(Tab_Unidad != null){
                return Ok(Tab_Unidad);
            }else{
                return NotFound();
            }

        }

        //Buscar por Nombre
        [HttpGet("{name}")]
        public IActionResult GetTab_UnidadByName(string name){
        var info = this._context.Tab_Unidad.SingleOrDefault(ct => ct.Name == Nom_Unidad);

            if(info == null){
                return new NoContentResult();
            }else {
                return Ok(info);
            }
        }
        // Add Tab_Unidad
        [HttpPost]
        public IActionResult AddTab_Unidades([FromBody] Tab_Unidad Tab_Unidad){
        
        if(!this.ModelState.IsValid){
            return BadRequest();
        }
            this._context.Tab_Unidad.Add(Tab_Unidad);
            this._context.SaveChanges();
            return Created($"Tab_Unidad/{Tab_Unidad.Id_Tab_Unidad}", Tab_Unidad);
        }        
        //Update Tab_Unidad
        [HttpPut("{id}")]
        public IActionResult PutTab_Unidad(int id, [FromBody] Tab_Unidad Tab_Unidad){

        var target = _context.Tab_Unidad.FirstOrDefault(ct=> ct.Id_Tab_Unidad == id);
            if(target == null)
            {
                return NotFound();
            }
            else
            {
                target.Id_Tab_Unidad = Tab_Unidad.Id_Tab_Unidad;
                target.Des = Tab_Unidad.Des_Unidad;
                target.Abrev = Tab_Unidad.Abrev_Unidad;
                
                _context.Tab_Unidad.Update(target);
                _context.SaveChanges();
                return new NoContentResult();
            }

        }
        //Delete Tab_Unidad
        [HttpDelete("{id}")]
        public IActionResult DeleteTab_Unidad(int id){
            var target = _context.Tab_Unidad.FirstOrDefault(ct=> ct.Id_Tab_Unidad == id);
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            else{
                _context.Tab_Unidad.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
