This is a sample test program which will get the data from WEb API https://eservices.mas.gov.sg/api/action/datastore/search.json?resource_id=5f2b18a8-0883-4769-a635-879c63d3caac
in JSOn format.
The data is deserialised into a .NET class and used for meeting the business requirements
The fields used in the WEb API for Fixed Deposit Intrest Rates are 

banks_fixed_deposits_3m
banks_fixed_deposits_6m
banks_fixed_deposits_12m
for Banks and

fc_fixed_deposits_3m
fc_fixed_deposits_6m
fc_fixed_deposits_12m

for Financial Companies

The fields used in the WEb API for Savings Deposit Intrest Rates are 

banks_savings_deposits
for Banks and

fc_savings_deposits
for Financial Companies

The Month and year is getting from fields
end_of_month

The Program is written as console application .exe script which can be run from command prompt.

The code is built in VS 2017 using c# programming language and using ASP.NET Web Api.

To compile the program , just open the solution in VS 2017 or VS 2015 and right click in the solution explorer , click build

Go to output window to see if there are any compiling errors and if build is successful
navigate to the folder where the exe is located and with high admin rights run the program .exe by calling MOMAssignment.exe

Enter the dates ranges and view the result outcome as per test case document shared

Assumptions :

The Program expects the data at the API is accurate and correct
It has correct intrest rates for valid month
end_of_month refers to the month period.
fc_fixed_deposits_3m
fc_fixed_deposits_6m
fc_fixed_deposits_12m 
is all cumulative fixed deposit rates for Financial companies

anks_fixed_deposits_3m
banks_fixed_deposits_6m
banks_fixed_deposits_12m
is all cumulative fixed deposit rates for Banks

The design pattern used here is composite design pattern where the primitive class is contained as an  object in the containing class and forms a heirrachy


