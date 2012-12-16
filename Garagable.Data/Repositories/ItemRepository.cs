using Garagable.Data.CodeContracts;
using Garagable.Model;

namespace Garagable.Data.Repositories {


    public class ItemRepository : EFRepository<Item, GaragableContext>, IItemRepository {
        public ItemRepository(IDatabaseFactory<GaragableContext> databaseFactory) 
            : base(databaseFactory) {
        }
    }
}
