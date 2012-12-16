using Garagable.Data.CodeContracts;
using Garagable.Model;

namespace Garagable.Data.Repositories {

    public class RoleRepository : EFRepository<Role, GaragableContext>, IRoleRepository {
        public RoleRepository(IDatabaseFactory<GaragableContext> databaseFactory)
            : base(databaseFactory) {

        }
    }
}
