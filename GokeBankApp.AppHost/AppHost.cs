var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Goke_Bank_WebServer>("goke-bank-webserver");

builder.AddProject<Projects.Goke_Bank_Web>("goke-bank-web");

builder.AddProject<Projects.Goke_Bank_Hyb>("goke-bank-hyb");

builder.AddProject<Projects.Goke_Bank_App>("goke-bank-app");


builder.Build().Run();
