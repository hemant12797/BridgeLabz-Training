using HealthApp.entity;
using healthapp.service;

namespace healthapp.menu
{
    public class MainMenu
    {
        DoctorService doctorService = new DoctorService();
        PatientService patientService = new PatientService();
        AppointmentService appointmentService = new AppointmentService();


        public void ShowMenu()
        {
            while(true)
            {
                Console.WriteLine("\n===== HEALTH APP =====");
                Console.WriteLine("1. Doctor");
                Console.WriteLine("2. Patient");
                Console.WriteLine("3. Appointment");
                Console.WriteLine("4. Exit");

                Console.Write("Enter Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch(choice)
                {
                    case 1:
                        DoctorSection();
                        break;

                    case 2:
                        PatientSection();
                        break;

                    case 3:
                        AppointmentSection();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }



        // ================= DOCTOR =================

        public void DoctorSection()
        {
            while(true)
            {
                Console.WriteLine("\n===== DOCTOR MENU =====");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Delete Doctor");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. View Doctor");
                Console.WriteLine("5. Exit");


                Console.Write("Enter Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch(choice)
                {
                    case 1:

                        DoctorEntity doctor = new DoctorEntity();

Console.Write("Doctor Name : ");
                        doctor.DoctorName = Console.ReadLine() ?? "";

                        Console.Write("Experience : ");
                        doctor.YearsOfExperience =
                            Convert.ToInt32(Console.ReadLine());

Console.Write("Specialization : ");
                        doctor.Specialization =
                            Console.ReadLine() ?? "";

                        Console.Write("Contact : ");
                        doctor.Contact =
                            Console.ReadLine() ?? "";


                        doctorService.AddDoctor(doctor);

                        break;


                    case 2:

                        Console.Write("Doctor Id : ");
                        int doctorId =
                        Convert.ToInt32(Console.ReadLine());

                        doctorService.DeleteDoctor(doctorId);

                        break;


                    case 3:

                        DoctorEntity updateDoctor = new DoctorEntity();


                        Console.Write("Doctor Id : ");
                        updateDoctor.DoctorId =
                        Convert.ToInt32(Console.ReadLine());


Console.Write("Doctor Name : ");
                        updateDoctor.DoctorName =
                        Console.ReadLine() ?? "";


                        Console.Write("Experience : ");
                        updateDoctor.YearsOfExperience =
                        Convert.ToInt32(Console.ReadLine());


Console.Write("Specialization : ");
                        updateDoctor.Specialization =
                        Console.ReadLine() ?? "";


                        Console.Write("Contact : ");
                        updateDoctor.Contact =
                        Console.ReadLine() ?? "";


                        doctorService.UpdateDoctor(updateDoctor);

                        break;


                    case 4:

                        doctorService.ViewDoctor();

                        break;


                    case 5:

                        return;


                    default:

                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }




        // ================= PATIENT =================


        public void PatientSection()
        {
            while(true)
            {
                Console.WriteLine("\n===== PATIENT MENU =====");

                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Delete Patient");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. View Patient");
                Console.WriteLine("5. Exit");


                Console.Write("Enter Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch(choice)
                {

                    case 1:

                        PatientEntity patient = new PatientEntity();


Console.Write("Patient Name : ");
                        patient.PatientName =
                        Console.ReadLine() ?? "";


                        Console.Write("Date Of Birth (yyyy-mm-dd) : ");
                        patient.DateOfBirth =
                        Convert.ToDateTime(Console.ReadLine());


                        Console.Write("Address : ");
                        patient.PatientAddress =
                        Console.ReadLine() ?? "";


                        Console.Write("Gender : ");
                        patient.Gender =
                        Console.ReadLine() ?? "";


                        Console.Write("Contact : ");
                        patient.Contact =
                        Console.ReadLine() ?? "";


                        patientService.AddPatient(patient);

                        break;



                    case 2:

                        Console.Write("Patient Id : ");

                        int patientId =
                        Convert.ToInt32(Console.ReadLine());


                        patientService.DeletePatient(patientId);

                        break;



                    case 3:

                        PatientEntity updatePatient = new PatientEntity();


                        Console.Write("Patient Id : ");
                        updatePatient.PatientId =
                        Convert.ToInt32(Console.ReadLine());


Console.Write("Name : ");
                        updatePatient.PatientName =
                        Console.ReadLine() ?? "";


                        Console.Write("DOB : ");
                        updatePatient.DateOfBirth =
                        Convert.ToDateTime(Console.ReadLine());


Console.Write("Address : ");
                        updatePatient.PatientAddress =
                        Console.ReadLine() ?? "";


                        Console.Write("Gender : ");
                        updatePatient.Gender =
                        Console.ReadLine() ?? "";


Console.Write("Contact : ");
                        updatePatient.Contact =
                        Console.ReadLine() ?? "";


                        patientService.UpdatePatient(updatePatient);

                        break;



                    case 4:

                        patientService.ViewPatient();

                        break;



                    case 5:

                        return;


                    default:

                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }





        // ================= APPOINTMENT =================


        public void AppointmentSection()
        {
            while(true)
            {
                Console.WriteLine("\n===== APPOINTMENT MENU =====");

                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. Delete Appointment");
                Console.WriteLine("3. Exit");


                Console.Write("Enter Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());



                switch(choice)
                {

                    case 1:

                        AppointmentEntity appointment =
                        new AppointmentEntity();



                        Console.Write("Doctor Id : ");
                        appointment.DoctorId =
                        Convert.ToInt32(Console.ReadLine());


                        Console.Write("Patient Id : ");
                        appointment.PatientId =
                        Convert.ToInt32(Console.ReadLine());


                        Console.Write("Appointment Date : ");
                        appointment.AppointmentDate =
                        Convert.ToDateTime(Console.ReadLine());


Console.Write("Time Slot (HH:mm) : ");
                        appointment.TimeSlot =
                        TimeSpan.Parse(Console.ReadLine() ?? "");


                        appointmentService.BookAppointment(appointment);


                        break;



                    case 2:

                        Console.Write("Appointment Id : ");

                        int appointmentId =
                        Convert.ToInt32(Console.ReadLine());


                        appointmentService.DeleteAppointment(appointmentId);

                        break;



                    case 3:

                        return;



                    default:

                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}