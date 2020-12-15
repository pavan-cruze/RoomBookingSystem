using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author @Pruthvi EmpId-53325.

namespace RoomBookingSystem
{
    class Members
    {
        private int _memberId;
        private String _memberName;
        private DateTime _membershipDate;
        private String _address;
        private String _emailAddress;
        private int _availableBookings;

        public int MemberID
        {
            get
            {
                return this._memberId;
            }
            set
            {
                this._memberId = value;
            }
        }

        public String MemberName
        {
            get
            {
                return this._memberName;
            }
            set
            {
                this._memberName = value;
            }
        }


        public DateTime MembershipDate
        {
            get
            {
                return this._membershipDate;
            }
            set
            {
                this._membershipDate = value;
            }
        }


        public String Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }


        public String EmailAddress
        {
            get
            {
                return this._emailAddress;
            }
            set
            {
                this._emailAddress = value;
            }
        }


        public int AvailableBookings
        {
            get
            {
                return this._availableBookings;
            }
            set
            {
                this._availableBookings = value;

            }
        }

        //public int MemberId { get => _memberId; set => _memberId = value; }
        //public string MemberName { get => _memberName; set => _memberName = value; }
        //public DateTime MembershipDate { get => _membershipDate; set => _membershipDate = value; }
        //public string Address { get => _address; set => _address = value; }
        //public string EmailAddress { get => _emailAddress; set => _emailAddress = value; }
        //public int AvailableBookings { get => _availableBookings; set => _availableBookings = value; }

        public Members(int argMemberId, String argMemberName, DateTime argMembershipDate, String argAddress, String argEmailAddress,
                           int argAvailableBookings)
        {
            this._memberId = argMemberId;
            this._memberName = argMemberName;
            this._membershipDate = argMembershipDate;
            this._address = argAddress;
            this._emailAddress = argEmailAddress;
            this._availableBookings = argAvailableBookings;
        }


        public override string ToString()
        {
            return string.Format("\n Member Id: {0} \n Member Name: {1}\n Membership Date: {2}\n Address: {3}\n emailAddress : {4}\n Available Bookings : {5}",
                this._memberId, this._memberName, this._membershipDate, this._address, this._emailAddress, this._availableBookings);
        }


        public bool equals(Object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Members member = (Members)obj;
                return (_memberId == member._memberId) && (_memberName == member._memberName) && (_membershipDate == member._membershipDate) &&
                      (_address == member._address) && (_availableBookings == member._availableBookings);
            }
        }



    }

}