using System;
using System.Data.Entity;

namespace Garagable.Data {

    public interface IDatabaseFactory<T> where T : DbContext, IDisposable, new()  {
        T Get();
    }

    public class GaragableDatabaseFactory : IDatabaseFactory<GaragableContext>, IDisposable {

        private GaragableContext _dataContext;
        private readonly object _padLock = new object();

        public GaragableContext Get() {

            if (_dataContext == null) {
                lock (_padLock) {
                    _dataContext = new GaragableContext();
                }
            }
            return _dataContext;

        }



        public void Dispose() {
            if (_dataContext != null) {
                _dataContext.Dispose();
            }
        }

    }

}
