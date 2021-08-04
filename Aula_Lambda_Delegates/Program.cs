using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula_Lambda_Delegates
{
    delegate double BinaryNumericOperation(double n1, double n2);
    delegate void Operations(double n1, double n2);

    class Program
    {
        
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD", 80.90));
            list.Add(new Product("Keyboard", 120.99));
            list.Add(new Product("Mousepad", 40.00));

            //Example of action
            Action<string> greet = msg =>
            {
                string greeting = $"Hello {msg}!";
                Console.WriteLine(greeting);
            };
            greet("World");

            //BASIC DELEGATE
            BinaryNumericOperation op = CalculationService.Sum;
            double sum = op(2, 5); 

            //MULTICAST DELEGATE
            Operations op1 = CalculationService.ShowSum;
            op1 += CalculationService.ShowMax;

            op1.Invoke(2, 5);

            //PREDICATE
            Predicate<Product> pred = CalculationService.ProductFilter;
            list.RemoveAll(pred);

            //ACTION
            Action<Product> act = CalculationService.UpdatePrice;
            // or Action<Product> act = p => { p.Price += p.Price * 0.1; }
            list.ForEach(act);

            //FUNC
            Func<Product, string> func = NameToUpper;
            List<string> listResult = list.Select(func).ToList();

            foreach (string p in listResult)
            {
                Console.WriteLine(p);
            }
        } 
        
        static string NameToUpper(Product p)
        {
            p.Name = p.Name.ToUpper();
            return p.ToString();
        }
    }
}
