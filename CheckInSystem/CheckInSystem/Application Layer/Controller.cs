using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Net.Mail;
using CheckInSystem.Domain_Layer;

namespace CheckInSystem.Application_Layer
{
    public class Controller
    {
        public string CurrentPersonName { get; set; }
        public CheckInRepo CheckInRepo = new CheckInRepo();
        public EmployeeRepo employeesRepo = new EmployeeRepo();
        public GuestRepo guestRepo = new GuestRepo();
        public AppointmentRepo appointmentRepo = new AppointmentRepo();
        public Person CurrentPerson;
        
        public bool VerifyPin(string pinCode)
        {
            //Checks if the parameter pinCode matches PinCode property in employees list.            
            foreach(Employee employee in employeesRepo.employees)
            {
                if (pinCode == employee.PinCode)
                {
                    CurrentPerson = new Employee();
                    CurrentPerson = employee;

                    return true;
                }               
            }
            return false;          
        }

        public void AssignMood(Mood mood)
        {
            CheckIn newCheckIn = new CheckIn();
            newCheckIn.mood = mood;
            newCheckIn.person = CurrentPerson;
            CheckInRepo.CheckIn(newCheckIn);
        }

        public void AssignGuestCheckIn()
        {
            CurrentPerson = new Guest();            
            CheckIn newCheckIn = new CheckIn();
            newCheckIn.person = CurrentPerson;
            CheckInRepo.CheckIn(newCheckIn);
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void SendMail(string toEmail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                //From mail
                mail.From = new MailAddress("ras_jebril@hotmail.com");
                //Target mail
                mail.To.Add(toEmail);
                mail.Subject = "Hydac bygning - Brandsikkerheds brochure";
                mail.Body = "This is for testing SMTP mail from Hotmail";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ras_jebril@hotmail.com", "KODE HER");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
