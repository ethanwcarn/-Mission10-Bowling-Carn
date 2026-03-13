using System.IO;
using System.Collections.Generic;
using BowlingApi.Models;
using Microsoft.Data.Sqlite;

// Create the application builder, which wires up services and middleware.
var builder = WebApplication.CreateBuilder(args);

// Allow the local Vite development server to call this API during development.
const string FrontendDevCorsPolicy = "FrontendDev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendDevCorsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Build a SQLite connection string that points at the BowlingLeague.sqlite file
// located in the root of the solution (one level above the API project).
var databasePath = Path.Combine(builder.Environment.ContentRootPath, "..", "BowlingLeague.sqlite");
var connectionString = $"Data Source={databasePath}";

// Optional: keep the minimal OpenAPI support that the template includes.
builder.Services.AddOpenApi();

// Build the HTTP application.
var app = builder.Build();

// When running in development, expose the OpenAPI endpoint for quick testing.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Redirect HTTP traffic to HTTPS outside development to avoid local certificate issues.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Enable CORS for the front-end app so browser fetch requests are allowed.
app.UseCors(FrontendDevCorsPolicy);

// Minimal API endpoint that returns bowler data for only the Marlins and Sharks teams.
app.MapGet("/api/bowlers", async () =>
    {
        // Prepare the collection that will hold the result set returned to callers.
        var bowlers = new List<BowlerDto>();

        // Open a direct SQLite connection so that we have full control over the SQL
        // sent to the BowlingLeague database.
        await using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        // SQL query that joins Bowlers and Teams, filters to Marlins/Sharks, and
        // orders by team, last name, and first name.
        const string sql = @"
SELECT 
    b.BowlerFirstName,
    b.BowlerMiddleInit,
    b.BowlerLastName,
    t.TeamName,
    b.BowlerAddress,
    b.BowlerCity,
    b.BowlerState,
    b.BowlerZip,
    b.BowlerPhoneNumber
FROM Bowlers b
INNER JOIN Teams t ON b.TeamID = t.TeamID
WHERE t.TeamName IN ('Marlins', 'Sharks')
ORDER BY t.TeamName, b.BowlerLastName, b.BowlerFirstName;";

        await using var command = new SqliteCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        // Read each row and map it into a BowlerDto instance.
        while (await reader.ReadAsync())
        {
            var firstName = reader.GetString(0);
            var middleInit = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
            var lastName = reader.GetString(2);

            var fullName = string.IsNullOrWhiteSpace(middleInit)
                ? $"{firstName} {lastName}"
                : $"{firstName} {middleInit} {lastName}";

            bowlers.Add(new BowlerDto
            {
                BowlerName = fullName,
                TeamName = reader.GetString(3),
                Address = reader.GetString(4),
                City = reader.GetString(5),
                State = reader.GetString(6),
                Zip = reader.GetString(7),
                PhoneNumber = reader.GetString(8)
            });
        }

        // Return the complete list of bowlers that match the filter.
        return Results.Ok(bowlers);
    })
    .WithName("GetBowlers")
    .WithDescription("Returns bowler information filtered to only the Marlins and Sharks teams.");

// Start listening for HTTP requests.
app.Run();
