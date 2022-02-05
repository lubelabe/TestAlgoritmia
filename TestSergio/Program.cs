using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSergio
{
    class Program
    {
        private static string[] listNumbersDataBase;
        private static string[] listNumbersToConsults;
        
        static void Main(string[] args)
        {
            GetDataToUser();
            CalculateResultToConsult();
        }

        private static void GetDataToUser()
        {
            int sizeListNumbers;
            string numbersToList;
            string numbersToListConsults;
            int countRequestToEvaluation;
            
            Console.WriteLine("digite el tamaño de la lista de números a evaluar");
            sizeListNumbers = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("ingrese los números para la lista, separados por un espacio");
                numbersToList = Console.ReadLine();

                listNumbersDataBase = numbersToList.Split(" ");

                if (listNumbersDataBase.Length > sizeListNumbers)
                    Console.WriteLine("La cantidad de números ingresados es mayor al tamaño de la lista");
                else if (listNumbersDataBase.Length < sizeListNumbers)
                    Console.WriteLine("La cantidad de números ingresados es menor al tamaño de la lista");
                
            } while (listNumbersDataBase.Length > sizeListNumbers || listNumbersDataBase.Length < sizeListNumbers);
            
            Console.WriteLine("Ingrese un número entero para la cantidad de consultas");
            countRequestToEvaluation = int.Parse(Console.ReadLine());
            
            do
            {
                Console.WriteLine("Ingrese los números que se van a consultar, separados por un espacio");
                numbersToListConsults = Console.ReadLine();

                listNumbersToConsults = numbersToListConsults.Split(" ");

                if (listNumbersToConsults.Length > countRequestToEvaluation)
                    Console.WriteLine("la cantidad de número ingresados es mayor a la cantidad de consultas ingresadas");
                else if (listNumbersToConsults.Length < countRequestToEvaluation)
                    Console.WriteLine("la cantidad de número ingresados es menor a la cantidad de consultas ingresadas");
            } 
            while(listNumbersToConsults.Length > countRequestToEvaluation || listNumbersToConsults.Length < countRequestToEvaluation);
        }

        private static void CalculateResultToConsult()
        {
            string minValue;
            string maxValue;

            List<int> listMaxNums = new List<int>();
            List<int> listMinNums = new List<int>();
            
            for (int i = 0; i < listNumbersToConsults.Length; i++)
            {
                listMaxNums.Clear();
                listMinNums.Clear();
                
                for (int j = 0; j < listNumbersDataBase.Length; j++)
                {
                    if (int.Parse(listNumbersToConsults[i]) < int.Parse(listNumbersDataBase[j]))
                    {
                        listMaxNums.Add(int.Parse(listNumbersDataBase[j]));
                    }
                    else if (int.Parse(listNumbersToConsults[i]) > int.Parse(listNumbersDataBase[j]))
                    {
                        listMinNums.Add(int.Parse(listNumbersDataBase[j]));
                    }
                }

                if (listMaxNums.Count > 0)
                    maxValue = listMaxNums.Min().ToString();
                else
                    maxValue = "X";

                if (listMinNums.Count > 0)
                    minValue = listMinNums.Max().ToString();
                else
                    minValue = "X";
                
                Console.WriteLine(minValue + " " + maxValue);
            }
        }
    }
}