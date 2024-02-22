using System;

namespace BlazorUIEvents.Data
{

	// This is a simple demo of extending EventArgs 
	//to allow sepcific values to be passed in the args

	public class StringEventArgs : EventArgs
	{
		public string Value { get; set; }
	}
}
