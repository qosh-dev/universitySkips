using service.Main.Models;
using System.Threading.Tasks;

namespace service.Main
{
    public class Specialities
    {
        private Repository _main;
        public Specialities() => _main = new Repository();
        public async Task<Models.Speciality[]> Get(int Id)
        {
            Speciality[] specialities = await _main.Where<Models.Speciality>(e => e.DepartmentId == Id);
            return specialities;
        }
    }
}