using System.Collections.Generic;
using Garagable.Model;

namespace Garagable.Service.Contract {
    public interface ISaveSearchesService {
        IEnumerable<SavedSearch> GetAllSearchesByUser(int userId);
        IEnumerable<SavedSearch> GetAllSearchesByUser(User user);
        SavedSearch GetSearchById(int id);
        SavedSearch GetSearchByName(string searchName);

        void AddSearchesToUser(IEnumerable<SavedSearch> searches, int userId);
        void AddSearchesToUser(IEnumerable<SavedSearch> searches, User user);
    }
}