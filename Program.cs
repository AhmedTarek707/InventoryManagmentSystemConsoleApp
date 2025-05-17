namespace Inventory_Mangment_System
{
    internal class Program
    {
        static string[,] Products = new string[4, 5];
        static int items = 0;
        static int id = 0;
        static void Main(string[] args)
        {

            //simple inventory management system
            //has core functions as add, remove, update and display items
            //using simple data structure such as 2d array
            //the attributes of the items are id, name, quantity, price and category
            //the id increment automatically when a new item is added
            #region core app
            Console.WriteLine("----------------welcome beek in our inventory management system--------------");
            while (true)
            {
                Console.WriteLine("1.Add product\n2.Update product\n3.Remove product\n4.Search for product\n5.Display all product\n6.Exit\n7.sortProductAccordingPrice\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        UpdateItem();
                        break;
                    case "3":
                        RemoveItem();
                        break;
                    case "4":
                        SearchItem();
                        break;
                    case "5":
                        DisplayItems();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    case "7":
                        SortItems();  //sort_items_according_to_price
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            #endregion
        }
        #region add item
        private static void AddItem()
        {
            Console.WriteLine($"enter details of product{id + 1} in order name,price,quantity and category");
            Console.WriteLine("enter product name:");
            Products[items, 1] = Console.ReadLine();
            Console.WriteLine("enter product price:");
            Products[items, 2] = Console.ReadLine();
            Console.WriteLine("enter product quantity:");
            Products[items, 3] = Console.ReadLine();
            Console.WriteLine("enter product category:");
            Products[items, 4] = Console.ReadLine();
            ++id;
            Products[items, 0] = id.ToString();
            ++items;
            Console.WriteLine("product added successfully");
        }
        #endregion
        #region remove item
        private static void RemoveItem()
        {
            Console.WriteLine("plz enter product id that want to remove");
            string Usid = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < items; i++)
            {
                if (Products[i, 0] == Usid)
                {
                    found = true;
                    for (int j = 0; j < Products.GetLength(1); j++)
                    {
                        Products[i, j] = "Out OF Stock";//or say equal null
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("product not found");
            }
            else
            {
                Console.WriteLine("product removed successfully");
            }
        }
        #endregion
        #region update item
        private static void UpdateItem()
        {
            Console.WriteLine("plz enter the name of product u want to update it");
            string Pname = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < items; i++)
            {
                if (Products[i, 1] == Pname)
                {
                    found = true;
                    Console.WriteLine("enter new product name:");
                    Products[i, 1] = Console.ReadLine();
                    Console.WriteLine("enter new product price:");
                    Products[i, 2] = Console.ReadLine();
                    Console.WriteLine("enter new product quantity:");
                    Products[i, 3] = Console.ReadLine();
                    Console.WriteLine("enter new product category:");
                    Products[i, 4] = Console.ReadLine();
                }
            }
            if (found == false)
            {
                Console.WriteLine("product not found");
            }
            else
            {
                Console.WriteLine("product updated successfully");
            }
        }
        #endregion
        #region display items
        private static void DisplayItems()
        {
            if (items > 0)
            {
                for (int i = 0; i < items; i++)
                {
                    Console.WriteLine($"product{i + 1} details are:");
                    Console.WriteLine($"productID: {Products[i, 0]}\nproductName: {Products[i, 1]}\nproductPrice: {Products[i, 2]}\nproductQuantity: {Products[i, 3]}\nproductCat: {Products[i, 4]}\n");
                }
            }
            else
            {
                Console.WriteLine("No products in Inventory");
            }
        }
        #endregion
        #region search item
        private static void SearchItem()
        {
            Console.WriteLine("plz type the name of the product u search for");
            string Usname = Console.ReadLine();
            bool b = false;
            for (int i = 0; i < items; i++)
            {
                if (Products[i, 1] == Usname)
                {
                    b = true;
                    Console.WriteLine($"product{i + 1} details are:");
                    Console.WriteLine($"productID: {Products[i, 0]}\nproductName: {Products[i, 1]}\nproductPrice: {Products[i, 2]}\nproductQuantity: {Products[i, 3]}\nproductCat: {Products[i, 4]}\n");
                }
            }
            if (b == false)
            {
                Console.WriteLine("product not found");
            }
        }
        #endregion
        #region sort items according to price
        private static void SortItems()
        {
            if (items > 0)
            {
                for (int i = 0; i < items; i++)
                {

                    for (int j = i + 1; j < items; j++)
                        if (int.Parse(Products[i + 1, 2]) > int.Parse(Products[i, 2]))
                        {
                            string temp = Products[i, 2];
                            Products[i, 2] = Products[i + 1, 2];
                            Products[i + 1, 2] = temp;
                        }
                }
                Console.WriteLine("products sorted successfully");
            }
            else
            {
                Console.WriteLine("No products in Inventory to be sort");
            }
        }
        #endregion
    }
}
    

