

Steps to integrate


Click on main project in solution explorer
In properties window below, change SSL Enabled property to true, note SSL URL
In Project --> Properties --> Web, change Project URL to the SSL URL from last step

Create project at http://developer.paypal.com, 
	Note email and client id
	Add return urls (both localhost and live domain name)
	Customize app feature options
	Save

In solution, add existing project ShoppingCart.PayPal
In main project, add reference to ShoppingCart.PayPal.dll

Copy PayPalController to controller in main project, uncomment, substitute namespaces where necessary
Copy Scripts folder to main project
Add ~/Scripts/Site/PayPal.js to BundleConfig
Add @Scripts.Render statement for the bundle in _Layout.cshtml if not added to a preexisting bundle

Uncomment this line in ShoppingCartController, and delete the next one
	//ClientInfo ClientInfo = new PayPalApiClient().GetClientSecrets();
	  object ClientInfo = null;

Add this reference in using section:
	using Cstieg.ShoppingCart.PayPal;

Copy PayPal.json to main project
	Can copy contents of PayPal.live.json to PayPay.json for live PayPal, or PayPal.sandbox.json for testing
	Insert client email and client id from developer.paypal.com
