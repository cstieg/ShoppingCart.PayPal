Steps to integrate

In solution, add existing project ShoppingCart.PayPal
In main project, add reference to ShoppingCart.PayPal and Geography project

Click on main project in solution explorer
In properties window below (F4), change SSL Enabled property to true, note SSL URL
In Project --> Properties --> Web, change Project URL to the SSL URL from last step

Create project at http://developer.paypal.com, 
	Note email and client id
	Add return urls (both localhost and live domain name)
	Customize app feature options
	Save

Copy PayPal.json to main project
	Insert client email and client id from developer.paypal.com
	Can copy contents of PayPal.live.json to PayPay.json for live PayPal, or PayPal.sandbox.json for testing

Copy PayPalController to controller in main project, uncomment, substitute namespaces where necessary
Copy Scripts folder to main project

Uncomment this line in ShoppingCartController, and delete the next one
	//ClientInfo ClientInfo = new PayPalApiClient().GetClientSecrets();
	  object ClientInfo = null;

Add this reference in using section:
	using Cstieg.Sales.PayPal;


