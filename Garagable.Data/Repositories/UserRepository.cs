using Garagable.Data.CodeContracts;
using Garagable.Model;

namespace Garagable.Data.Repositories {

    public class UserRepository : EFRepository<User, GaragableContext>, IUserRepository {

        public UserRepository(IDatabaseFactory<GaragableContext> databaseFactory) 
            : base(databaseFactory) {
            
        }

    }
}
