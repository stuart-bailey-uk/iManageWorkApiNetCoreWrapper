# iManageWorkApiNetCoreWrapper

c# wrapper for the iManage Work REST Api, fed up waiting for the offical version so creating one.

## Basic usage ##

```
using Newtonsoft.Json;

using WorkWrapper.Authentication;

using WorkWrapper.Comms;

using WorkWrapper.Documents.Actions;

using WorkWrapper.Documents.Models;


var httpFactory = new HttpClientFactory();

var httpProxy = httpFactory.Create("https://****.imanagework.co.uk");

var virtualLogin = new VirtualLogon("https://****.imanagework.co.uk", httpProxy);

var session = await virtualLogin
    .ForUser("username", "password")
    .ForClient("client-id", "client-secret")
    .GetSessionAsync();

var apiClientFactory = new WorkApiClientFactory();
var workClient = apiClientFactory.Create(session);

var documentSearch = new DocumentsSearchAction(workClient);

var searchProfile = new StandardDocumentSearchProfile
{
    Class = "DOC"
};

var documents = await documentSearch.SearchDocumentsAsync(searchProfile);
```
