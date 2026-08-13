using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using AdvancedAddressBook.Models;

namespace AdvancedAddressBook.Repositories
{
    public class AddressBookRepository
    {
        private string connectionString = "Server=.\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private string masterConnectionString = "Server=.\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        // Initialize database - create if not exists
        public void InitializeDatabase()
        {
            // First, try to create the database if it doesn't exist
            using (SqlConnection conn = new SqlConnection(masterConnectionString))
            {
                string createDbQuery = @"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AddressBookDB')
                                        BEGIN
                                            CREATE DATABASE AddressBookDB
                                        END";
                SqlCommand cmd = new SqlCommand(createDbQuery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Now create tables if they don't exist
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create AddressBook table
                string createAddressBookTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AddressBook')
                    BEGIN
                        CREATE TABLE AddressBook
                        (
                            AddressBookId INT PRIMARY KEY IDENTITY(1,1),
                            AddressBookName VARCHAR(100) NOT NULL,
                            CreatedDate DATETIME DEFAULT GETDATE()
                        )
                    END";

                // Create Contacts table
                string createContactsTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Contacts')
                    BEGIN
                        CREATE TABLE Contacts
                        (
                            ContactId INT PRIMARY KEY IDENTITY(1,1),
                            AddressBookId INT,
                            FirstName VARCHAR(50) NOT NULL,
                            LastName VARCHAR(50),
                            Address VARCHAR(200),
                            City VARCHAR(50),
                            State VARCHAR(50),
                            ZipCode VARCHAR(10),
                            PhoneNumber VARCHAR(15),
                            Email VARCHAR(100),
                            FOREIGN KEY (AddressBookId) REFERENCES AddressBook(AddressBookId)
                        )
                    END";

                SqlCommand cmd1 = new SqlCommand(createAddressBookTable, conn);
                SqlCommand cmd2 = new SqlCommand(createContactsTable, conn);

                conn.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                // Insert default address book if not exists
                string insertDefault = @"
                    IF NOT EXISTS (SELECT * FROM AddressBook)
                    BEGIN
                        INSERT INTO AddressBook (AddressBookName) VALUES ('Default')
                    END";
                SqlCommand cmd3 = new SqlCommand(insertDefault, conn);
                cmd3.ExecuteNonQuery();
            }
        }

        // Insert a new contact
        public void InsertContact(Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Contacts
                (AddressBookId, FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email)
                VALUES (@AddressBookId, @FirstName, @LastName, @Address, @City, @State, @ZipCode, @PhoneNumber, @Email)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AddressBookId", contact.AddressBookId);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", contact.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@City", contact.City ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@State", contact.State ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ZipCode", contact.ZipCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", contact.Email ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get all contacts
        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        ContactId = Convert.ToInt32(reader["ContactId"]),
                        AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return contacts;
        }

        // Delete contact by first name
        public void DeleteContact(string firstName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Contacts WHERE FirstName=@FirstName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Edit/Update existing contact
        public void UpdateContact(Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Contacts SET 
                    FirstName = @FirstName,
                    LastName = @LastName,
                    Address = @Address,
                    City = @City,
                    State = @State,
                    ZipCode = @ZipCode,
                    PhoneNumber = @PhoneNumber,
                    Email = @Email
                    WHERE ContactId = @ContactId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ContactId", contact.ContactId);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", contact.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@City", contact.City ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@State", contact.State ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ZipCode", contact.ZipCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", contact.Email ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Create a new Address Book
        public void CreateAddressBook(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AddressBook (AddressBookName) VALUES (@Name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get all Address Books
        public List<Dictionary<string, object>> GetAllAddressBooks()
        {
            List<Dictionary<string, object>> addressBooks = new List<Dictionary<string, object>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM AddressBook";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var addressBook = new Dictionary<string, object>
                    {
                        { "AddressBookId", Convert.ToInt32(reader["AddressBookId"]) },
                        { "AddressBookName", reader["AddressBookName"].ToString() },
                        { "CreatedDate", reader["CreatedDate"].ToString() }
                    };
                    addressBooks.Add(addressBook);
                }
            }

            return addressBooks;
        }

        // List all contacts in a city or state
        public List<Contact> GetContactsByCityOrState(string city, string state)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Contacts 
                                 WHERE City = @City OR State = @State";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        ContactId = Convert.ToInt32(reader["ContactId"]),
                        AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return contacts;
        }

        // Search contact by first name and city or state
        public List<Contact> SearchContactByNameAndCityOrState(string firstName, string city, string state)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Contacts 
                                 WHERE FirstName = @FirstName AND (City = @City OR State = @State)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        ContactId = Convert.ToInt32(reader["ContactId"]),
                        AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return contacts;
        }

        // Count contacts in a city or state
        public int CountContactsByCityOrState(string city, string state)
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM Contacts 
                                 WHERE City = @City OR State = @State";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);

                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return count;
        }

        // Get contact by ID
        public Contact GetContactById(int contactId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts WHERE ContactId = @ContactId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ContactId", contactId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Contact
                    {
                        ContactId = Convert.ToInt32(reader["ContactId"]),
                        AddressBookId = Convert.ToInt32(reader["AddressBookId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        ZipCode = reader["ZipCode"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }

            return null;
        }
    }
}
