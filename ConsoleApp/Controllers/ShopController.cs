using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenu;
using ConsoleApp.Helpers;
using ConsoleApp.Validators;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;
using StoreDAL.Entities;

namespace ConsoleApp.Services
{
    public static class ShopController
    {
        private static StoreDbContext context = UserMenuController.Context;

        public static void CancelOrder(UserRoles role)
        {
            var orderService = new CustomerOrderService(context);
            int orderId;

            Console.WriteLine("Enter ID of your order");

            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Please, enter valid ID number");
                return;
            }

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Order with this ID is not exist");
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
            Console.WriteLine("Order was successfuly canceled");
        }

        public static void ConfirmDelivery(UserRoles role)
        {
            var orderService = new CustomerOrderService(context);
            int orderId;

            Console.WriteLine("Enter ID of your order");
            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Please, enter valid ID number");
                return;
            }

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Order with this ID is not exist");
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

        public static void AddOrder()
        {
            throw new NotImplementedException();
        }

        public static void UpdateOrder()
        {
            throw new NotImplementedException();
        }

        public static void DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public static void ShowOrder()
        {
            throw new NotImplementedException();
        }

        public static void ShowAllOrders()
        {
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetAll().Select(u => (CustomerOrderModel)u);
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id} {order.State} {order.OperationTime} ");
            }
        }

        public static void ShowAllUserOrders(int userId)
        {
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetOrdersByCustomerId(userId).Select(u => (CustomerOrderModel)u);
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id} {order.State} {order.OperationTime} ");
            }
        }

        public static void AddOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void UpdateOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void DeleteOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void ShowAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void ProcessOrder()
        {
            throw new NotImplementedException();
        }

        public static void ShowAllOrderStates()
        {
            var service = new OrderStateService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadOrderStateModel), service.GetAll);
            menu.Run();
        }

        public static void ChangeOrderStatus()
        {
            var orderService = new CustomerOrderService(context);
            int orderId;
            int status;

            Console.WriteLine("Enter ID of your order");
            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Please, enter valid ID number");
                return;
            }

            var order = (CustomerOrderModel)orderService.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Order with this ID is not exist");
                return;
            }

            Console.WriteLine("Enter ID of the required status");
            ShowAllOrderStates();

            if (!int.TryParse(Console.ReadLine(), out status) || !GenericValidator<OrderStateModel>.ValidateEntityId(status))
            {
                Console.WriteLine("Enter valid status ID");
                return;
            }

            order.OrderStateId = status;

            orderService.Update(order);
            Console.WriteLine($"Status of the order №{order.Id} has been chaged");
        }
    }
}
