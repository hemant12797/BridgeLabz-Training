using System;
using HealthApp.entity;
using Microsoft.Data.SqlClient;
namespace healthapp.service
{
    public class DoctorService
    {
        //Connection String 
        string constring="Server=.\\SQLEXPRESS;Database=healthapp;Trusted_Connection=True;TrustServerCertificate=True;" ;
        // Add Doctor
        public void AddDoctor(DoctorEntity d)
        {
            using (SqlConnection con=new SqlConnection(constring))
            {
                string querry ="insert into doctor(DoctorName,YearsOfExperience,Specialization,Contact) values(@name,@yoe,@Specialization,@contact) ";
                SqlCommand cmd =new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@name",d.DoctorName);
                cmd.Parameters.AddWithValue("@yoe",d.YearsOfExperience);
                cmd.Parameters.AddWithValue("@Specialization",d.Specialization);
                cmd.Parameters.AddWithValue("@contact",d.Contact);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Doctor Added Successfully");
            }
        }
        //View Doctor
        public void ViewDoctor()
        {
            using(SqlConnection con=new SqlConnection(constring))
            {
                string querry="select * from doctor";
                SqlCommand cmd=new SqlCommand(querry,con);
                con.Open();
                SqlDataReader reader =cmd.ExecuteReader(); 
                while(reader.Read())
                {
                    Console.WriteLine("ID : "+reader["DoctorId"]);
                    Console.WriteLine("Name : "+reader["DoctorName"]);
                    Console.WriteLine("yoe : "+reader["YearOfExperience"]);
                    Console.WriteLine("Specialization : "+reader["Specialization"]);
                    Console.WriteLine("Contact : "+reader["Contact"]);
                }
            }
        } 
        // Update Doctor
        public void UpdateDoctor(DoctorEntity d)
        {
            using(SqlConnection con=new SqlConnection(constring))
            {
                string querry="update doctor set DoctorName=@name,YearOfExperience=@yoe,Specialization=@Specialization,Contact=@contact where DoctorId=@id";
                SqlCommand cmd =new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@name",d.DoctorName);
                cmd.Parameters.AddWithValue("@yoe",d.YearsOfExperience);
                cmd.Parameters.AddWithValue("@Specialization",d.Specialization);
                cmd.Parameters.AddWithValue("@contact",d.Contact);
                cmd.Parameters.AddWithValue("@id",d.DoctorId);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Doctor updated");
            }
        }
        //Delete Doctor
        public void DeleteDoctor(int id)
        {
            using(SqlConnection con=new SqlConnection(constring))
            {
                string querry="delete from doctor where DoctorId =@id";
                SqlCommand cmd=new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Doctor deleted");
            }

        } 
    } 
}