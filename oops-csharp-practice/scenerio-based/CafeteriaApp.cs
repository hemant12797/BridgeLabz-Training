using System;

class CafeteriaMenuApp
{
    static string[] menuItems =
    {
        "Espresso",
        "Cappuccino",
        "Latte",
        "Americano",
        "Masala Chai",
        "Cold Coffee",
        "Veg Sandwich",
        "Cheese Sandwich",
        "French Fries",
        "Chocolate Brownie"
    };

    static void Main()
    {
        DisplayMenu();

        Console.Write("\nEnter item index to order: ");
        int index = Convert.ToInt32(Console.ReadLine());

        string selectedItem = GetItemByIndex(index);

        if (selectedItem != null)
        {
            Console.WriteLine("\nYou ordered: " + selectedItem);
        }
        else
        {
            Console.WriteLine("\nInvalid selection.");
        }
    }

    // Method to display menu
    static void DisplayMenu()
    {
        Console.WriteLine("----- Cafeteria Menu -----");
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine(i + " : " + menuItems[i]);
        }
    }

    // Method to get item by index
    static string GetItemByIndex(int index)
    {
        if (index >= 0 && index < menuItems.Length)
        {
            return menuItems[index];
        }
        return null;
    }
}
