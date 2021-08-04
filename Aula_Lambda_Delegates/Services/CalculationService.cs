using System;

namespace Aula_Lambda_Delegates
{
    class CalculationService
    {
        public static double Sum(double x, double y)
        {
            return x + y;
        }

        public static void ShowSum(double x, double y)
        {
            Console.WriteLine(Sum(x, y));
        }

        public static void ShowMax(double x, double y)
        {
            double max = (x >= y) ? x : y;
            Console.WriteLine(max);
        }

        public static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }

        public static bool ProductFilter(Product p)
        {
            return p.Price <= 100;
        }
    }
}
