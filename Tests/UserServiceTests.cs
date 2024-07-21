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
    public class UserServiceTests : IDisposable
    {
        private readonly StoreDbContext dbContext;
        private readonly UserService userService;
        private readonly IUserRepository userRepositoryMock;

        public UserServiceTests()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            dbContext = new StoreDbContext(options, new TestDataFactory());
            userRepositoryMock = Substitute.For<IUserRepository>();

            userService = new UserService(dbContext);

            // Manually inject the mocked repository into the userService
            var field = typeof(UserService).GetField("userRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(userService, userRepositoryMock);
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Fact]
        public void GetUserByLogin_ShouldReturnUserModel_WhenUserExists()
        {
            // Arrange
            var login = "testuser";
            var user = new User
            {
                Id = 1,
                Name = "Test",
                LastName = "User",
                Login = login,
                Password = "password",
                RoleId = 2
            };

            userRepositoryMock.GetUserByLogin(login).Returns(user);

            // Act
            var result = userService.GetUserByLogin(login);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.LastName, result.LastName);
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.Password, result.Password);
            Assert.Equal(user.RoleId, result.RoleId);
        }

        [Fact]
        public void GetUserByLogin_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var login = "nonexistentuser";
            userRepositoryMock.GetUserByLogin(login).Returns((User)null);

            // Act
            var result = userService.GetUserByLogin(login);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void LoginUser_ShouldReturnUserModel_WhenCredentialsAreCorrect()
        {
            // Arrange
            var login = "testuser";
            var password = "password";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User
            {
                Id = 1,
                Name = "Test",
                LastName = "User",
                Login = login,
                Password = hashedPassword,
                RoleId = 2
            };

            userRepositoryMock.GetUserByLogin(login).Returns(user);

            // Act
            var result = userService.LoginUser(login, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.LastName, result.LastName);
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.Password, result.Password);
            Assert.Equal(user.RoleId, result.RoleId);
        }

        [Fact]
        public void LoginUser_ShouldReturnNull_WhenPasswordIsIncorrect()
        {
            // Arrange
            var login = "testuser";
            var password = "wrongpassword";
            var user = new User
            {
                Id = 1,
                Name = "Test",
                LastName = "User",
                Login = login,
                Password = BCrypt.Net.BCrypt.HashPassword("password"),
                RoleId = 2
            };

            userRepositoryMock.GetUserByLogin(login).Returns(user);

            // Act
            var result = userService.LoginUser(login, password);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_ShouldAddUserToRepository()
        {
            // Arrange
            var userModel = new UserModel(0, "Test", "User", "testuser", "password", 2);

            // Act
            userService.Add(userModel);

            // Assert
            userRepositoryMock.Received(1).Add(Arg.Is<User>(u =>
                u.Name == userModel.Name &&
                u.LastName == userModel.LastName &&
                u.Login == userModel.Login &&
                u.RoleId == userModel.RoleId
            ));
        }

        [Fact]
        public void Delete_ShouldRemoveUserFromRepository()
        {
            // Arrange
            var userId = 1;

            // Act
            userService.Delete(userId);

            // Assert
            userRepositoryMock.Received(1).DeleteById(userId);
        }

        [Fact]
        public void GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "Test1", LastName = "User1", Login = "testuser1", Password = "password1", RoleId = 2 },
                new User { Id = 2, Name = "Test2", LastName = "User2", Login = "testuser2", Password = "password2", RoleId = 2 }
            };
            userRepositoryMock.GetAll().Returns(users);

            // Act
            var result = userService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(users.Count, result.Count());
        }

        [Fact]
        public void GetById_ShouldReturnUserModel_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, Name = "Test", LastName = "User", Login = "testuser", Password = "password", RoleId = 2 };
            userRepositoryMock.GetById(userId).Returns(user);

            // Act
            var result = (UserModel)userService.GetById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.LastName, result.LastName);
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.RoleId, result.RoleId);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            userRepositoryMock.GetById(userId).Returns((User)null);

            // Act
            var result = userService.GetById(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_ShouldUpdateUserInRepository()
        {
            // Arrange
            var userModel = new UserModel(1, "Updated", "User", "updateduser", "newpassword", 2);
            var user = new User { Id = userModel.Id, Name = "Test", LastName = "User", Login = "testuser", Password = "password", RoleId = 2 };

            userRepositoryMock.GetById(userModel.Id).Returns(user);

            // Act
            userService.Update(userModel);

            // Assert
            userRepositoryMock.Received(1).Update(Arg.Is<User>(u =>
                u.Id == userModel.Id &&
                u.Name == userModel.Name &&
                u.LastName == userModel.LastName &&
                u.Login == userModel.Login &&
                u.RoleId == userModel.RoleId
            ));
        }

        [Fact]
        public void Count_ShouldReturnNumberOfUsers()
        {
            // Arrange
            var count = 5;
            userRepositoryMock.Count().Returns(count);

            // Act
            var result = userService.Count();

            // Assert
            Assert.Equal(count, result);
        }
    }
}
