using System;
using System.Collections.Generic;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<int> FriendIDs { get; set; }

    public User(int userID, string name, int age)
    {
        UserID = userID;
        Name = name;
        Age = age;
        FriendIDs = new List<int>();
    }
}

public class Node
{
    public User Data { get; set; }
    public Node Next { get; set; }

    public Node(User data)
    {
        Data = data;
        Next = null;
    }
}

public class SinglyLinkedList
{
    private Node head;

    public SinglyLinkedList()
    {
        head = null;
    }

    // Add user at end
    public void AddUser(User user)
    {
        Node newNode = new Node(user);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Add friend connection
    public void AddFriendConnection(int userID1, int userID2)
    {
        User user1 = FindUserByID(userID1);
        User user2 = FindUserByID(userID2);
        if (user1 != null && user2 != null)
        {
            if (!user1.FriendIDs.Contains(userID2))
            {
                user1.FriendIDs.Add(userID2);
            }
            if (!user2.FriendIDs.Contains(userID1))
            {
                user2.FriendIDs.Add(userID1);
            }
            Console.WriteLine("Friend connection added");
        }
        else
        {
            Console.WriteLine("One or both users not found");
        }
    }

    // Remove friend connection
    public void RemoveFriendConnection(int userID1, int userID2)
    {
        User user1 = FindUserByID(userID1);
        User user2 = FindUserByID(userID2);
        if (user1 != null && user2 != null)
        {
            user1.FriendIDs.Remove(userID2);
            user2.FriendIDs.Remove(userID1);
            Console.WriteLine("Friend connection removed");
        }
        else
        {
            Console.WriteLine("One or both users not found");
        }
    }

    // Find mutual friends
    public List<int> FindMutualFriends(int userID1, int userID2)
    {
        User user1 = FindUserByID(userID1);
        User user2 = FindUserByID(userID2);
        if (user1 != null && user2 != null)
        {
            List<int> mutual = new List<int>();
            foreach (int friend in user1.FriendIDs)
            {
                if (user2.FriendIDs.Contains(friend))
                {
                    mutual.Add(friend);
                }
            }
            return mutual;
        }
        return new List<int>();
    }

    // Display friends of a user
    public void DisplayFriends(int userID)
    {
        User user = FindUserByID(userID);
        if (user != null)
        {
            Console.WriteLine($"Friends of {user.Name}:");
            foreach (int friendID in user.FriendIDs)
            {
                User friend = FindUserByID(friendID);
                if (friend != null)
                {
                    Console.WriteLine($"{friend.Name} (ID: {friend.UserID})");
                }
            }
        }
        else
        {
            Console.WriteLine("User not found");
        }
    }

    // Search user by Name
    public User SearchByName(string name)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Name == name)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Search user by User ID
    public User FindUserByID(int userID)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.UserID == userID)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Count friends for each user
    public void CountFriendsForAll()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"{current.Data.Name} has {current.Data.FriendIDs.Count} friends");
            current = current.Next;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        // Add some users
        list.AddUser(new User(1, "Alice", 25));
        list.AddUser(new User(2, "Bob", 30));
        list.AddUser(new User(3, "Charlie", 28));

        // Add connections
        list.AddFriendConnection(1, 2);
        list.AddFriendConnection(1, 3);

        // Display friends
        list.DisplayFriends(1);

        // Find mutual friends
        List<int> mutual = list.FindMutualFriends(2, 3);
        Console.WriteLine($"Mutual friends: {string.Join(", ", mutual)}");

        // Search
        User found = list.SearchByName("Bob");
        if (found != null)
        {
            Console.WriteLine($"Found user: {found.Name}");
        }

        // Count friends
        list.CountFriendsForAll();

        // Remove connection
        list.RemoveFriendConnection(1, 2);

        Console.WriteLine("After removal:");
        list.DisplayFriends(1);
    }
}
