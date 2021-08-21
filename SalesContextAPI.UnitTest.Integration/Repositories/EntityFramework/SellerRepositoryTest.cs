using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using SalesContextAPI.Infraestructure.DBConfiguration.EFCore;
using SalesContextAPI.Infraestructure.Interfaces.Repositories.Domain;
using SalesContextAPI.UnitTest.Integration.Repositories.DataBuilder;
using SalesContextAPI.UnitTest.Integration.Repositories.DBConfiguration.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesContextAPI.Infraestructure.Interfaces;
using SalesContextAPI.Infraestructure.Repositories.Domain.EFCore;

namespace SalesContextAPI.UnitTest.Integration.Repositories.EntityFramework
{
    [TestFixture]
    public class SellerRepositoryTest
    {
        private ApplicationContext dbContext;
        private IDbContextTransaction transaction;

        private ISellerRepository userEntityFramework;
        private SellerBuilder builder;

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            dbContext = new EntityFrameworkConnection().DataBaseConfiguration();
        }

        [SetUp]
        public void Inicializa()
        {
            userEntityFramework = new SellerRepository(dbContext);
            builder = new SellerBuilder();
            transaction = dbContext.Database.BeginTransaction();
        }

        [TearDown]
        public void ExecutadoAposExecucaoDeCadaTeste()
        {
            transaction.Rollback();
        }

        [Test]
        public async Task AddAsync()
        {
            var result = await userEntityFramework.AddAsync(builder.CreateUser());
            Assert.Greater(result.Id, 0);
        }

        [Test]
        public async Task RemoveAsync()
        {
            var inserted = await userEntityFramework.AddAsync(builder.CreateUser());
            var result = await userEntityFramework.RemoveAsync(inserted.Id);
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task RemoveAsyncObj()
        {
            var inserted = await userEntityFramework.AddAsync(builder.CreateUser());
            var result = await userEntityFramework.RemoveAsync(inserted);
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task UpdateAsync()
        {
            var inserted = await userEntityFramework.AddAsync(builder.CreateUser());
            inserted.Name = "Update";
            var result = await userEntityFramework.UpdateAsync(inserted);
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task GetByIdAsync()
        {
            var user = await userEntityFramework.AddAsync(builder.CreateUser());
            var result = await userEntityFramework.GetByIdAsync(user.Id);
            Assert.AreEqual(result.Id, user.Id);
        }

        [Test]
        public async Task GetAllAsync()
        {
            var user1 = await userEntityFramework.AddAsync(builder.CreateUser());
            var user2 = await userEntityFramework.AddAsync(builder.CreateUser());
            var result = await userEntityFramework.GetAllAsync();
            Assert.AreEqual(result.OrderBy(u => u.Id).FirstOrDefault().Id, user1.Id);
            Assert.AreEqual(result.OrderBy(u => u.Id).LastOrDefault().Id, user2.Id);
        }
    }
}
