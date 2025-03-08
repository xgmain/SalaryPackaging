# SalaryPackaging Caculator

- This is a simple salary packaging calculator that calculates the net salary of an employee after packaging their salary. 

- Using 
	- [x] .net 8, MVC and Blazor.
	- [x] frontend and backend validation.
	- [x] strategy pattern for calculation.(overkill for this simple project, can be replaced by switch statement for DRY principle).
	- [ ] I didn't write unit test for this, because its not on requirement.

- How did I approach the task
	- Understand requirement
	- Break down the logic
	- Plan structure
		1. Models
		2. validation
		3. Serivce Layer
		4. Controller
		5. Views
	- Implement code step by step
		1. Models first (Employee.cs)
		2. Business logic (SalaryPackagingService.cs)
		3. Apply validation
		4. Create Controller and Views
		5. (todo) UNIT test
	- Finalizing
		1. Clean up code
		2. Write README
		3. Submit via Git