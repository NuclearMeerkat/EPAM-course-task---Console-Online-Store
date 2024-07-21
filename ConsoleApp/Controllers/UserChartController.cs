using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Services;
using ConsoleApp1;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;
using StoreDAL.Entities;

namespace ConsoleApp.Controllers
{
    /// <summary>
    /// Singletone class which implement chart functionality for each user.
    /// </summary>
    public static class UserChartController
    {
        private static Dictionary<int, List<OrderDetailModel>> userCharts = new Dictionary<int, List<OrderDetailModel>>();
        private static StoreDbContext context = UserMenuController.Context;

        /// <summary>
        /// Gets the chart for the specified user. If the chart does not exist, a new one is created.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The list of customer orders for the user.</returns>
        public static List<OrderDetailModel> GetOrCreateChart(int userId)
        {
            if (!userCharts.ContainsKey(userId))
            {
                userCharts[userId] = new List<OrderDetailModel>();
            }

            return userCharts[userId];
        }

        /// <summary>
        /// Adds an order to the user's chart.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="order">The customer order to add.</param>
        public static void AddOrderDetailToChart(int userId, OrderDetailModel order)
        {
            if (!userCharts.ContainsKey(userId))
            {
                userCharts[userId] = new List<OrderDetailModel>();
            }

            userCharts[userId].Add(order);
        }

        /// <summary>
        /// Confirms the order for the user and disposes of it in the chart.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public static void ConfirmOrder(int userId)
        {
            var orderDetailService = new OrderDetailService(context);
            var orderService = new CustomerOrderService(context);

            var chart = GetOrCreateChart(userId);

            Console.Clear();

            if (chart == null || chart.Count == 0)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("***Chart is empty.... for now =)***");
                Console.WriteLine("***********************************\n");
                return;
            }

            ShopController.AddOrder();
            var lastOrder = orderService.GetOrdersByCustomerId(userId).Last();

            var orderDetails = GetOrCreateChart(userId);

            for (int i = 0; i < orderDetails.Count; i++)
            {
                orderDetails[i] = new OrderDetailModel(
                    orderDetails[i].ProductId,
                    orderDetails[i].Price,
                    orderDetails[i].Amount,
                    lastOrder.Id);
            }

            foreach (var orderDetail in orderDetails)
            {
                orderDetailService.Add(orderDetail);
            }

            userCharts[userId].Clear();

            Console.WriteLine("************************************************");
            Console.WriteLine("****************Order created!******************");
            Console.WriteLine("************************************************\n");
        }

        public static void ViewUserChart(int userId)
        {
            var chart = GetOrCreateChart(userId);

            Console.Clear();

            if (chart == null || chart.Count == 0)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("***Chart is empty.... for now =)***");
                Console.WriteLine("***********************************\n");
                return;
            }

            Console.WriteLine("************** Chart **************");
            int id = 1;
            foreach (var orderDetail in chart)
            {
                Console.WriteLine($"{"ID:" + id,-7}{"ProductID:" + orderDetail.ProductId,-15} {"Price:" + orderDetail.Price,-10} {"Amount:" + orderDetail.Amount,-10}");
                id++;
            }

            Console.WriteLine("***********************************\n");
        }

        public static void DeleteOrderDetail(int userId)
        {
            Console.Clear();
            Console.WriteLine("Enter the id of the order details you need to delete from the chart:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > userCharts[userId].Count)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Enter, please, valid number");
                Console.WriteLine("***************************");
                return;
            }

            userCharts[userId].RemoveAt(id - 1);

            Console.Clear();
            Console.WriteLine("************************************************");
            Console.WriteLine("Elemen was successfuly deleted from the chart =)");
            Console.WriteLine("************************************************\n");
        }
    }
}
