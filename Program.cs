using FluentMigrator.Runner;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddFluentMigratorCore()
.ConfigureRunner(config => config
    .AddPostgres()
    .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
    .ScanIn(typeof(Program).Assembly).For.Migrations()).AddLogging(l => l.AddFluentMigratorConsole());




var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

