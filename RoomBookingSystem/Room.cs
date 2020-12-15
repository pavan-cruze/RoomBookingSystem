using System;
using System.Collections.Generic;
using EmailSender;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem
{
    public class Room
    {
        private int _bookingId;

        private int _memberId;

        private RoomType _roomType;

        private BookingStatus _bookingStatus;

        private DateTime _startDate;

        private DateTime _endDate;

        private int _noOfRooms;

        private double _totalAmount;

        public Room()
        { }

        public Room(int argBookingId, int argMemberId, RoomType argRoomType,
                BookingStatus argBookingStatus, DateTime argStartDate, DateTime argEndDate, int argNoOfRooms)
        {
            this._bookingId = argBookingId;
            this._memberId = argMemberId;
            this._roomType = argRoomType;
            this._bookingStatus = argBookingStatus;
            this.StartDate = argStartDate;
            this.EndDate = argEndDate;
            this.NoOfRooms = argNoOfRooms;
        }

        public override string ToString()
        {
            return string.Format("\n BookingId: {0} \n MemberId: {1}\n Roomtype: {2}\n bookingStatus : {3}\n StartDate : {4}\n EndDate : {5}\n noOfooms: {6}\n "
                        , this._bookingId, this._memberId, this._roomType, this._bookingStatus, this.StartDate, this.EndDate, this.NoOfRooms);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Room rb = (Room)obj;
                return (_bookingId == rb._bookingId) && (_memberId == rb._memberId)
                        && (_roomType == rb._roomType) && (_bookingStatus == rb._bookingStatus)
                        && (StartDate == rb.StartDate) && (EndDate == rb.EndDate)
                        && (NoOfRooms == rb.NoOfRooms) && (TotalAmount == rb.TotalAmount);
            }
        }
        //public override int GetHashCode()
        //{
        //    return _bookingId.GetHashCode() ^
        //        _memberId.GetHashCode() ^
        //        RoomType.GetHashCode() ^
        //        BookingStatus.GetHashCode() ^
        //        StartDate.GetHashCode() ^
        //        EndDate.GetHashCode() ^
        //        NoOfRooms.GetHashCode() ^
        //        TotalAmount.GetHashCode();
        //}
        public int BookingId
        {
            get
            {
                return this._bookingId;
            }
            set
            {
                this._bookingId = BookingId;
            }
        }
        public int MemberId
        {
            get
            {
                return this._memberId;
            }
            set
            {
                this._memberId = MemberId;
            }
        }

        public double TotalAmount { get => _totalAmount; set => _totalAmount = value; }
        public int NoOfRooms { get => _noOfRooms; set => _noOfRooms = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public BookingStatus CurrentBookingStatus { get { return _bookingStatus; } set { _bookingStatus = value; } }
        public RoomType Roomtype { get => _roomType; set => _roomType = value; }
        //internal BookingStatus BookingStatus { get => _bookingStatus; set => _bookingStatus = value; }
        //internal RoomType RoomType { get ; set ; }




        //Author @Pruthvi EmpId-53325.
        public static string BookRoom(int memberid, DateTime startdate, DateTime endDate, string roomtype)
        {
            int price = 0;
            int bookingid = RoomFactory.bookidgen();
            int noofrooms = 1;
            // RoomType type = RoomType.AC_SINGLE;
            //BookingStatus BookingStatus = "PENDING";
            string msg = "Thank you..";
            var cur = DateTime.Now;
            Console.WriteLine(startdate.CompareTo(cur));
            TimeSpan ts = endDate - startdate;
            var days = ts.TotalDays + 1;
            if (startdate.CompareTo(cur) < 0 || endDate.CompareTo(startdate) < 0)
            {
                msg = "Please enter the correct Date";
                return msg;
            }
            else
            {
                if (days >= 1)
                {
                    switch (roomtype)
                    {
                        case "AC_SINGLE":

                            price = 5000;
                            RoomFactory.Pending(new Room(bookingid, memberid, RoomType.AC_SINGLE, BookingStatus.PENDING, startdate, endDate, noofrooms));
                            break;
                        case "AC_DOUBLE":
                            RoomFactory.Pending(new Room(bookingid, memberid, RoomType.AC_DOUBLE, BookingStatus.PENDING, startdate, endDate, noofrooms));
                            price = 10000;
                            break;
                        case "REG_SINGLE":
                            RoomFactory.Pending(new Room(bookingid, memberid, RoomType.REG_SINGLE, BookingStatus.PENDING, startdate, endDate, noofrooms));
                            price = 6000;
                            break;
                        case "REG_DOUBLE":
                            RoomFactory.Pending(new Room(bookingid, memberid, RoomType.REG_DOUBLE, BookingStatus.PENDING, startdate, endDate, noofrooms));
                            price = 9000;
                            break;
                        default:
                            //flag = false;
                            break;
                            //return "Booked";
                    }


                    var totalprice = days * price;
                    Console.WriteLine("You need to pay {0} /- \nTo book this {1}\nFor {2} days\n", totalprice, roomtype, days);
                    GmailClientInfo client = new GmailClientInfo()
                    {
                        GmailUserEmail = "pavancruze3@gmail.com",
                        GmailUserPassword = "pavan.112",
                    };

                    IEmailSender GmailSender = new GmailEmailSender(client);

                    EmailMessage Message = new EmailMessage()
                    {
                        TO = new List<string>() { "pavancruze1@gmail.com" },
                        //, "chippapruthvi@gmail.com", "ramanjan.nelluri@gmail.com"
                        CC = null,
                        Subject = "for your conformation of the room booking",
                        Body = "Greetings of the Day,\nWelcome to Room Booking\n\n As Per Your request the billing amount and all you can get in this mail\n\t\t--------------------------------------------------------------\n\t\tYou need to pay " + totalprice + "To book this For " + days + " days\n\t\t--------------------------------------------------------------",
                        IsBodyHtml = false
                    };

                    EmailSendResult Result = GmailSender.SendEmail(Message);
                    if (Result.IsMessageDelivered)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Email Is Delivered! as per your booking request...");
                        Console.ReadLine();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        string error = string.Format("Email is not delivered due to following error \r\n{0}", Result.Error.Message);
                        Console.WriteLine(error);
                    }


                }
            }
            return msg;
            //Program pg1 = new Program();


        }



        //public static string ConfirmBooking(int argBookingId, string argStatus)
        //{


        //    string msg = "confirming failed";
        //    string curStatus = "PENDING";

        //    try
        //    {
        //        if (argStatus.Equals("RESERVED") || curStatus.Equals("PENDING") || (argStatus.Equals("RESERVED") && curStatus.Equals("UNAVAILABLE")))
        //        {
        //            Console.WriteLine("Booking has been under procees to check \n");
        //            Members m = new Members(1, "Pruthvi", new DateTime(2016, 12, 1), "hyderabad", "pruthvi@gmail.com", 2);
        //            if (m == null)
        //            {

        //                msg = "Booking Confirmed";
        //            }
        //            else if (argStatus.Equals("UNAVAILABLE") && curStatus.Equals("PENDING"))
        //            {
        //                curStatus = argStatus;

        //                msg = "Rooms Unavailable. Booking cancelled";
        //            }
        //            else if ((argStatus.Equals("RESERVED") || curStatus.Equals("RESERVED")) ||
        //              (argStatus.Equals("UNAVAILABLE") && curStatus.Equals("UNAVAILABLE")))
        //            {
        //                msg = "Confirmed So Already on Given Status \n";
        //            }

        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Something went wrong.");
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Succfully updated status");
        //    }
        //    return "for this id: 1 " + msg;
        //}


        public static void PendingBooking()
        {

            Console.WriteLine("-----------------PendingBookings-----------------------");
            Console.WriteLine("Enter the memberid");
            int memid = Convert.ToInt32(Console.ReadLine());
            RoomFactory.memval(memid);

        }
        //public static BookingHistory()
        //{
        //    //Rooms[] pendingList = null;
        //    Console.WriteLine("--------------------------------------------BookingHistory----------------------------------------------");
        //    Console.WriteLine("Enter the memberid");
        //    int memid = Convert.ToInt32(Console.ReadLine());
        //    if (memid != 11)
        //    {
        //        Console.WriteLine("You Dont have any bookings");
        //        Environment.Exit(0);
        //    }

        //    List<Room> numberNames = new List<Room>();
        //    //RoomType AC_DOUBLE = default;
        //    //BookingStatus RESERVED = default;
        //    numberNames.Add(new Room(1, 11, RoomType.AC_DOUBLE, BookingStatus.RESERVED, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5));
        //    numberNames.Add(new Room(2, 11, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));
        //    numberNames.Add(new Room(3, 11, RoomType.AC_DOUBLE, BookingStatus.RESERVED, new DateTime(2020 - 12 - 13), new DateTime(2020 - 12 - 15), 5));
        //    //for(string str in numberNames)
        //    //{
        //    //Console.WriteLine(numberNames.ToString());
        //    //}
        //    foreach (var item in numberNames)
        //    {
        //        //Console.WriteLine("\n BOOKING ID \t MEMBER ID \tRoomType \t\t BookingStatus\t\t StartDate \t\t EndDate \t NoOfRooms");
        //        Console.Write(item._bookingId + "\t " + item._memberId + "\t" + item.Roomtype + "\t" + item._bookingStatus + "\t" + item._startDate + "\t" + item._endDate + "\t" + item._noOfRooms);
        //        Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------\n");

        //    }
        //    return numberNames.ToArray();



        //}
    }
    public enum BookingStatus
    {
        RESERVED,

        UNAVAILABLE,

        PENDING

    }
    public enum RoomType
    {
        AC_SINGLE,

        AC_DOUBLE,

        REG_SINGLE,

        REG_DOUBLE
    }
}
