using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenu;
using ConsoleApp.Helpers;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;

namespace ConsoleApp.Services
{
    /// <summary>
    /// Controller for managing shop operations, including orders and order states.
    /// </summary>
    public static class ShopController
    {
        private static StoreDbContext context = UserMenuController.Context;

        /// <summary>
        /// Cancels an order based on the user's currentUserRole.
        /// </summary>
        /// <param name="role">The currentUserRole of the user.</param>
        public static void CancelOrder()
        {
            var orderService = new CustomerOrderService(context);
            var currentUserRole = UserMenuController.UserRole;

            Console.Clear();
            UserMenuController.ShowAllUserOrders();

            Console.WriteLine("Enter ID of your order");
            int orderId = ValidationHelper.ReadValidId(orderService);

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (currentUserRole == UserRoles.RegistredCustomer)
            {
                order.OrderStateId = 2; // Cancelled by user
            }
            else if (currentUserRole == UserRoles.Administrator)
            {
                order.OrderStateId = 3; // Cancelled by administrator
            }

            orderService.Update(order);

            UserMenuController.ShowAllUserOrders();

            Console.WriteLine("Order was successfully canceled");
        }

        /// <summary>
        /// Confirms the delivery of an order based on the user's currentUserRole.
        /// </summary>
        /// <param name="role">The currentUserRole of the user.</param>
        public static void ConfirmDelivery()
        {
            var orderService = new CustomerOrderService(context);
            var currentUserRole = UserMenuController.UserRole;

            Console.Clear();
            UserMenuController.ShowAllUserOrders();
            Console.WriteLine("Enter ID of your order");
            int orderId = ValidationHelper.ReadValidId(orderService);
            Console.Clear();

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (currentUserRole == UserRoles.RegistredCustomer)
            {
                order.OrderStateId = 8; // Confirmed by client
            }
            else if (currentUserRole == UserRoles.Administrator)
            {
                order.OrderStateId = 4; // Confirmed
            }

            orderService.Update(order);

            Console.Clear();
            UserMenuController.ShowAllUserOrders();

            Console.WriteLine("Thank you for using our services!");
        }

        /// <summary>
        /// Adds a new order.
        /// </summary>
        public static void AddOrder()
        {
            var orderService = new CustomerOrderService(context);

            // Creating new order with current time, New order state and current user id
            var orderModel = new CustomerOrderModel(
                DateTime.Now.ToString(CultureInfo.InvariantCulture),
                1,
                UserMenuController.UserId);

            orderService.Add(orderModel);
        }

        /// <summary>
        /// Shows all orders.
        /// </summary>
        public static void ShowAllOrders()
        {
            var service = new CustomerOrderService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadCustomerOrderModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Shows all orders for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public static void ShowAllUserOrders()
        {
            Console.Clear();
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetOrdersByCustomerId(UserMenuController.UserId).Select(u => (CustomerOrderModel)u);
            Console.WriteLine("======= Current DataSet ==========");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("===================================");
        }

        /// <summary>
        /// Adds new order details.
        /// </summary>
        public static void AddOrderDetailsToChart()
        {
            var productService = new ProductService(context);

            Console.WriteLine("Enter id of the product you need");
            int productId = ValidationHelper.ReadValidId(productService);
            Console.Clear();

            Console.WriteLine("Enter the amount of product you need");
            int productAmount = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Clear();

            var product = (ProductModel)productService.GetById(productId);

            var fullPrice = productAmount * product.UnitPrice;

            var orderDetailModel = new OrderDetailModel(
                productId,
                fullPrice,
                productAmount,
                UserMenuController.UserId);

            UserChartController.AddOrderDetailToChart(UserMenuController.UserId, orderDetailModel);
            Console.WriteLine("******************************");
            Console.WriteLine("**Product added to the chart**");
            Console.WriteLine("******************************");
        }

        /// <summary>
        /// Shows all possible order states.
        /// </summary>
        public static void ShowAllOrderStates()
        {
            Console.Clear();
            var service = new OrderStateService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadOrderStateModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Changes the status of an order.
        /// </summary>
        public static void ChangeOrderStatus()
        {
            var orderService = new CustomerOrderService(context);

            var order = InputHelper.ReadOrderWithNewStatus();
            orderService.Update(order);

            Console.WriteLine($"Status of order ID:{order.Id} has been changed");
        }

        public static void ShowAllProducts()
        {
            var productService = new ProductService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(productService, InputHelper.ReadProductModel), productService.GetAll);
            menu.Run();
        }
    }
}
