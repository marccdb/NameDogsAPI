using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace NameDogsAPI.Data
{
    public class DogDB : IDogDB
    {

        readonly DogNameContext _context;

        public DogDB(DogNameContext context)
        {
            _context = context;
        }

        public async Task<Dog> CreateDog(Dog dog)
        {
           await _context.Dogs.AddAsync(dog);
           return dog;
        }

        public void DeleteDog(Dog dog)
        {
            _context.Dogs.Remove(dog);
        }

        public async Task<Dog> GetDog(int id)
        {
            try
            {
                return await _context.Dogs.FirstOrDefaultAsync<Dog>(x => x.ID == id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public async Task<IEnumerable<Dog>> GetDogList()
        {
            try
            {
                return await _context.Dogs.ToListAsync();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void UpdateDog(Dog dog)
        {
            _context.Entry(dog).State = EntityState.Modified;
        }


        public void Savechanges()
        {
            _context.SaveChangesAsync();
        }


    }
}
