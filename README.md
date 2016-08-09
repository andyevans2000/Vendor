A simple Vending Machine Implmentation with .NET.

The solution is divided into 4 projects.
1 - Vend - contains the main application logic, with VendingMachine.cs the principle class. 
2 - Vend.Tests - contains NUnit nunit tests for VendingMachine. Note - the unit tests are not exhaustive, but demonstate a broad range of the functionality. NSubstitute is used to mock objects.
3 - Vend.UI - this is a Windows Forms UI that demos the vending machine functionality - NOTE - this is a very quick and dirty demo / test client, it is in no way tested.
4 - Logger - an Autofac / Log4Net logging module

General principles

1 - Dependency Injection is used throughout, with use of interfaces. Autofac is used as a DI container for the Forms app.
2- Log4Net is used for logging of all events, loggers can be attached through standard log4net config (none are set up yet)