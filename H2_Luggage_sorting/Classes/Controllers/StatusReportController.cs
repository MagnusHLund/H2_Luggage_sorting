using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class StatusReportController
	{
        #region Fields

        private protected string _flightId = "";
        private protected string _planeModel = "";
        private protected string _departureTime = "";
        private protected TimeModel _timeModel;



        static string directory = Environment.CurrentDirectory;
		#endregion


		#region Constructor
		internal StatusReportController(string flightId, string planeModel, string departureTime, TimeModel timeModel)
        {
            _flightId = flightId;
            _planeModel = planeModel;
            _departureTime = departureTime;
            _timeModel = timeModel;
        }

		#endregion


		#region Methods
		internal void GenerateStatusReport(List<Luggage> luggageList)
        {

            string currentTime = _timeModel.GetDateTime().ToShortDateString();

            
            while(true)
            {
                if (currentTime != _timeModel.GetDateTime().ToShortDateString())
                {
                    currentTime = _timeModel.GetDateTime().ToShortDateString();
                    
			        string path = $"{directory}/StatusReport-{currentTime}.txt";

                    StringBuilder reportContent = new StringBuilder();
                    reportContent.AppendLine("Status Report");
                    reportContent.AppendLine("-------------");
                    reportContent.AppendLine($"Flight ID: {_flightId}");
                    reportContent.AppendLine($"Plane Model: {_planeModel}");
                    reportContent.AppendLine($"Departure Time: {_departureTime}");
                    reportContent.AppendLine();
                    reportContent.AppendLine("Luggage List:");
                    reportContent.AppendLine("-------------");

                    foreach (var luggage in luggageList)
                    {
                        reportContent.AppendLine($"Weight: {luggage.Weight}");
                    }

                    File.WriteAllText(path, reportContent.ToString());
                }

            }


        }

        #endregion


    }
}
