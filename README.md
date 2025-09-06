🏙 City Management System</br>

The City Management System is a demo application for managing day-to-day city tasks and long-term building projects, with role-based permissions for different types of city staff.</br>
City Tasks → small operational jobs that city departments need to perform.</br>
Examples: fixing streetlights, cleaning public gardens, repairing sidewalks, or scheduling waste collection.</br>
Building Projects → larger initiatives that require planning and approval from city management.</br>
Examples: constructing a new park, renovating a community center, or building new roads.</br>
The system allows managers to assign, create, and approve these tasks and projects depending on their role in the organization.</br>
It consists of:</br>
CityManagementApi → ASP.NET Web API for tasks & projects</br>
CityManagementApp → WPF desktop app for managers and workers</br>
Authentication & authorization are handled by Auth0 (already integrated with this app).</br></br></br>

🚀 Features</br>

Role-based permissions via Auth0 scopes:</br>
top-level-manager-test@city-mng-test.app → update:tasks, create:projects, update:projects</br>
mid-level-manager-test@city-mng-test.app → update:tasks, create:projects</br>
city-worker-test@city-mng-test.app → no extra permissions (view tasks/projects + create task)</br>

Tasks</br>
Anyone can view or create</br>
Mid & Top-level managers can accept</br>

Projects</br>
Anyone can view</br>
Mid & Top-level managers can create</br>
Only Top-level managers can accept</br>

WPF Client</br>
Login via Auth0</br>
<img width="500" height="350" alt="login-window" src="https://github.com/user-attachments/assets/ca74a749-67d0-4301-9e80-5520fce69a60" /></br>
<img width="500" height="350" alt="auth0-login" src="https://github.com/user-attachments/assets/913e05a8-747f-4902-add9-706c6ea8a523" /></br>

Create and manage tasks/projects</br>
UI shows permissions-based buttons</br>
Logout returns to Login screen
</br>
<img width="500" height="350" alt="city-task-main" src="https://github.com/user-attachments/assets/cc1cc47b-f461-4dc0-85fe-7deac2e05ba9" />
<img width="500" height="350" alt="city-project-main" src="https://github.com/user-attachments/assets/a71a7c02-b230-42f0-ae28-192456144052" />


</br></br>

🛠 Tech Stack</br>

.NET 8 (API + WPF)</br>
WPF (XAML) for desktop client</br>
Auth0 for authentication/authorization
</br></br></br>

👤 Test Users</br>
Username: top-level-manager-test@city-mng-test.app</br>
Password: cityapp.</br> 
Permissions:	update:tasks, create:projects, update:projects	Full access (tasks + projects + accept)</br>

Username: mid-level-manager-test@city-mng-test.app</br>
Password: cityapp.</br> 
Permissions:	update:tasks, create:projects	Manage tasks & create projects</br>

Username: regular-city-worker-test@city-mng-test.app</br> 
Password: cityapp.</br>

