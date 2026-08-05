using System;
using HealthApp.entity;
using Microsoft.Data.SqlClient;
namespace healthapp.service
{
    public class AppointmentService{
        // Connection String 
        string constring="Server=.\\SQLEXPRESS;Database=healthapp;Trusted_Connection=True;TrustServerCertificate=true";
        // Book Appointment
        public void BookAppointment(AppointmentEntity appointment)
        {
            using(SqlConnection con = new SqlConnection(constring))
            {
                string query = @"INSERT INTO appointment
                (DoctorId, PatientId, AppointmentStatus, AppointmentDate, TimeSlot)
                VALUES
                (@DoctorId, @PatientId, @Status, @Date, @Time)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@Status", appointment.AppointmentStatus);
                cmd.Parameters.AddWithValue("@Date", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@Time", appointment.TimeSlot);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Appointment Booked Successfully");
            }
        }
        //Delete Appointment
        public void DeleteAppointment(int appointmentId)
        {
            using(SqlConnection con = new SqlConnection(constring))
            {
                string query = "DELETE FROM appointment WHERE AppointmentId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", appointmentId);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Appointment Deleted");
            }
        } 
        
    }
}