

// See https://aka.ms/new-console-template for more information
using adichostedapp;

Console.WriteLine("Service started");
AppService service = new AppService();
service.ExecuteTask();

Console.WriteLine("Task executed");
