using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class PlaneModel
    {
        #region Fields

        internal List<Plane> _planes = new List<Plane>();

        #endregion Fields

        #region Properites

        internal List<Plane> Planes
        {
            get { return _planes; }
            set { _planes = value; }
        }

        #endregion

        #region List

        internal void AddFlights(Plane[] planes)
        {
            foreach (Plane plane in planes) 
            {
                _planes.Add(plane);
            }
        }

        #endregion
    }
}
