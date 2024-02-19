Hr department
------------------------------------------------------
Employees are managed. Employee belongs to a department. Employee has a manager.
Web Api and Web App.

The Web app is available at
https://localhost:7247/ 
The Web Api is available at
https://localhost:7247/api/apiemployees/ 


https://localhost:7247/api/apiemployees/4/manager/2




Solution
1. create MVC project using template
2. Add libraries
3. Create the model
4. DbContext -> dbset, contructors, onconfiguring
5. Define connection string, add in program.cs 
6. migration

7. Manage the employees -> scaffold a controller,  add to the main menu

8. make sure that the manager is shown

9. create Web API for employee
10. add API request to add a manager to an employee
11. add API request to add employee to a department
 
12. Create an MVC request to assign department to employee
	1. create the view
	1. create the command