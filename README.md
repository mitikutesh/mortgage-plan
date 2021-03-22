# mortgage-plan



- NOTE :
	This application has two  optional parts. One can use either the WebUI or the console application.

## Getting started

- Optional
	 Do this only if one want to create the table needed and populate with some data.

1. Install RoundHouse dotnet core global tools by writing to command line:
```sh
dotnet tool install --global dotnet-roundhouse --version 1.2.1
```
2. Check database "servername" from `db/Conf_LOCAL_Database.json`
3. Run 'RebuildDatabase.bat'

NOTE : Make sure to have a dotnet run installed on your machine

### Starting `Mortgage.Web` 


`Mortgage.Web` can be launched either through Visual Studio or from a command prompt in `src\Mortgage.Web`:

-before running set the database connectionsetting in appsetting.json
```sh
dotnet run
```

### Starting `Mortgage.Cli` 
`Mortgage.Cli` can be launched either through Visual Studio or from a command prompt in `src\Mortgage.Cli`:
- `Mortgage.Cli` takes full file path as an argument so it easier to compile and and run the .exe file and with argument
```sh
   src\Mortgage.Cli\bin\Debug\net5.0\Mortgage.Cli.exe -p " ~ \Codetest-Mortageplan\prospects.txt"
```

NOTE: `Mortgage.Web` read data from database while `Mortgage.Cli` reads data from a file with proper format.