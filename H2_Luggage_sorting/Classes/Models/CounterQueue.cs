using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class CounterQueue
	{
        #region Fields

        // List of people in queue for check in
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
        public void QueueAdd(byte value) 
        {
            numbers.Add(value);
        }

        /// <summary>
        /// Method for removing a person or persons from our queue list
        /// </summary>
        /// <param name="value"></param>
        public void QueueRemove(byte value)
        {
            numbers.RemoveAt(value);
        }

        /// <summary>
        /// Method to get the total amount of people in the que
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public int GetQueueLength(List<byte> queue)
        {
            int count = 0;
            foreach(byte value in queue) 
            {
                count = count + value;
            }
          //  return count;

            return queue.Count;
        }
        #endregion
    }
}
