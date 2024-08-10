navigate to the folder that contains BlazorBankApp.csproj and type into terminal:

dotnet run

The server should then start listening on localhost, with a variable (random) port number. In certain cases, the browser may not automatically open the page. If this occurs, please refer to the URL displayed in the console when the server starts (on dotnet run entry).

It should display:
http://localhost:[portnumber]

for example:
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5104

replace [portnumber] with the actual port number displayed. enter the URL in the browser and you should see the Web App UI.

Please note: 
https is not supported in this project! please ensure you use http ONLY!
You may have to accept the 'security risk' that the browser displays for non-https pages by clicking 'I understand the risks' or something similar, depending on the browser you use.

The project includes all necessary binaries for Windows systems.
It may be necessary to clean-build the solution on different platforms if the page is not rendered correctly.