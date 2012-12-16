using Garagable.Data.CodeContracts;
using Garagable.Model;

namespace Garagable.Data.Repositories
{
    public class PhotoRepository : EFRepository<Photo, GaragableContext>, IPhotoRepository {
        public PhotoRepository(IDatabaseFactory<GaragableContext> databaseFactory) 
            : base(databaseFactory) {
            
        }
        
    }
}
