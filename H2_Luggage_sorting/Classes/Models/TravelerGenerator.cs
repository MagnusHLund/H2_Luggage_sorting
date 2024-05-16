using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class TravelerGenerator : Passenger
    {
        #region Fields

        private protected string _firstname;
        private protected string _lastname;
        private protected string _passportNumber;

        #endregion



        #region Constructor

        #endregion



        #region Properties

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string PassportNumber
        {
            get { return _passportNumber; }
            set { _passportNumber = value; }
        }

        #endregion

        #region Methods
        
        #endregion
    }
}