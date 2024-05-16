using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Queue
	{
        #region Fields

        // List of people in que for check in
        List<byte> numbers = new List<byte>();
        Random random = new Random();
        #endregion

        #region Methods

        /// <summary>
        /// Method for getting a random amount of travelers
        /// </summary>
        /// <returns></returns>
        public byte GenerateTraveler()
        {
            byte travelers = Convert.ToByte(random.Next(1,6));
            return travelers;
        }

        /// <summary>
        /// Method for adding a person or persons to our list
        /// </summary>
        /// <param name="value"></param>
        public void QueAdd(byte value) 
        {
            numbers.Add(value);
        }

        /// <summary>
        /// Method for removing a person or persons from our que list
        /// </summary>
        /// <param name="value"></param>
        public void QueRemove(byte value)
        {
            numbers.RemoveAt(value);
        }

        /// <summary>
        /// Method to get the total amount of people in the que
        /// </summary>
        /// <param name="que"></param>
        /// <returns></returns>
        public int GetQueLength(List<byte> que)
        {
            int count = 0;
            foreach(byte value in que) 
            {
                count = count + value;
            }
            return count;
        }
        #endregion
    }
}
