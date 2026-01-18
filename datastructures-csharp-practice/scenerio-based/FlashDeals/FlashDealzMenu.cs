internal class FlashDealzMenu
{
    private IFlashDealz flashDealzUtility;

    public void ShowFlashDealzMenu()
    {
        flashDealzUtility = new FlashDealzUtility();
        int choice;
        do
        {
            Console.WriteLine("\n==== FLASH DEALZ ====\n");
            Console.WriteLine("1. Add a product.");
            Console.WriteLine("2. List all products.");
            Console.WriteLine("3. Get product with most discount.");
            Console.WriteLine("0.Exit");
            Console.Write("\nPlease enter your choice number: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    flashDealzUtility.AddAProduct();
                    break;
                case 2:
                    flashDealzUtility.ListAllProducts();
                    break;
                case 3:
                    flashDealzUtility.ProductWithMostDiscount();
                    break;
            }

        } while (choice != 0);
    }
}