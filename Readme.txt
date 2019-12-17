Please follow the below instructions to run the project successfully and test the functionality:

1. Open your ssms(SQL Server Management Studio)
2. Open the SqlScripts.sql file and select all the contents of file and execute.
3. Database will be automatically get created with name: "MyDatabase".

Copy the repository from github path:
and Update the Server name in Web.config and app.config file in both of the projects with your database serverName or database Instance Name.(for ex. i setuped in my local machine so it like (localdb)\MyInstance). 

Download and install the Fiddler/Postman to test the created APIs: 
(I have use Fiddler, so below i am mentioning setps related to Fiddler only.)
1. If you want to download Fiddler, you can use this link: https://www.telerik.com/download/fiddler
2. If ContactAPI is not selected as a startup project, make it as Startup projet by right click on ContactAPI->Set as StartUp Project.
3. Run the Application by pressing CTRL+F5.
4. Click the Composer tab and paste the below lines in Headers: 
Content-type: application/json
accept: application/json

For any of this case to work copy the server name and append it before the below urls:

For testing Get Method:
1. From the Dropdown select the GET option.
2. i. Replace_With_Server_Name/api/Contact/GetContact
ii. Replace_With_Server_Name/api/Contact/GetContact/1
3. Click Execute button.
4. You can see the output Under Inspectors tab -> Under JSON tab and for the Status Code you can check it on Second Raw Tab.


For testing Put Method:
1. From the Dropdown select the PUT option.
2. Replace_With_Server_Name/api/Contact/UpdateContact/1
3. 1 is the id of parameter you can pass any if you want, but for working successfully it need to be in database.
4. put the below data in request body, again below data must be valid to get sucessfully save in database:
    {
        "FirstName": "Deepesh1",
        "LastName": "Chopda1",
        "Email": "deepeshc1@gmail.com",
        "Phone": "8983290191",
        "Status": "Active"
    }
3. Click Execute button.
4. You can see the output Under Inspectors tab -> Under JSON tab and for the Status Code you can check it on Second Raw Tab.

For testing Post Method:
1. From the Dropdown select the POST option.
2. Replace_With_Server_Name/api/Contact/CreateContact
3. Put the below data in request body, the below data must be valid to get sucessfully save in database:
    {
        "FirstName": "ABC",
        "LastName": "XYZ",
        "Email": "abc@gmail.com",
        "Phone": "8899775566",
        "Status": "Inactive"
    } 
4. Click Execute button.
5. You can see the output Under Inspectors tab -> Under JSON tab and for the Status Code you can check it on Second Raw Tab.

For testing Delete Method:
1. From the Dropdown select the DELETE option.
2. Replace_With_Server_Name/api/Contact/DeleteContact/12
3. Click Execute button.
4. You can see the output Under Inspectors tab -> Under JSON tab and for the Status Code you can check it on Second Raw Tab.


For Executing TestCases:
1. Go to Test tab in Visual Studio.
2. Run->All Tests
3. You will be able to see the test result in Test Explorer.
