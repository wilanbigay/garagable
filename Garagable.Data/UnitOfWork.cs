using Garagable.Data.CodeContracts;

namespace Garagable.Data {

    public class UnitOfWork : IUnitOfWork {

        private readonly IDatabaseFactory<GaragableContext> _databaseFactory;
        private GaragableContext _dataContext;

        public UnitOfWork(IDatabaseFactory<GaragableContext> databaseFactory) {
            _databaseFactory = databaseFactory;
        }

        protected GaragableContext DataContext {

            get {
                return _dataContext ?? (_dataContext = _databaseFactory.Get());
            }


        }

        public void Commit() {
            DataContext.Commit();
        }

        public IItemRepository ItemRepository { get; set; }
        public IGarageSaleRepository GarageSaleRepository { get; set; }
        public IPhotoRepository PhotoRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IScheduleRepository ScheduleRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ISearchRepository SearchRepository { get; set; }
    }
}
