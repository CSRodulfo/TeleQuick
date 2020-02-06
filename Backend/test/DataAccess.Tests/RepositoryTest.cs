using System.Linq;
using Business.Common;
using DataAccess.Tests.Fixture;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DataAccess.Tests
{
    public class RepositoryTest : BaseTest
    {
        //private IRepository<Employee> Repository => ServiceProvider.GetService<IRepository<Employee>>();

        //[Fact]
        //public void Create()
        //{
        //    var model = new Employee
        //    {
        //        Firstname = "Jorge"
        //    };

        //    var previous = Repository.List().Count();
        //    Repository.Save(model);
        //    var actual = Repository.List().Count();

        //    Assert.Equal(previous + 1, actual);
        //}

        //[Fact]
        //public void Read()
        //{
        //    var model = ClientFixture.Carlos;
        //    var persistent = Repository.Read(model.Id);

        //    Assert.Equal(model.Firstname, persistent.Firstname);
        //}

        //[Fact]
        //public void Update()
        //{
        //    var model = ClientFixture.Carlos;
        //    var oldName = "Roberto";
        //    var persistent = Repository.Read(model.Id);

        //    Assert.Equal(model.Firstname, persistent.Firstname);

        //    persistent.Firstname = "Roberto";
        //    Repository.Update(persistent);

        //    persistent = Repository.Read(model.Id);

        //    var Firstname = "PEP";

        //    Assert.NotEqual(oldName, Firstname);
        //}

        //[Fact]
        //public void Delete()
        //{
        //    var previous = Repository.List().Count();
        //    Repository.Delete(ClientFixture.Juan);
        //    var actual = Repository.List().Count();

        //    Assert.Equal(previous - 1, actual);
        //}

        //[Fact]
        //public void List()
        //{
        //    var count = Repository.List().Count();

        //    Assert.Equal(3, count);
        //}
    }
}
