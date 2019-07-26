using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Week2CapstoneTaskList_NateS
{
    
    public class Validator
    {
        //feilds

        #region Properties
        //Constructor
        public Validator()
        {

        }
        
        public static double ValidateDouble(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            bool isValid = double.TryParse(input, out double result);
            if (isValid && result > 0)
            {
                return result;
            }
            else if (isValid)
            {
                return ValidateDouble("Please enter a value GREATER THAN 0.00");
            }
            else
            {
                Console.WriteLine("(FormatException)");
                return ValidateDouble($"{input} is Not Valid!");
            }
        }
        public static bool GetYN(string message)
        {
            Console.WriteLine(message + "(Y/N)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                return GetYN("Not Valid!");
            }
        }
        public static int GetIntChoice(int min, int max)
        {
            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int ChV);
            
            if (!isValid)
            {
                Console.WriteLine("Not Valid, Please enter an Interger");
                return GetIntChoice(min,max);
            }
            else if (ChV >= min && ChV <= max)
            {
                return ChV - 1;
            }
            else
            {
                Console.WriteLine($"Not Valid, {ChV} is not within the range {min}-{max}!");
                return GetIntChoice(min, max);
            }
        }
        public static string VerifyDate(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Format as DD/MM/YYYY");
            string inputS = Console.ReadLine();
            if (Regex.IsMatch(inputS, @"^((\d{2})\/(\d{2})\/(\d{4}))$"))
            {
                return inputS;
            }
            else
            {
                return VerifyDate("Not Valid!");
            }
        }
        public static string VerifyNames(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, @"^(([A-Z]{1}\w{2,29}\s{0,1}[A-Z]{0,1}[a-z]{0,29}))$"))
            {
                return input;
            }
            else
            {
                return VerifyNames("Not Valid!");
            }
        }
        public static string GetString(string message)
        {
            Console.WriteLine(message);
            string result = Console.ReadLine();

            if (result != null && result != " " && result != "")
            {
                return result;
            }
            else
            {
                return GetString("Not Valid!");
            }
        }
        public static void EndProgram(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("press ESC to exit");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            { }
        }
        public static bool VerifyPassword(string gateWord)
        {
            System.Console.Write("Enter password: ");
            string password = null;
            while (true)
            {
                System.ConsoleKeyInfo input = System.Console.ReadKey(true);
                if (input.Key == ConsoleKey.Enter)
                    break;
                password += input.KeyChar;
                Console.Write("X");
            }
            if (gateWord.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
