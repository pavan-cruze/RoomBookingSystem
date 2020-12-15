using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem
{
    class FileRw
    {
        public static bool Writer(Members mm)
        {
            bool successflag = false;
            var filePath = @"C:\Users\raman\Desktop\Registration.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {


                    sw.WriteLine("----------------------------------------Registration Form for RBS-------------------------------------------------------");

                    sw.WriteLine("MemberName: " + mm.MemberName + "\n" + "MembershipDate:" + mm.MembershipDate + "\n" + "Address:" + mm.Address + "\n" + "EmailAddress :" + mm.EmailAddress + "\n" + "AvailableBookings:" + mm.AvailableBookings);
                    //sw.WriteLine("Booking id: " +  + "\n" + "MembershipDate:" + mm.MembershipDate + "\n" + "Address:" + mm.Address + "\n" + "EmailAddress :" + mm.EmailAddress + "\n" + "AvailableBookings:" + mm.AvailableBookings);


                    {

                    }
                    successflag = true;
                    return successflag;

                }
            }
        }
        public static bool Writer(Room rb)
        {
            bool successflag = false;
            var filePath = @"C:\Users\raman\Desktop\Registration.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {


                    sw.WriteLine("----------------------------------------PENDING LIST-------------------------------------------------------");

                    sw.WriteLine("BookingID: " + rb.BookingId + "\n" + "MemberId:" + rb.MemberId + "\n" + "RoomType:" + rb.Roomtype + "\n" + "Booking Statu :" + rb.CurrentBookingStatus + "\n" + "startDate" + rb.StartDate +"\n"+ "EndDate:"+rb.EndDate+"\n"+"NoOfRooms:"+rb.NoOfRooms);
                    //sw.WriteLine("Booking id: " +  + "\n" + "MembershipDate:" + mm.MembershipDate + "\n" + "Address:" + mm.Address + "\n" + "EmailAddress :" + mm.EmailAddress + "\n" + "AvailableBookings:" + mm.AvailableBookings);


                    {

                    }
                    successflag = true;
                    return successflag;

                }
            }
        }
    }
}
