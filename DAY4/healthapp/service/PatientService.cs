using System;
using HealthApp.entity;
using Microsoft.Data.SqlClient;
namespace healthapp.service
{
    public class PatientService
    {
        //Connection String 
        string constring="Server=.\\SQLEXPRESS;Database=healthapp;Trusted_Connection=True;TrustServerCertificate=True;" ;
        // Add Patient
        public void AddPatient(PatientEntity p)
        {
            using (SqlConnection con=new SqlConnection(constring))
            {
                string querry ="insert into patient(PatientName,DateOfBirth,PatientAddress,Gender,Contact) values(@name,@dob,@address,@gender,@contact) ";
                SqlCommand cmd =new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@name",p.PatientName);
                cmd.Parameters.AddWithValue("@dob",p.DateOfBirth);
                cmd.Parameters.AddWithValue("@address",p.PatientAddress);
                cmd.Parameters.AddWithValue("@gender",p.Gender);
                cmd.Parameters.AddWithValue("@contact",p.Contact);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Patient Added Successfully");
            }
        }
        //View Patient
        public void ViewPatient()
        {
            using(SqlConnection con=new SqlConnection(constring))
            {
                string querry="select * from patient";
                SqlCommand cmd=new SqlCommand(querry,con);
                con.Open();
                SqlDataReader reader =cmd.ExecuteReader(); 
                while(reader.Read())
                {
                    Console.WriteLine("ID : "+reader["PatientId"]);
                    Console.WriteLine("Name : "+reader["PatientName"]);
                    Console.WriteLine("DOB : "+reader["DateOfBirth"]);
                    Console.WriteLine("Address : "+reader["PatientAddress"]);
                    Console.WriteLine("Gender : "+reader["Gender"]);
                    Console.WriteLine("Contact : "+reader["Contact"]);
                }
            }
        } 
        // Update Patient
        public void UpdatePatient(PatientEntity p)
        {
            using(SqlConnection con=new SqlConnection(constring))
            {
                string querry="update patient set PatientName=@name,PatientAddress=@address";
                SqlCommand cmd =new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@name",p.PatientName);
                cmd.Parameters.AddWithValue("@address",p.PatientAddress);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Patient updated");
            }
        }
        //Delete Patient
        public void DeletePatient(int id)
        {
            using(SqlConnection con=new SqlConnection(constring))
            {
                string querry="delete from patient where PatientId =@id";
                SqlCommand cmd=new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("PatientEntity deleted");
            }

        } 
    } 
}