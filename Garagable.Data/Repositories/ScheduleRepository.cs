using Garagable.Data.CodeContracts;
using Garagable.Model;

namespace Garagable.Data.Repositories {

    public class ScheduleRepository : EFRepository<Schedule, GaragableContext>, IScheduleRepository {

        public ScheduleRepository(IDatabaseFactory<GaragableContext> databaseFactory) 
            : base(databaseFactory) {
            
        }

    }
}
