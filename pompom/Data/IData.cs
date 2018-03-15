using System.Collections.Generic;
using System.Threading.Tasks;
using pompom.Models;

namespace pompom.Data
{
    public interface IData
    {
        Task<IList<Profile>> GetWeeksPeopleAsync();
        Task<IList<Message>> GetThisWeeksList();
        Task<Profile> GetProfileByIdAsync(int id);
        Task<IList<DetailProfile>> GetDetailProfile();
        Task<DetailProfile> GetUserProfile();
    }
}
