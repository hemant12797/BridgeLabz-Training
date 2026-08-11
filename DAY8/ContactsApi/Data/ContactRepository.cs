using Microsoft.Data.SqlClient;
using ContactsApi.Models;

namespace ContactsApi.Data;

public class ContactRepository
{
    private readonly string _connectionString;

    public ContactRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // CREATE
    public int Add(Contact contact)
    {
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        string sql = "INSERT INTO Contacts(Name, Email, Phone) VALUES(@Name, @Email, @Phone)";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Name", contact.Name);
        cmd.Parameters.AddWithValue("@Email", contact.Email);
        cmd.Parameters.AddWithValue("@Phone", contact.Phone);

        return cmd.ExecuteNonQuery();
    }

    // READ ALL
    public List<Contact> GetAll()
    {
        List<Contact> contacts = new();

        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT * FROM Contacts";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            contacts.Add(new Contact
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()!,
                Email = reader["Email"].ToString()!,
                Phone = reader["Phone"].ToString()!
            });
        }

        return contacts;
    }

    // READ BY ID
    public Contact? GetById(int id)
    {
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT * FROM Contacts WHERE Id=@Id";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Contact
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()!,
                Email = reader["Email"].ToString()!,
                Phone = reader["Phone"].ToString()!
            };
        }

        return null;
    }

    // UPDATE
    public int Update(Contact contact)
    {
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        string sql = @"
            UPDATE Contacts
            SET Name=@Name,
                Email=@Email,
                Phone=@Phone
            WHERE Id=@Id";

        using SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@Id", contact.Id);
        cmd.Parameters.AddWithValue("@Name", contact.Name);
        cmd.Parameters.AddWithValue("@Email", contact.Email);
        cmd.Parameters.AddWithValue("@Phone", contact.Phone);

        return cmd.ExecuteNonQuery();
    }

    // DELETE
    public int Delete(int id)
    {
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        string sql = "DELETE FROM Contacts WHERE Id=@Id";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);

        return cmd.ExecuteNonQuery();
    }
}