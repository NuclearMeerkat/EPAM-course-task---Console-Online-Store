using StoreBLL.Interfaces;

namespace ConsoleApp.Helpers
{
    public static class ValidationHelper
    {
        public static int ReadValidId(ICrud service)
        {
            int modelId;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out modelId))
                {
                    Console.WriteLine("Not valid value, please, enter digit number");
                }
                else if (service.GetById(modelId) == null)
                {
                    Console.WriteLine("Element with this ID is not existing");
                }
                else
                {
                    break;
                }
            }
            while (true);

            return modelId;
        }

        public static string ReadValidString()
        {
            string text;
            do
            {
                text = Console.ReadLine();
                if (text == null || string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Please, enter valid text");
                }
                else
                {
                    break;
                }
            }
            while (true);

            return text;
        }
    }
}