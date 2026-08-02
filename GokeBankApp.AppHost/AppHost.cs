var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Goke_Bank_WebServer>("goke-bank-webserver");

builder.Build().Run();
