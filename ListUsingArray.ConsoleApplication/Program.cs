using System;
using ListUsingArray.ClassLibrary;

namespace ListUsingArray.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To 'List Using Array' Application\n");

            bool isValidToContinue;
            List myList;

            TakeStartupInput(out isValidToContinue, out myList);
            if (isValidToContinue)
            {
                PerformOperationsOnList(myList);
                EndOfProgram(isValidToContinue); // Application end with success.
            }

            Console.ReadKey(true);
        }

        private static void TakeStartupInput(out bool isValidToContinue, out List myList)
        {
            Console.Write("Please enter the size of the list: ");

            int size = 0;
            isValidToContinue = false;

            try
            {
                size = int.Parse(Console.ReadLine());
                isValidToContinue = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry your input is not valid.");
                EndOfProgram(isValidToContinue); // Application end with error.
            }
            catch (Exception)
            {
                Console.WriteLine("Operation can not be done due to some problem");
                EndOfProgram(isValidToContinue); // Application end with error.
            }

            myList = new List(size);
        }

        private static void PerformOperationsOnList(List myList)
        {
            OperationMode mode = OperationMode.Input;

            do
            {
                Console.WriteLine("\nInput");
                Console.WriteLine("Insert");
                Console.WriteLine("Search");
                Console.WriteLine("Delete");
                Console.WriteLine("Display");
                Console.WriteLine("Quit\n");

                Console.Write("Please enter your choise: ");
                string choise = string.Empty;
                try
                {
                    choise = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine
                        ("Please enter valid input."); // Then go to next loop cycle to try again.
                }
                catch (Exception)
                {
                    Console.WriteLine
                        ("Operation can not be done due to some problem"); // Then go to next loop cycle to try again.
                }

                if (choise != string.Empty)
                {
                    try
                    {
                        mode = (OperationMode)Enum.Parse(typeof(OperationMode), choise, true);
                        myList.PerformOperationOnList(mode); // Perform logic which is in the class library.
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Please enter valid input.");
                    }
                }

            } while (mode != OperationMode.Quit);
        }

        private static void EndOfProgram(bool isValidToContinue)
        {
            if (isValidToContinue)
            {
                Console.WriteLine("\nThank you");
            }
            else
            {
                Console.WriteLine("\nBetter luck next time");
            }
        }
    }
}
