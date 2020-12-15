using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static RoomBookingSystem.Room;

namespace RoomBookingSystem
{
    class Program
    {
        //public static IDictionary<int, Members> dict;
        public static int memid;
        //public static Members m5;
        public static List<Members> memlist = new List<Members>();

        Program pg = new Program();


        static void Main(string[] args)
        {

            menu();

        }

        public static void menu()
        {
            Console.WriteLine("------------------RoomBooking System--------------------------------------");
            Console.WriteLine("\n 1. Admin \n 2. User");
            int inval = Convert.ToByte(Console.ReadLine());
            Console.Clear();
            switch (inval)
            {
                case 1:
                    Console.WriteLine("\nWelcome admin\n");
                    Console.WriteLine("1. ConfirmBooking \n2. ListallBookings \n3.Pending bookings \n4.Listallmembers");

                    int sel = Convert.ToByte(Console.ReadLine());
                    switch (sel)
                    {
                        case 1:
                            approve();
                            menu();
                            break;
                        case 2:
                            listAllBookings();
                            menu();
                            break;
                        case 3:
                            PendingBooking();
                            menu();
                            break;
                        case 4:
                            listallmembers();
                            menu();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("\nWelcome user\n");
                    Console.WriteLine("\n1.BookRoom \n2.NewUser Registration \n3.BookingHistory \n4.Exit");
                    int usel = Convert.ToByte(Console.ReadLine());
                    switch (usel)
                    {
                        case 1:
                            bookRoom();
                            menu();

                            break;
                        case 2:
                            newmember();
                            menu();
                            break;
                        case 5:
                            System.Environment.Exit(1);
                            break;
                        case 3:
                            RoomFactory.BookingHistory();
                            menu();
                            break;

                    }
                    break;
            }
        }



        //Author @Pruthvi EmpId-53325.
        public static void memberfactory()
        {
            Members[] m = new Members[5];
            m[0] = new Members(101, "Pruthvi CH", new DateTime(2013, 12, 21), "Hyderabad", "Pruthvi@gmail.com", 10);
            m[1] = new Members(102, "Dhoni", new DateTime(2011, 12, 21), "Ranchi", "Dhoni@gmail.com", 1);
            m[2] = new Members(103, "Virat", new DateTime(2013, 12, 21), "Delhi", "virat@gmail.com", 12);
            m[3] = new Members(104, "Rohit", new DateTime(2015, 12, 21), "Mumbai", "Rohit@gmail.com", 2);

            memlist.Add(m[0]);
            memlist.Add(m[1]);
            memlist.Add(m[2]);
            memlist.Add(m[3]);
            //dict = new Dictionary<int, Members>();
            //dict.Add(122, m[0]);
            //dict.Add(777, m[1]);
            //dict.Add(3212, m[2]);
            //dict.Add(312, m[3]);




        }

        //Author @Pruthvi EmpId-53325.
        private static void bookRoom()
        {
            bool Flag = false;
            memberfactory();
            Console.Clear();
            Console.WriteLine("Enter your Accountid");

            memid = Convert.ToInt32(Console.ReadLine());

            foreach (var k in memlist)
            {
                if (k.MemberID == memid)
                {
                    Flag = true;
                }
            }

            try
            {
                if (Flag == false)
                {
                    throw new NullReferenceException();
                }


            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(" Sorry you cant book room");
                Environment.Exit(0);
            }
            Console.WriteLine("---------------------------------------------Welcome! Start Booking :)----------------------------------------------------   ");
            Console.WriteLine("enter the start date");
            DateTime startdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("enter the end date");
            DateTime enddate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("select room type AC_SINGLE / AC_DOUBLE / REG_SINGLE / REG_DOUBLE");
            string type = Console.ReadLine();
            string str2 = Room.BookRoom(memid, startdate, enddate, type);
            Console.WriteLine(str2);
            menu();


        }


        ////Author @Pruthvi EmpId-53325.
        public static void newmember()
        {
            Console.WriteLine("Memberid");
            int newmemid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your name");
            string newmem = Console.ReadLine();
            Console.WriteLine("Enter date");
            DateTime newdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter your Location");
            string newlocation = Console.ReadLine();
            Console.WriteLine("Enter your Email id");
            string newemail = Console.ReadLine();
            int ava = 15;
            memlist.Add(new Members(newmemid, newmem, newdate, newlocation, newemail, ava));
            Console.WriteLine("Registered Sucessfully");

            //try
            //{

            //   // m5 = new Members(newmemid, newmem, newdate, newlocation, newemail, ava);
            //    memlist.Add(new Members(newmemid, newmem, newdate, newlocation, newemail, ava));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Registered Sucessfully");
            //    //Console.WriteLine(m5.ToString());
            //}



            Console.WriteLine("do you want to Registration copy ");
            char c = Convert.ToChar(Console.ReadLine());
            if (c == 'y')
            {
                bool flag = FileRw.Writer(new Members(newmemid, newmem, newdate, newlocation, newemail, ava));

                if (flag)
                {
                    Console.WriteLine("success");
                }
            }
            //listallmembers();
            // Console.ReadLine();
            menu();

        }

        //author @pruthvi
        public static void listallmembers()
        {
            memberfactory();
            foreach (var a in memlist)
            {
                Console.WriteLine(a.ToString());
            }
            menu();
        }


        private static void approve()
        {

            Console.WriteLine("\n -----------------Confirm/Reject the bookings-----------------------");
            RoomFactory.BookingHistory();
            Console.WriteLine("\n Enter the booking Id to Approve:");
            int ch1 = Convert.ToInt32(Console.ReadLine());
 //           bool Flag = false;
           

            Console.WriteLine("\n set as the bookingstatus to  1.Unavailable 2.Reserved");
            int ch = Convert.ToInt32(Console.ReadLine());
            //string msg = "confirming failed";
            //BookingStatus fStatus = BookingStatus.UNAVAILABLE;
            //BookingStatus fStatus1 = BookingStatus.RESERVED;
            switch (ch)
            {
                case 1:

                    RoomFactory.Setstatus(ch1, BookingStatus.UNAVAILABLE);
                    break;
                case 2:
                    RoomFactory.Setstatus(ch1, BookingStatus.RESERVED);
                    break;
                default:

                    break;
            }

           
            //Console.WriteLine(str);
            //Console.WriteLine(str1);
            //menu();
        }


        private static void listAllBookings()
        {
            Console.WriteLine("-----------------ListAllbookingsDsiplay-----------------------");
            List<Room> numberNames = new List<Room>();
            //RoomType AC_DOUBLE = default;
            //BookingStatus PENDING = default;
            numberNames.Add(new Room(1, 10, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5));
            numberNames.Add(new Room(1, 11, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));
            numberNames.Add(new Room(2, 13, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));
            numberNames.Add(new Room(2, 14, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));
            numberNames.Add(new Room(3, 15, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));
            numberNames.Add(new Room(3, 16, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));

            //for(string str in numberNames)
            //{
            //Console.WriteLine(numberNames.ToString());
            //}
            foreach (var item in numberNames)
            {
                Console.Write(" ");
                // Console.WriteLine("\n \t BOOKING ID \t\t MEMBER ID \t\t RoomType \t\t BookingStatus\t\t StartDate \t\t EndDate \t NoOfRooms");
                Console.Write(item);
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------\n"); ;
            };
            menu();
        }



    }
}