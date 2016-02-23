using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GryphonSecurity_v2.Domain.Entity
{
    class AlarmReport
    {
        String customerName;
        long customerNumber;
        String streetAndHouseNumber;
        int zipCode;
        String city;
        long phonenumber;
        DateTime date;
        DateTime time;
        String zone;
        Boolean burglaryVandalismk;
        Boolean windowDoorClosed;
        Boolean apprehendedPerson;
        Boolean staffError;
        Boolean nothingToReport;
        Boolean technicalError;
        Boolean unknownReason;
        Boolean other;
        Boolean cancelsDuringEmergency;
        Boolean coverMade;
        String remark;
        String name;
        String installer;
        String controlCenter;
        DateTime guardRadioedDate;
        DateTime guardRadioedFrom;
        DateTime guardRadioedTo;
        DateTime arrivedAt;
        DateTime done;

        public AlarmReport(string customerName, long customerNumber, String streetAndHouseNumber, int zipCode, String city, long phonenumber, DateTime date, DateTime time, String zone,
                Boolean burglaryVandalismk, Boolean windowDoorClosed, Boolean apprehendedPerson, Boolean staffError, Boolean nothingToReport, Boolean technicalError, Boolean unknownReason,
                Boolean other, Boolean cancelsDuringEmergency, Boolean coverMade, String remark, String name, String installer, String controlCenter, DateTime guardRadioedDate,
                DateTime guardRadioedFrom, DateTime guardRadioedTo, DateTime arrivedAt, DateTime done)
        {
            this.customerName = customerName;
            this.customerNumber = customerNumber;
            this.streetAndHouseNumber = streetAndHouseNumber;
            this.zipCode = zipCode;
            this.city = city;
            this.phonenumber = phonenumber;
            this.date = date;
            this.time = time;
            this.zone = zone;
            this.burglaryVandalismk = burglaryVandalismk;
            this.windowDoorClosed = windowDoorClosed;
            this.apprehendedPerson = apprehendedPerson;
            this.staffError = staffError;
            this.nothingToReport = nothingToReport;
            this.technicalError = technicalError;
            this.unknownReason = unknownReason;
            this.other = other;
            this.cancelsDuringEmergency = cancelsDuringEmergency;
            this.coverMade = coverMade;
            this.remark = remark;
            this.name = name;
            this.installer = installer;
            this.controlCenter = controlCenter;
            this.guardRadioedDate = guardRadioedDate;
            this.guardRadioedFrom = guardRadioedFrom;
            this.guardRadioedTo = guardRadioedTo;
            this.arrivedAt = arrivedAt;
            this.done = done;
        }

        public String CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public long CustomerNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }

        public String StreetAndHouseNumber
        {
            get { return streetAndHouseNumber; }
            set { streetAndHouseNumber = value; }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public long Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public String Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public Boolean BurglaryVandalismk
        {
            get { return burglaryVandalismk; }
            set { burglaryVandalismk = value; }
        }

        public Boolean WindowDoorClosed
        {
            get { return windowDoorClosed; }
            set { windowDoorClosed = value; }
        }

        public Boolean ApprehendedPerson
        {
            get { return apprehendedPerson; }
            set { apprehendedPerson = value; }
        }

        public Boolean StaffError
        {
            get { return staffError; }
            set { staffError = value; }
        }

        public Boolean NothingToReport
        {
            get { return nothingToReport; }
            set { nothingToReport = value; }
        }

        public Boolean TechnicalError
        {
            get { return technicalError; }
            set { technicalError = value; }
        }

        public Boolean UnknownReason
        {
            get { return unknownReason; }
            set { unknownReason = value; }
        }

        public Boolean Other
        {
            get { return other; }
            set { other = value; }
        }

        public Boolean CancelsDuringEmergency
        {
            get { return cancelsDuringEmergency; }
            set { cancelsDuringEmergency = value; }
        }

        public Boolean CoverMade
        {
            get { return coverMade; }
            set { coverMade = value; }
        }

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Installer
        {
            get { return installer; }
            set { installer = value; }
        }

        public String ControlCenter
        {
            get { return controlCenter; }
            set { controlCenter = value; }
        }

        public DateTime GuardRadioedDate
        {
            get { return guardRadioedDate; }
            set { guardRadioedDate = value; }
        }

        public DateTime GuardRadioedFrom
        {
            get { return guardRadioedFrom; }
            set { guardRadioedFrom = value; }
        }

        public DateTime GuardRadioedTo
        {
            get { return guardRadioedTo; }
            set { guardRadioedTo = value; }
        }

        public DateTime ArrivedAt
        {
            get { return arrivedAt; }
            set { arrivedAt = value; }
        }

        public DateTime Done
        {
            get { return done; }
            set { done = value; }
        }
    }
}
