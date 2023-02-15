using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NameDogsAPI.Data;

namespace NameDogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private readonly IDogDB _DogDb;

        public DogsController(IDogDB dogDB)
        {
            _DogDb= dogDB;
        }


        [HttpGet]
        public async Task<ActionResult> GetDogs()
        {
            return Ok(await _DogDb.GetDogList());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDog(int id)
        {
            return Ok(await _DogDb.GetDog(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddNewDog(Dog dog)
        {
           await _DogDb.CreateDog(dog);
           _DogDb.Savechanges();
           return Created("Object Created", dog);
        }

        [HttpPut("{id}")]
        public ActionResult<Dog> UpdateDog(int id, Dog dog)
        {
            if(id != dog.ID)
            {
                return BadRequest();
            }
            _DogDb.UpdateDog(dog);
            _DogDb.Savechanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDog(int id) 
        {
            try
            {
                var returnedValue = await _DogDb.GetDog(id);
                _DogDb.DeleteDog(returnedValue);
                _DogDb.Savechanges();
                return Ok(await _DogDb.GetDogList());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }


        }

    }
}
