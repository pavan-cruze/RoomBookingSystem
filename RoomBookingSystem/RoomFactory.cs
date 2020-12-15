using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem
{
    public class RoomFactory
    {
        public static List<Room> roomdata = new List<Room>();
        
        public static int x;
        public static BookingStatus Pending(Room r)
        {
            roomdata.Add(new Room(1, 101, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5));
            roomdata.Add(new Room(2, 102, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5));

            roomdata.Add(r);

            return r.CurrentBookingStatus;
        }
        public static string BookingHistory()
        {

            foreach (Room K in roomdata)
            {
                Console.WriteLine(K.ToString());
                //  Console.WriteLine("do you want to Registration copy ");
                //char c = Convert.ToChar(Console.ReadLine());
                //if (c == 'y')
                //{
                //    bool flag1 = FileRw.Writer(new Room(K.BookingId, K.MemberId, K.Roomtype, K.CurrentBookingStatus, K.StartDate, K.EndDate, K.NoOfRooms));

                //    if (flag1)
                //    {
                //        Console.WriteLine("success");
                //    }
                //    ////bool flag = FileRw.Writer(new Room(K.BookingId, K.MemberId, K.Roomtype, K.CurrentBookingStatus, K.StartDate, K.EndDate, K.NoOfRooms));

                //}
              
            }
            return roomdata.ToString();
        }

        public static int bookidgen()
        {
            x = x + 1;
            return x;
        }

        public static void memval(int memid)
        {
            bool flag1 = false;
            int count = 0;
            foreach (var k in roomdata)
            {
                if (k.MemberId == memid)
                {
                    flag1 = true;
                }
            }

            try
            {
                if (flag1 == false)
                {
                    throw new NullReferenceException();
                }


            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(" Sorry you dont have bookings");
                Environment.Exit(0);
            }
            foreach (var k in roomdata)
            {
                if (k.MemberId == memid && k.CurrentBookingStatus == BookingStatus.PENDING)
                {
                    Console.WriteLine(k.ToString());
                    count++;

                }

            }
            if (count == 0)
            {
                Console.WriteLine("You dont havae any bookings");
            }

        }

        public static string Setstatus(int bid, BookingStatus str)
        {
            // BookingStatus a = BookingStatus.UNAVAILABLE;
            // BookingStatus s = BookingStatus.RESERVED;
            //Console.WriteLine("hello");
            //int i = (int)str;
            //Console.WriteLine(str);
            string msg = "setting status";
            foreach (var k in roomdata)
            {
               // Console.WriteLine("hello");
                if (k.BookingId == bid)
                {
                    //Console.WriteLine("hello22");
                    switch (str)
                    {

                        case BookingStatus.UNAVAILABLE:
                            
                                Console.WriteLine("hello2");
                                k.CurrentBookingStatus = BookingStatus.UNAVAILABLE;
                                msg = "Sorry booking cancled,Unaviable";
                                Console.WriteLine(msg);
                                BookingHistory();
                                //return msg;
                                break;
                        
                        case BookingStatus.RESERVED:
                            
                                k.CurrentBookingStatus = BookingStatus.RESERVED;
                                msg = "booking succufully confirmed";
                                 Console.WriteLine(msg);
                                BookingHistory();
                                //return msg;
                               break;
                            
                    }
                    
                }

                ////BookingHistory();
            }
            
            
            return msg;
        }

    }
}