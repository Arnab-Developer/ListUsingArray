// -------------------------------------------------------------------+
// This file containing the List class. This class representing a list
// which is implemented using an array.
// -------------------------------------------------------------------+

using System;

namespace ListUsingArray.ClassLibrary
{
    /// <summary>
    /// Impliments list using an array.
    /// </summary>
    public class List
    {
        private int[] _list;
        private int _numberOfElementInList;

        /// <summary>
        /// Parameterised constructor.
        /// </summary>
        /// <param name="sizeOfList">Size of the list.</param>
        public List(int sizeOfList)
        {
            _numberOfElementInList = sizeOfList;
            _list = new int[sizeOfList];
        }

        /// <summary>
        /// Perform operation on list.
        /// </summary>
        /// <param name="mode">Mode of the operation on list.</param>
        public void PerformOperationOnList(OperationMode mode)
        {
            int position;
            bool isFound;

            switch (mode)
            {
                case OperationMode.Input:
                    InputList();
                    break;

                case OperationMode.Insert:
                    Insert();
                    break;

                case OperationMode.Search:
                    Console.Write("Please enter an item to search: ");
                    int itemToSearch = int.Parse(Console.ReadLine());

                    isFound = Search(itemToSearch, out position);

                    if (isFound)
                    {
                        Console.WriteLine("Item found at {0} position", position);
                    }
                    else
                    {
                        Console.WriteLine("Item can not be found");
                    }
                    break;

                case OperationMode.Delete:
                    Delete();
                    break;

                case OperationMode.Display:
                    Display();
                    break;

                case OperationMode.Quit:
                    break;

                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }

        private void InputList()
        {
            for (int counter = 0; counter < _list.Length; counter++)
            {
                Console.Write("Please enter an item: ");
                int item = int.Parse(Console.ReadLine());

                _list[counter] = item;
            }
        }

        private void Insert()
        {
            if (_list.Length == _numberOfElementInList)
            {
                Console.WriteLine("List overflow");
                return;
            }

            Console.Write("Please enter a position to insert: ");
            int position = int.Parse(Console.ReadLine());

            Console.Write("Please enter an item to insert: ");
            int itemToInsert = int.Parse(Console.ReadLine());

            if (position > _numberOfElementInList)
            {
                Console.WriteLine("Please enter position less than size of the list");
                return;
            }

            // Insert at the last of the list.
            if (position == _numberOfElementInList)
            {
                _list[position] = itemToInsert;
                _numberOfElementInList++;
                return;
            }

            // Insert in the middle position of the list.
            int temp = _numberOfElementInList - 1;
            while (temp >= position)
            {
                _list[temp + 1] = _list[temp];
                temp--;
            }
            _list[position] = itemToInsert;
            _numberOfElementInList++;
        }

        private bool Search(int itemToSearch, out int position)
        {
            bool isFound = false;
            position = -1;

            for (int counter = 0; counter < _list.Length; counter++)
            {
                if (_list[counter] == itemToSearch)
                {
                    position = counter;
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        private void Delete()
        {
            bool isFound;
            int position;

            if (_numberOfElementInList == 0)
            {
                Console.WriteLine("List underflow");
                return;
            }

            Console.Write("Please enter an item to delete: ");
            int itemToDelete = int.Parse(Console.ReadLine());

            isFound = Search(itemToDelete, out position);

            if (isFound)
            {
                // Delete the last item from the list.
                if (position == _numberOfElementInList)
                {
                    _numberOfElementInList--;
                }

                // Delete item from the middle position of the list.
                int temp = position;
                while (temp < _numberOfElementInList - 1)
                {
                    _list[temp] = _list[temp + 1];
                    temp++;
                }
                _numberOfElementInList--;
            }
            else
            {
                Console.WriteLine("Item can not be found in the list");
            }
        }

        private void Display()
        {
            if (_numberOfElementInList == 0)
            {
                Console.WriteLine("List underflow");
                return;
            }

            Console.WriteLine();

            for (int counter = 0; counter < _numberOfElementInList; counter++)
            {
                Console.WriteLine(_list[counter]);
            }

            Console.WriteLine();
        }
    }
}
