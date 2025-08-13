using Project_Backend_2024.DTO.TechStack;

var app = TechStack.CreateApp(args);
app.Map("GET","/health", () => "ok");
app.Run();