using DataLibrary.Models;

namespace NameDogsAPI.Data

{
    public interface IDogDB
    {
        Task<Dog> CreateDog(Dog dog);
        void DeleteDog(Dog dog);
        void UpdateDog(Dog dog);
        Task<Dog> GetDog (int id);
        Task<IEnumerable<Dog>> GetDogList();

        void Savechanges();
    }
}
