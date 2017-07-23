# Making a Project

With DotNetCore you can generate a number of different project types 
which gets you going a little faster, using the `dotnet` CLI command.

If you forget the options for `dotnet` just type:
```
dotnet new --help
```

## Console App

A Console App is a good way to start and try different parts of a .NET
language.  The `dotnet` command will also scaffold your project
in a language of your choice.

For a simple console app in C#, type the below for a project called "Scalars".  By default, this will be for the C# language - as no language was specified.
```
dotnet new console -o Scalars
dotnet restore
```

The `dotnet restore` command is needed prior to DotNetCore 2 but from 2, the tools will 'restore' the project for you after creation.

Restoring downloads the necessary runtime classes and any open source Nuget
packages neeeded for your project to be compiled and executed.

The scaffolded `Program.cs` will be a basic hello-world app and can be executed by typing:

```
dotnet run
```
Produces the output...
```
$ dotnet run
Hello World!
```


----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |
