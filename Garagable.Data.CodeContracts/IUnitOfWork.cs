namespace Garagable.Data.CodeContracts {

    public interface IUnitOfWork {
        void Commit();

        IItemRepository ItemRepository { get; set; }
        IGarageSaleRepository GarageSaleRepository { get; set; }
        IPhotoRepository PhotoRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IScheduleRepository ScheduleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        ISearchRepository SearchRepository { get; set; }
    }
}
