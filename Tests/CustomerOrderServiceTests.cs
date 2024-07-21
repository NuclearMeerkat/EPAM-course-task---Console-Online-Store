using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;
using StoreDAL.Data.InitDataFactory;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using Xunit;

namespace StoreBLL.Tests
{
    public class CustomerOrderServiceTests : IDisposable
    {
        private readonly StoreDbContext dbContext;
        private readonly CustomerOrderService customerOrderService;
        private readonly ICustomerOrderRepository customerOrderRepositoryMock;

        public CustomerOrderServiceTests()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            dbContext = new StoreDbContext(options, new TestDataFactory());
            customerOrderRepositoryMock = Substitute.For<ICustomerOrderRepository>();

            customerOrderService = new CustomerOrderService(dbContext);

            // Manually inject the mocked repository into the customerOrderService
            var field = typeof(CustomerOrderService).GetField("customerOrderRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(customerOrderService, customerOrderRepositoryMock);
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Fact]
        public void Delete_ShouldRemoveCustomerOrderFromRepository()
        {
            // Arrange
            var customerOrderId = 1;

            // Act
            customerOrderService.Delete(customerOrderId);

            // Assert
            customerOrderRepositoryMock.Received(1).DeleteById(customerOrderId);
        }

        [Fact]
        public void GetById_ShouldReturnCustomerOrderModel_WhenOrderExists()
        {
            // Arrange
            var customerOrderId = 1;
            var customerOrder = new CustomerOrder { Id = customerOrderId, OperationTime = "2023-07-21", OrderStateId = 1, UserId = 1 };
            customerOrderRepositoryMock.GetById(customerOrderId).Returns(customerOrder);

            // Act
            var result = (CustomerOrderModel)customerOrderService.GetById(customerOrderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerOrder.Id, result.Id);
            Assert.Equal(customerOrder.OperationTime, result.OperationTime);
            Assert.Equal(customerOrder.OrderStateId, result.OrderStateId);
            Assert.Equal(customerOrder.UserId, result.UserId);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenOrderDoesNotExist()
        {
            // Arrange
            var customerOrderId = 1;
            customerOrderRepositoryMock.GetById(customerOrderId).Returns((CustomerOrder)null);

            // Act
            var result = customerOrderService.GetById(customerOrderId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_ShouldUpdateCustomerOrderInRepository()
        {
            // Arrange
            var customerOrderModel = new CustomerOrderModel(1, "2023-07-21", 1, 1);
            var customerOrder = new CustomerOrder { Id = customerOrderModel.Id, OperationTime = "2023-07-20", OrderStateId = 1, UserId = 1 };

            customerOrderRepositoryMock.GetById(customerOrderModel.Id).Returns(customerOrder);

            // Act
            customerOrderService.Update(customerOrderModel);

            // Assert
            customerOrderRepositoryMock.Received(1).Update(Arg.Is<CustomerOrder>(co =>
                co.Id == customerOrderModel.Id &&
                co.OperationTime == customerOrderModel.OperationTime &&
                co.OrderStateId == customerOrderModel.OrderStateId &&
                co.UserId == customerOrderModel.UserId
            ));
        }

        [Fact]
        public void Count_ShouldReturnNumberOfCustomerOrders()
        {
            // Arrange
            var count = 5;
            customerOrderRepositoryMock.Count().Returns(count);

            // Act
            var result = customerOrderService.Count();

            // Assert
            Assert.Equal(count, result);
        }
    }
}
