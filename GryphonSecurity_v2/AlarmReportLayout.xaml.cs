using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GryphonSecurity;
using System.Globalization;
using GryphonSecurity_v2.Domain.Entity;
using GryphonSecurity_v2.Resources;

namespace GryphonSecurity_v2
{
    public partial class AlarmReportLayout : PhoneApplicationPage
    {
        Controller controller = Controller.Instance;
        public AlarmReportLayout()
        {
            InitializeComponent();
        }

        private void sendReport_Click(object sender, RoutedEventArgs e)
        {
            String customerNameTB = textBoxCustomerName.Text;
            long customerNumberTB = Convert.ToInt64(textBoxCustomerNumber.Text);
            String streetAndHouseNumberTB = textBoxStreetAndHouseNumber.Text;
            int zipCodeTB = Convert.ToInt32(textBoxZipCode.Text);
            String cityTB = textBoxCity.Text;
            long phonenumberTB = Convert.ToInt64(textBoxPhonenumber.Text);
            DateTime dateTB = DateTime.Parse(textBoxDate.Text, CultureInfo.InvariantCulture);
            DateTime timeTB = DateTime.Parse(textBoxTime.Text, CultureInfo.InvariantCulture);
            String zoneTB = textBoxZone.Text;
            Boolean burglaryVandalismCB = (Boolean)checkBoxBurglaryVandalism.IsChecked;
            Boolean windowDoorClosedCB = (Boolean)checkBoxWindowDoorClosed.IsChecked;
            Boolean apprehendedPersonCB = (Boolean)checkBoxApprehendedPerson.IsChecked;
            Boolean staffErrorCB = (Boolean)checkBoxStaffError.IsChecked;
            Boolean nothingToReportCB = (Boolean)checkBoxNothingToReport.IsChecked;
            Boolean technicalErrorCB = (Boolean)checkBoxTechnicalError.IsChecked;
            Boolean unknownReasonCB = (Boolean)checkBoxUnknownReason.IsChecked;
            Boolean otherCB = (Boolean)checkBoxOther.IsChecked;
            Boolean cancelDuringEmergencyCB = (Boolean)checkBoxCancelsDuringEmergency.IsChecked;
            Boolean coverMadeCB = (Boolean)checkBoxCoverMade.IsChecked;
            String remarkTB = textBoxRemark.Text;
            String nameTB = textBoxName.Text;
            String installerTB = textBoxInstaller.Text;
            String controlCenterTB = textBoxControlCenter.Text;
            DateTime guardRadioedDateTB = DateTime.Parse(textBoxGuardRadioedDate.Text, CultureInfo.InvariantCulture);
            DateTime guardRadioedFromTB = DateTime.Parse(textBoxGuardRadioedFrom.Text, CultureInfo.InvariantCulture);
            DateTime guardRadioedToTB = DateTime.Parse(textBoxGuardRadioedTo.Text, CultureInfo.InvariantCulture);
            DateTime arrivedAtTB = DateTime.Parse(textBoxArrivedAt.Text, CultureInfo.InvariantCulture);
            DateTime doneTB = DateTime.Parse(textBoxDone.Text, CultureInfo.InvariantCulture);
            if (controller.createAlarmReport(new AlarmReport(customerNameTB, customerNumberTB, streetAndHouseNumberTB, zipCodeTB, cityTB, phonenumberTB, dateTB, timeTB, zoneTB, burglaryVandalismCB,
                                        windowDoorClosedCB, apprehendedPersonCB, staffErrorCB, nothingToReportCB, technicalErrorCB, unknownReasonCB, otherCB, cancelDuringEmergencyCB, coverMadeCB,
                                        remarkTB, nameTB, installerTB, controlCenterTB, guardRadioedDateTB, guardRadioedFromTB, guardRadioedToTB, arrivedAtTB, doneTB)))
            {
                MessageBox.Show(AppResources.ReportAlarmReportSuccess);
            }
            else
            {
                MessageBox.Show(AppResources.ReportAlarmReportFailed);
            }

        }
    }
}