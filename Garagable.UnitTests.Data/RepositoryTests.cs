using System.Linq;
using Garagable.Data;
using Garagable.Data.CodeContracts;
using Garagable.Data.Repositories;
using Garagable.Model;
using Garagable.UnitTests.Helpers;
using NUnit.Framework;

namespace Garagable.UnitTests.Data {

    [TestFixture]
    public class RepositoryTests {

        private IDatabaseFactory<GaragableContext> _databaseFactory;
        private IUserRepository _userRepo;
        private RandomStringGenerator _randomString;
        private IUnitOfWork _unitOfWork;

        public RepositoryTests() {
            _randomString = new RandomStringGenerator();
        }

        [SetUp]
        public void Init() {
            _databaseFactory = new GaragableDatabaseFactory();
            _userRepo = new UserRepository(_databaseFactory);
            _randomString = new RandomStringGenerator();
            _unitOfWork = new UnitOfWork(_databaseFactory);
        }

        [Test]
        public void Can_Retrieve_An_Entity_From_Database() {

            var users = _userRepo.GetAll();


            //Assert:
            users.Count().Should(Be.GreaterThanOrEqualTo(1));

        }

        [Test]
        public void Can_Add_A_Record_To_The_Database() {
            //Arrange:
            var newUser = new User() {UserName = _randomString.NextString(10), HashedPassword = _randomString.NextString(10), Email= _randomString.NextString(20)};
            
            //Act:
            _userRepo.Add(newUser);
            _unitOfWork.Commit();

            //Assert:
            newUser.Id.Should(Be.GreaterThanOrEqualTo(1));

        }

    }
}
