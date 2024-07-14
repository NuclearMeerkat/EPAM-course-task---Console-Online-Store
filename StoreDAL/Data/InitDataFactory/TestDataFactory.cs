namespace StoreDAL.Data.InitDataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDAL.Entities;

public class TestDataFactory : AbstractDataFactory
{
    public override Category[] GetCategoryData()
    {
        return new[]
        {
            new Category(1, "fruits"),
            new Category(2, "water"),
            new Category(3, "vegetables"),
            new Category(4, "seafood"),
            new Category(5, "meet"),
            new Category(6, "grocery"),
            new Category(7, "milk food"),
            new Category(8, "smartphones"),
            new Category(9, "laptop"),
            new Category(10, "photocameras"),
            new Category(11, "kitchen accesories"),
            new Category(12, "spices"),
            new Category(13, "Juice"),
            new Category(14, "alcohol drinks"),
        };
    }

    public override CustomerOrder[] GetCustomerOrderData()
    {
        return new[]
        {
            new CustomerOrder(1, "2023-07-01 10:00:00", 1, 1),
            new CustomerOrder(2, "2020-07-03 14:30:00", 2, 4),
            new CustomerOrder(3, "2023-07-04 09:00:00", 3, 1),
            new CustomerOrder(4, "2021-07-05 16:45:00", 4, 7),
            new CustomerOrder(5, "2023-07-06 12:00:00", 5, 6),
        };
    }

    public override Manufacturer[] GetManufacturerData()
    {
        return new[]
        {
            new Manufacturer(1, "Fresh Farms"),
            new Manufacturer(2, "Ocean Harvest"),
            new Manufacturer(3, "Dairy Best"),
            new Manufacturer(4, "Tech World"),
            new Manufacturer(5, "Gourmet Spices"),
        };
    }

    public override OrderDetail[] GetOrderDetailData()
    {
        return new[]
        {
            new OrderDetail(1, 1, 1, 2.99m, 5),
            new OrderDetail(2, 2, 4, 15.99m, 1),
            new OrderDetail(3, 3, 3, 1.49m, 10),
            new OrderDetail(4, 4, 2, 1.49m, 5),
            new OrderDetail(5, 5, 5, 3.99m, 2),
        };
    }

    public override OrderState[] GetOrderStateData()
    {
        return new[]
        {
            new OrderState(1, "New Orders"),
            new OrderState(2, "Cancelled by user"),
            new OrderState(3, "Cancelled by administrator"),
            new OrderState(4, "Confirmed"),
            new OrderState(5, "Moved to delivery company"),
            new OrderState(6, "In delivery"),
            new OrderState(7, "Delivered to client"),
            new OrderState(8, "Delivery confirmed by client"),
        };
    }

    public override Product[] GetProductData()
    {
        return new[]
        {
            new Product(1, 1, 1, "Fresh apples", 2.99m),
            new Product(2, 2, 2, "Bottled water", 1.49m),
            new Product(3, 3, 3, "Carrots", 3.99m),
            new Product(4, 4, 2, "Salmon fillets", 15.99m),
            new Product(5, 5, 3, "Whole milk", 3.99m),
            new Product(6, 6, 4, "Blender", 199.99m),
            new Product(7, 7, 5, "Mixed spices", 4.99m),
        };
    }

    public override ProductTitle[] GetProductTitleData()
    {
        return new[]
        {
            new ProductTitle(1, "Apple", 1),
            new ProductTitle(2, "Bottled Water", 2),
            new ProductTitle(3, "Carrot", 3),
            new ProductTitle(4, "Salmon Fillets", 4),
            new ProductTitle(5, "Whole Milk", 7),
            new ProductTitle(6, "Blender", 11),
            new ProductTitle(7, "Mixed Spices", 12),
        };
    }

    public override User[] GetUserData()
    {
        return new[]
        {
            new User(1, "John", "Doe", "johndoe", "password123", 2),
            new User(2, "Jane", "Smith", "janesmith", "password456", 2),
            new User(3, "Emily", "Johnson", "emilyj", "password789", 2),
            new User(4, "Michael", "Brown", "michaelb", "password321", 2),
            new User(5, "Sarah", "Davis", "sarahd", "password654", 2),
        };
    }

    public override UserRole[] GetUserRoleData()
    {
        return new[]
        {
            new UserRole(1, "Admin"),
            new UserRole(2, "Registered"),
            new UserRole(3, "Guest"),
        };
    }
}
