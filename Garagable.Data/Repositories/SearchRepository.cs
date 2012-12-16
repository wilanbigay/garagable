using Garagable.Data.CodeContracts;
using Garagable.Model;

namespace Garagable.Data.Repositories {

    public class SearchRepository : EFRepository<SavedSearch, GaragableContext>, ISearchRepository {
        public SearchRepository(IDatabaseFactory<GaragableContext> databaseFactory) 
            :base(databaseFactory) {
            
        }
    }
}
