using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Cancels an order based on the user's role.
        /// </summary>
        /// <param name="role">The role of the user.</param>
        public static void CancelOrder(UserRoles role)
        {
            var orderService = new CustomerOrderService(context);
            int orderId;

            Console.WriteLine("Enter ID of your order");

            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Please, enter a valid ID number");
                return;
            }

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Order with this ID does not exist");
                return;
            }

            if (role == UserRoles.RegistredCustomer)
            {
                order.OrderStateId = 2; // Cancelled by user
            }
            else if (role == UserRoles.Administrator)
            {
                order.OrderStateId = 3; // Cancelled by administrator
            }

            orderService.Update(order);
            Console.WriteLine("Order was successfully canceled");
        }

        /// <summary>
        /// Confirms the delivery of an order based on the user's role.
        /// </summary>
        /// <param name="role">The role of the user.</param>
        public static void ConfirmDelivery(UserRoles role)
        {
            var orderService = new CustomerOrderService(context);
            int orderId;

            Console.WriteLine("Enter ID of your order");
            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Please, enter a valid ID number");
                return;
            }

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Order with this ID does not exist");
                return;
            }

            if (role == UserRoles.RegistredCustomer)
            {
                order.OrderStateId = 8; // Confirmed by client
            }
            else if (role == UserRoles.Administrator)
            {
                order.OrderStateId = 4; // Confirmed
            }

            orderService.Update(order);
            Console.WriteLine("Thank you for using our services!");
        }

        /// <summary>
        /// Adds a new order.
        /// </summary>
        public static void AddOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        public static void UpdateOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an order.
        /// </summary>
        public static void DeleteOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows details of a specific order by ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        public static void ShowOrder(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all orders.
        /// </summary>
        public static void ShowAllOrders()
        {
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetAll().Select(u => (CustomerOrderModel)u);
            Console.WriteLine("======= Current DataSet ==========");
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id} {order.State} {order.OperationTime} ");
            }
            Console.WriteLine("===================================");
        }

        /// <summary>
        /// Shows all orders for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public static void ShowAllUserOrders(int userId)
        {
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetOrdersByCustomerId(userId).Select(u => (CustomerOrderModel)u);
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
        public static void AddOrderDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates existing order details.
        /// </summary>
        public static void UpdateOrderDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes order details.
        /// </summary>
        public static void DeleteOrderDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all order details.
        /// </summary>
        public static void ShowAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Processes an order.
        /// </summary>
        public static void ProcessOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows all possible order states.
        /// </summary>
        public static void ShowAllOrderStates()
        {
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
            var orderStateService = new OrderStateService(context);
            int orderId;
            int status;

            Console.WriteLine("Enter ID of your order");
            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Please, enter a valid ID number");
                return;
            }

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Order with this ID does not exist");
                return;
            }

            Console.WriteLine("Enter ID of the required status");
            ShowAllOrderStates();

            if (!int.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Enter valid status ID");
                return;
            }

            if (orderStateService.GetById(status) == null)
            {
                Console.WriteLine("Status with this ID does not exist");
                return;
            }

            order.OrderStateId = status;

            orderService.Update(order);
            Console.WriteLine($"Status of order №{order.Id} has been changed");
        }
    }
}
