using H2_Luggage_sorting.Classes.Models;
using System.Linq;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class LuggageController
	{
		private readonly LuggageModel _luggageModel;
		private readonly object _lock = new object(); // Lock object

		/// <summary>
		/// Initializes a new instance of the LuggageController class with the provided luggage model.
		/// </summary>
		/// <param name="luggageModel">The luggage model.</param>
		internal LuggageController(LuggageModel luggageModel)
		{
			_luggageModel = luggageModel;
		}

		/// <summary>
		/// Continuously sorts luggage to gates.
		/// </summary>
		internal void SortLuggageToGate()
		{
			while (true)
			{
				lock (_lock) // Ensure that sorting luggage is thread-safe
				{
					if (_luggageModel.LuggageToSort.Any())
					{
						var luggage = _luggageModel.LuggageToSort.First();
						_luggageModel.SortedLuggage.Add(luggage);
						_luggageModel.LuggageToSort.Remove(luggage);
					}
				}
			}
		}
	}
}
