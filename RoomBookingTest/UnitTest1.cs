using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
//using NUnit.Framework;
using RoomBookingSystem;
using System.Runtime.Remoting.Contexts;
using System.Collections;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace RoomBookingTest
{
    [TestClass]
    [TestFixture]
   
    public class UnitTest1
    {
        [TestMethod]
        public void pending_test__for_User()
        {
            
            Room rt = new Room(1, 11, RoomType.AC_DOUBLE, BookingStatus.RESERVED, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5);
            //RoomFactory rf = new RoomFactory();
            BookingStatus st = RoomBookingSystem.RoomFactory.Pending(rt);

            Assert.AreNotEqual(BookingStatus.PENDING, st);
            
        }
        [TestMethod]

        public void setstatusTest()
        {
            //Room rt = new Room(1, 101, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5);
            RoomBookingSystem.RoomFactory.Pending(new Room(1, 101, RoomType.AC_DOUBLE, BookingStatus.PENDING, new DateTime(2020 - 12 - 12), new DateTime(2020 - 12 - 15), 5));
            string st = RoomBookingSystem.RoomFactory.Setstatus(1, BookingStatus.RESERVED);
            string st1 = RoomBookingSystem.RoomFactory.Setstatus(1, BookingStatus.UNAVAILABLE);
            Assert.AreEqual("booking succufully confirmed", st);
            Assert.AreEqual("Sorry booking cancled,Unaviable", st1);
        }
        [TestMethod]
        public void BookRoomTest()
        {
            String ac = "AC_SINGLE";
            String actualstr1 = RoomBookingSystem.Room.BookRoom(102, new DateTime(2021, 01, 17), new DateTime(2021, 01, 23), ac);
            Assert.AreEqual("Booking Accepted. Under Consideration", actualstr1);
            String actualstr2 = RoomBookingSystem.Room.BookRoom(102, new DateTime(2020, 01, 17), new DateTime(2021, 01, 23), ac);
            Assert.AreEqual("Please enter the correct Date", actualstr2);
            String actualstr3 = RoomBookingSystem.Room.BookRoom(102, new DateTime(2021, 01, 17), new DateTime(2021, 01, 02), ac);
            Assert.AreEqual("Please enter the correct Date", actualstr3);
        }


    }
}
