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
        
        var Tab_Unidad= this._context.Tab_Unidades.SingleOrDefault(ct=> ct.Id_Tab_Unidad ==id);
            if(Tab_Unidad != null){
                return Ok(Tab_Unidad);
            }else{
                return NotFound();
            }

        }

        //Search by Name 
        [HttpGet("{name}")]
        public IActionResult GetTab_UnidadByName(string name){
        var info = this._context.Tab_Unidades.SingleOrDefault(ct => ct.Name == name);

            if(info == null){
                return new NoContentResult();
            }else {
                return Ok(info);
            }
        }
        //AddTab_Unidades
        [HttpPost]
        public IActionResult AddTab_Unidades([FromBody] Tab_Unidad Tab_Unidad){
        
        if(!this.ModelState.IsValid){
            return BadRequest();
        }
            this._context.Tab_Unidades.Add(Tab_Unidad);
            this._context.SaveChanges();
            return Created($"Tab_Unidades/{Tab_Unidad.Id_Tab_Unidad}", Tab_Unidad);
        }        
        //UpdateTab_Unidades
        [HttpPut("{id}")]
        public IActionResult PutTab_Unidades(int id, [FromBody] Tab_Unidad Tab_Unidad){

        var target = _context.Tab_Unidades.FirstOrDefault(ct=> ct.Id_Tab_Unidad == id);
            if(target == null)
            {
                return NotFound();
            }
            else
            {
                target.Id_Tab_Unidad = Tab_Unidad.Id_Tab_Unidad;
                target.Name = Tab_Unidad.Name;
                target.Last_Name = Tab_Unidad.Last_Name;
                target.Email = Tab_Unidad.Email;

                _context.Tab_Unidades.Update(target);
                _context.SaveChanges();
                return new NoContentResult();
            }

        }
        //Delete Tab_Unidades
        [HttpDelete("{id}")]
        public IActionResult DeleteTab_Unidades(int id){
            var target = _context.Tab_Unidades.FirstOrDefault(ct=> ct.Id_Tab_Unidad == id);
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            else{
                _context.Tab_Unidades.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
