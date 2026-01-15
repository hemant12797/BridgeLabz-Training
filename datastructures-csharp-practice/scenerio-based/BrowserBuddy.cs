using System;
using System.Collections.Generic;

public class Page
{
    public string Url { get; set; }
    public Page(string url) { Url = url; }
}

public class Tab
{
    public LinkedList<Page> History { get; private set; }
    public LinkedListNode<Page> Current { get; private set; }

    public Tab()
    {
        History = new LinkedList<Page>();
        Current = null;
    }

    public void VisitPage(string url)
    {
        Page page = new Page(url);
        if (Current == null)
        {
            History.AddFirst(page);
            Current = History.First;
        }
        else
        {
            // Remove forward history
            while (Current.Next != null)
            {
                History.RemoveLast();
            }
            History.AddAfter(Current, page);
            Current = Current.Next;
        }
    }

    public bool Back()
    {
        if (Current?.Previous != null)
        {
            Current = Current.Previous;
            return true;
        }
        return false;
    }

    public bool Forward()
    {
        if (Current?.Next != null)
        {
            Current = Current.Next;
            return true;
        }
        return false;
    }

    public string GetCurrentPage()
    {
        return Current?.Value.Url ?? "No page";
    }
}

public class Browser
{
    public List<Tab> OpenTabs { get; private set; }
    public Stack<Tab> ClosedTabs { get; private set; }

    public Browser()
    {
        OpenTabs = new List<Tab>();
        ClosedTabs = new Stack<Tab>();
    }

    public void OpenTab()
    {
        OpenTabs.Add(new Tab());
    }

    public bool CloseTab(int index)
    {
        if (index >= 0 && index < OpenTabs.Count)
        {
            Tab tab = OpenTabs[index];
            OpenTabs.RemoveAt(index);
            ClosedTabs.Push(tab);
            return true;
        }
        return false;
    }

    public bool ReopenTab()
    {
        if (ClosedTabs.Count > 0)
        {
            Tab tab = ClosedTabs.Pop();
            OpenTabs.Add(tab);
            return true;
        }
        return false;
    }

    public Tab GetTab(int index)
    {
        return index >= 0 && index < OpenTabs.Count ? OpenTabs[index] : null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Browser browser = new Browser();
        int currentTabIndex = -1;

        while (true)
        {
            Console.WriteLine("\nBrowserBuddy Menu:");
            Console.WriteLine("1. Open New Tab");
            Console.WriteLine("2. Close Tab");
            Console.WriteLine("3. Reopen Closed Tab");
            Console.WriteLine("4. Switch Tab");
            Console.WriteLine("5. Visit Page");
            Console.WriteLine("6. Go Back");
            Console.WriteLine("7. Go Forward");
            Console.WriteLine("8. Display Current Page");
            Console.WriteLine("9. Display All Tabs");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    browser.OpenTab();
                    currentTabIndex = browser.OpenTabs.Count - 1;
                    Console.WriteLine("New tab opened.");
                    break;
                case "2":
                    if (browser.OpenTabs.Count == 0)
                    {
                        Console.WriteLine("No tabs to close.");
                        break;
                    }
                    Console.Write("Enter tab index to close (0-based): ");
                    if (int.TryParse(Console.ReadLine(), out int closeIndex) && browser.CloseTab(closeIndex))
                    {
                        Console.WriteLine("Tab closed.");
                        if (currentTabIndex >= browser.OpenTabs.Count) currentTabIndex = browser.OpenTabs.Count - 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;
                case "3":
                    if (browser.ReopenTab())
                    {
                        Console.WriteLine("Tab reopened.");
                        currentTabIndex = browser.OpenTabs.Count - 1;
                    }
                    else
                    {
                        Console.WriteLine("No closed tabs to reopen.");
                    }
                    break;
                case "4":
                    Console.Write("Enter tab index to switch to (0-based): ");
                    if (int.TryParse(Console.ReadLine(), out int switchIndex) && switchIndex >= 0 && switchIndex < browser.OpenTabs.Count)
                    {
                        currentTabIndex = switchIndex;
                        Console.WriteLine($"Switched to tab {currentTabIndex}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;
                case "5":
                    if (currentTabIndex == -1)
                    {
                        Console.WriteLine("No tab selected. Open a tab first.");
                        break;
                    }
                    Console.Write("Enter URL to visit: ");
                    string url = Console.ReadLine();
                    browser.GetTab(currentTabIndex).VisitPage(url);
                    Console.WriteLine($"Visited {url}.");
                    break;
                case "6":
                    if (currentTabIndex == -1)
                    {
                        Console.WriteLine("No tab selected.");
                        break;
                    }
                    if (browser.GetTab(currentTabIndex).Back())
                    {
                        Console.WriteLine("Went back.");
                    }
                    else
                    {
                        Console.WriteLine("Cannot go back.");
                    }
                    break;
                case "7":
                    if (currentTabIndex == -1)
                    {
                        Console.WriteLine("No tab selected.");
                        break;
                    }
                    if (browser.GetTab(currentTabIndex).Forward())
                    {
                        Console.WriteLine("Went forward.");
                    }
                    else
                    {
                        Console.WriteLine("Cannot go forward.");
                    }
                    break;
                case "8":
                    if (currentTabIndex == -1)
                    {
                        Console.WriteLine("No tab selected.");
                        break;
                    }
                    Console.WriteLine($"Current page: {browser.GetTab(currentTabIndex).GetCurrentPage()}");
                    break;
                case "9":
                    Console.WriteLine("Open Tabs:");
                    for (int i = 0; i < browser.OpenTabs.Count; i++)
                    {
                        Console.WriteLine($"{i}: {browser.OpenTabs[i].GetCurrentPage()}");
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
