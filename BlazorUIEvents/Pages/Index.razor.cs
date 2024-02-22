using BlazorUIEvents.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUIEvents.Pages
{
	//Inherit from OwningComponentBase or implement IDisposable
	public class IndexBase : OwningComponentBase
	{

		public string status { get; set; }

		public string MessageToPass { get; set; }

		[Inject]
		protected SingleService Service { get; set; }


		//This handler will be called whenever the event defined in MyService 
		//triggers, and will accept EventArgs which can be passed from the event caller
		//Note that this needs to be ASYNC so you can await the 'InvokeAsync' call below
		private async void OnStatusChangedMethod(object sender, EventArgs e)
		{

			//Verify the EventArgs is the sub-type you expect
			if (e.GetType() == typeof(StringEventArgs))
			{
				//Cast EventArgs to the type you need, then extract value
				status = (e as StringEventArgs).Value;
			}

			//Invoke StateHasChanged in an async call, helps align the thread with the Synchroniztion context
			await InvokeAsync(StateHasChanged);
		}


		//Triggered when the page builds and renders
		protected override void OnInitialized()
		{
			//Unsubsribe once to make sure you only have one event subscription
			//This prevents event propogation, and won't do anything unless you are 
			//already subscribed for some reason
			Service.MyEvent -= OnStatusChangedMethod;

			//Subscribe to the event 
			Service.MyEvent += OnStatusChangedMethod;
		}

		//IMPORTANT - override Dispose and unsubscribe on teardown
		protected override void Dispose(bool disposing)
		{
			//PRevents event propogation and memory leaks
			Service.MyEvent -= OnStatusChangedMethod;
		}

	}
}
