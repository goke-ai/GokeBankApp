var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Goke_Bank_WebServer>("goke-bank-webserver");

builder.AddProject<Projects.Goke_Bank_Web>("goke-bank-web");

builder.Build().Run();
