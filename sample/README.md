# EF Continuous Migrations - Sample Application

This folder includes a sample ASP.NET Core application which is configured to use EF Continuous Migrations running in Docker.

### Requirements

- Docker
- VSDbg

  The Docker application expects VSDbg to be installed in the root of the EF Continusous Migrations project. It can be downloaded using the following command: 
  
  `curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg`
  
  Optionally VSDbg can be installed in the applicaiton Docker image. See the Web/Dockerfile for more details.

### Running the application

1. Run the `compose-up` VSCode Task.

### How do I know it worked?

Connect to the `ContinuousMigrations-MySql` instance using the credentials in the `applsettings.json` file to inspect the database & tables.

OR

Look at the `ContinuousMigrations-Web_Debug` container log output to ensure the database migrations were applied.

### Debugging sample application

The sample application is configured to be debugged locally or inside a Docker container using the following launch settings:

- `Attach to Web (Docker)`
- `Launch Web (Local)`

In order to debug locally make sure the MySql container is running and accessable (this can be done using the `compose-up` VSCode Task).

In order to attach to the application running in Docker first compose-up the application and ensure the application is running and migrations have been applied. Then select the dotnet process when `Attach to Web (Docker)` is run. 

__Note:__ Breakpoints in application startup are not accessable using the debugger attached to Docker.

### Cleaning up

Stop the application and delete containers using the `compose-down` VSCode Task.

### Issues?

If you have any issues please report it here.