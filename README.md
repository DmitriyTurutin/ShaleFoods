Shale Foods Backend

---

### What is the main goal?

The main goal of this project is:

Create an API that can

1. Retrive Create Delete Update Vacancies
2. Retrive Create Delete Update Sales
3. Get and process data form contacts page
4. Generate and send Email to client
5. Generate and send Email to manager
6. Generate excel from clients requests data

### To be done first

- [ ] Even storm Sales
- [ ] Event storm Vacancies
- [ ] Setup EF Core

#### Vacancies

- Implement _domain layer_
- Unit Test _domain layer_
- Implement _application layer_
- Unit Test _application layer_
- Implement _infrastructure layer_
- Unit test _infrastructure layer_
- Implement _presentation layer_
- Unit test _presentation layer_
- Integration test `Sales`

#### Sales

- Implement _domain layer_
- Unit Test _domain layer_
- Implement _application layer_
- Unit Test _application layer_
- Implement _infrastructure layer_
- Unit test _infrastructure layer_
- Implement _presentation layer_
- Unit test _presentation layer_
- Integration test `Sales`

#### Send email

Use yandex smpt server to send email

#### Generate excel and google sheets

_Google Sheets_

1. Create a new project in the Google Developers Console and enable the Google Sheets API. You will also need to create credentials (like client ID and secret) for your application to access the API.

2. Install the Google.Apis.Sheets.v4 package via NuGet by running the following command in your package manager console:

```bash
Install-Package Google.Apis.Sheets.v4
```

In ASP.NET application, use the Google Sheets API to create a new SheetsService object. This object will be used to interact with the Google Sheets API.

```c#
var sheetsService = new SheetsService(new BaseClientService.Initializer
{
HttpClientInitializer = credential,
ApplicationName = "Your App Name",
});
```

4. Use the SheetsService object to interact with Google Sheets. For example, you can retrieve the values of a specific range of cells in a sheet by using the "Spreadsheets.Values.Get" method:

```c#
var request = sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
var response = request.Execute();
```

#### Authentication and Authorization

[Use openiddict](https://github.com/openiddict/openiddict-core) to set up authentication and authorization

- [ ] Vacancies

- [ ] Sales
- [ ] Sending Email
