using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUIEvents.Data
{
	public class SingleService
	{

		//This is a simple service implementation 
		// to outline holding application wide state, 
		//and handling an event notification

		public Func<object, EventArgs, Task> MyEvent;

		public int CountValue;

		public Task OnCountValueIncreased(object sender, EventArgs e)
		{
			CountValue++;
			MyEvent?.Invoke(sender, e);
			return Task.CompletedTask;
		}

	}
}
