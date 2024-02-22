# BlazorUIEvents
**A short proof of concept to showcase UI event responses from a singleton service**

To see it in action, clone the repo and run the app, then open a second browser (i.e. Firefox AND chrome), Copy the URL from the running app and paste it in the other browser. Then, when you hit the increment button, the count will update and whatever you have typed in the text box will be sent out, and both the updated count and the text message will display on all open connections on all browsers. 

**Key points are as follows:** 

- SingleService.cs contains a CountValue variable that can be shared across connections and browsers, as well as an event that can be subscribed to and a method 'OnCountValueIncreased' that will increment the counter once and then brodacst the event

- Startup.cs has a line to register SingleService.cs as a Singleton service, to be consumed by all connections

- StringEventArgs.cs outlines extending EventArgs to add your own properties

- Index.razor.cs outlines one of the ways to do a 'Code behind' approach. This one is used to instead of the Partial Class approach so that OwningComponentBase can be implemented, and then Index.razor can inherit it all. Usage of the SingleService to subscribe to and handle the event is outlined here

- Index.razor will of course display the count and the value passed in the StringEventArgs, but also has a button that is orth noting. The 'OnClick' function of the button is assigned to exectute the 'OnCountValueIncreased' method of the SingleService, and takes the current page as the sender parameter and build a new StringEventArgs instance that passes the value from the text box. 


**Where is this useful?**

I've used this concept to build from and set up in-app notifications across users, logon/logoff notifications, and background triggers for a combination Toast / Modal component that I put together. I'm sure there are other uses as well and I'd love to hear about them. 
