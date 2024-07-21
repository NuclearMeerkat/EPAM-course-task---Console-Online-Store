using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Data.InitDataFactory;
using StoreDAL.Entities;
using StoreDAL.Repository;
using Xunit;

public class GenericRepositoryTests
{
    private readonly StoreDbContext _context;
    private readonly GenericRepository<Category> _repository;

    public GenericRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<StoreDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new StoreDbContext(options, new TestDataFactory());
        _repository = new CategoryRepository(_context);
    }

    [Fact]
    public void Add_ShouldAddEntity()
    {
        var entity = new Category { Id = 0, Name = "Test" };

        _repository.Add(entity);

        var addedEntity = _context.Set<Category>().Find(entity.Id);
        Assert.NotNull(addedEntity);
        Assert.Equal(entity.Name, addedEntity.Name);
    }

    [Fact]
    public void Delete_ShouldRemoveEntity()
    {
        var entity = new Category { Id = 20, Name = "Test" };
        _context.Set<Category>().Add(entity);
        _context.SaveChanges();

        _repository.Delete(entity);

        var deletedEntity = _context.Set<Category>().Find(entity.Id);
        Assert.Null(deletedEntity);
    }

    [Fact]
    public void DeleteById_ShouldRemoveEntityById()
    {
        var entity = new Category { Id = 20, Name = "Test" };
        _context.Set<Category>().Add(entity);
        _context.SaveChanges();

        _repository.DeleteById(entity.Id);

        var deletedEntity = _context.Set<Category>().Find(entity.Id);
        Assert.Null(deletedEntity);
    }

    [Fact]
    public void GetAll_ShouldReturnAllEntities()
    {
        var data = new List<Category>
        {
            new Category { Id = 20, Name = "Test1" },
            new Category { Id = 21, Name = "Test2" }
        };

        _context.Set<Category>().AddRange(data);
        _context.SaveChanges();

        var result = _repository.GetAll();

        Assert.Equal(6, result.Count());
        Assert.Equal("Test2", result.Last().Name);
    }

    [Fact]
    public void GetById_ShouldReturnCorrectEntity()
    {
        var entity = new Category { Id = 35, Name = "Test" };
        _context.Set<Category>().Add(entity);
        _context.SaveChanges();

        var result = _repository.GetById(35);

        Assert.Equal(entity, result);
    }

    [Fact]
    public void Update_ShouldUpdateEntity()
    {
        var entity = new Category { Id = 45, Name = "Test" };
        _context.Set<Category>().Add(entity);
        _context.SaveChanges();

        entity.Name = "Updated Test";
        _repository.Update(entity);

        var updatedEntity = _context.Set<Category>().Find(entity.Id);
        Assert.Equal("Updated Test", updatedEntity.Name);
    }

    [Fact]
    public void Count_ShouldReturnCorrectNumberOfEntities()
    {
        var data = new List<Category>
        {
            new Category { Id = 1, Name = "Test1" },
            new Category { Id = 2, Name = "Test2" }
        };

        _context.Set<Category>().AddRange(data);
        _context.SaveChanges();

        var count = _repository.Count();

        Assert.Equal(2, count);
    }
}
