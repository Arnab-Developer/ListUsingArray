// --------------------------------------------------------------------+
// This file containing the enumeration with the options of operations
// which can be done on a list in this application.
// --------------------------------------------------------------------+

namespace ListUsingArray.ClassLibrary
{
    /// <summary>
    /// Mode of operation on list.
    /// </summary>
    public enum OperationMode
    {
        /// <summary>
        /// Input into list.
        /// </summary>
        Input = 1,

        /// <summary>
        /// Insert item into list.
        /// </summary>
        Insert = 2,

        /// <summary>
        /// Search from list.
        /// </summary>
        Search = 3,

        /// <summary>
        /// Delete item from list.
        /// </summary>
        Delete = 4,

        /// <summary>
        /// Display items from list.
        /// </summary>
        Display = 5,

        /// <summary>
        /// Close the application.
        /// </summary>
        Quit = 6
    }
}
