using System.Collections.Concurrent;

internal class FlashDealzUtility: IFlashDealz
{
    private Product[] _productsList;
    private int _productIndex;

    public FlashDealzUtility()
    {
        int initialSize = 10;
        _productsList = new Product[initialSize];
        _productIndex = 0;
    }

    public void ListAllProducts()
    {
        Console.WriteLine("\n==== PRODUCT LIST ====\n");
        if (_productIndex == 0)
        {
            Console.WriteLine("\nZero Products available...\n");
            return;
        }

        Console.WriteLine("Products are sorted from highest discout to lowest discount:\n");
        for(int i = 0; i < _productIndex; i++)
        {
            Console.WriteLine(_productsList[i]);
        }
        Console.WriteLine();
    }

    public void AddAProduct()
    {
        Console.WriteLine("\n==== PRODUCT ADDITION WINDOW ====\n");
        if(_productIndex >= _productsList.Length)
        {
            ResizeProductsList();
        }
        Console.Write("Please enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Please enter product original price: ");
        double productOriginalPrice = double.Parse(Console.ReadLine());
        Console.Write("Please enter discount percent: ");
        double discountPercent = double.Parse(Console.ReadLine());

        Product product = new Product(productName, productOriginalPrice, discountPercent);
        _productsList[_productIndex++] = product;

        QuickSort(0, _productIndex - 1);

        Console.WriteLine("\nProduct added succesfully...\n");
    }

    public void ProductWithMostDiscount()
    {
        
        Console.WriteLine("\n==== HIGHEST DISCOUNTED PRODUCT ====\n");
        if (_productIndex == 0)
        {
            Console.WriteLine("\nZero Products available...\n");
            return;
        }

        Console.WriteLine("Here is the most discounted product: \n");
        Console.WriteLine(_productsList[0]);
    }

    private void QuickSort(int left, int right)
    {
        if(left >= right)
        {
            return;
        }

        int pivotIndex = Partition(left, right);
        QuickSort(left, pivotIndex - 1);
        QuickSort(pivotIndex + 1, right);
    }

    private int Partition(int left, int right)
    {
        Product pivotProduct = _productsList[right];
        int boundary = left - 1;

        for(int i = left; i <= right-1; i++)
        {
            if (_productsList[i].GetDiscountPercent() >= pivotProduct.GetDiscountPercent())
            {
                boundary++;
                Product tempProduct = _productsList[boundary];
                _productsList[boundary] = _productsList[i];
                _productsList[i] = tempProduct;
            }
        }

        _productsList[right] = _productsList[boundary + 1];
        _productsList[boundary + 1] = pivotProduct;

        return boundary + 1;
    }

    private void ResizeProductsList()
    {
        Product[] tempList = new Product[2 * _productIndex];
        for(int i = 0; i < _productIndex; i++)
        {
            tempList[i] = _productsList[i];
        }
        _productsList = tempList;
    }
}