using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add the EntityFramecore DbContext

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RaceDb>(options => options.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

#region Cars Endpoints

// Get cars

app.MapGet("api/cars", (RaceDb db) =>
{
    var cars = db.Cars.ToList();
    return Results.Ok(cars);
})
    .WithName("GetCars")
    .WithTags("Cars");

// Get car

app.MapGet("api/cars/{id}", (int id, RaceDb db) =>
{
    var dbCar = db.Cars.FirstOrDefault(x => x.Id == id);

    if(dbCar == null)
    {
        return Results.NotFound($"Car with id: {id} isn't found.");
    }

    return Results.Ok(dbCar);
})
    .WithName("GetCar")
    .WithTags("Cars");

// Create car

app.MapPost("api/cars",(CarCreateModel carModel, RaceDb db) =>
{
    var newCar = new Car
    {
        TeamName = carModel.TeamName,
        Speed = carModel.Speed,
        MelfunctionChance = carModel.MelfunctionChance
    };

    db.Cars.Add(newCar);
    db.SaveChanges();

    return Results.Ok(newCar);
})
    .WithName("CreateCar")
    .WithTags("Cars");

// Update car

app.MapPut("api/cars/{id}", ([FromQuery] int id, [FromBody] CarCreateModel carModel, RaceDb db) =>
{
    var dbCar = db.Cars.FirstOrDefault(x => x.Id == id);

    if (dbCar == null)
    {
        return Results.NotFound($"Car with id: {id} isn't found.");
    }

    dbCar.TeamName = carModel.TeamName;
    dbCar.Speed = carModel.Speed;
    dbCar.MelfunctionChance = carModel.MelfunctionChance;
    db.SaveChanges();

    return Results.Ok(dbCar);
})
    .WithName("UpdateCar")
    .WithTags("Cars");

// Delete car

app.MapDelete("api/cars/{id}", (int id, RaceDb db) =>
{
    var dbCar = db.Cars.FirstOrDefault(x => x.Id == id);

    if (dbCar == null)
    {
        return Results.NotFound($"Car with id: {id} isn't found.");
    }

    db.Remove(dbCar);
    db.SaveChanges();

    return Results.Ok($"Car with id: {id} was successfully deleted");
})
    .WithName("DeleteCar")
    .WithTags("Cars");

#endregion

#region Motobikes Endpoints

app.MapGet("api/motorbikes", (RaceDb db) =>
{
    var motorbikes = db.Motorbikes.ToList();

    return Results.Ok(motorbikes);
})
    .WithName("GetMotorbikes")
    .WithTags("Motorbikes");

app.MapGet("api/motorbikes/{id}", (int id, RaceDb db) =>
{
    var dbMotorbike = db.Motorbikes.FirstOrDefault(x => x.Id == id);

    if(dbMotorbike == null)
    {
        return Results.NotFound($"Motorbike with id: {id} isn't found.");
    }

    return Results.Ok(dbMotorbike);
})
    .WithName("GetMotorbike")
    .WithTags("Motorbikes");

app.MapPost("api/motorbikes/{id}", (MotorbikeCreateModel motorbikeModel, RaceDb db) =>
{
    var newMotorbike = new Motorbike()
    {
        TeamName = motorbikeModel.TeamName,
        Speed = motorbikeModel.Speed,
        MelfunctionChance = motorbikeModel.MelfunctionChance
    };

    db.Motorbikes.Add(newMotorbike);
    db.SaveChanges();

    return Results.Ok(newMotorbike);
})
    .WithName("CreateMotorbike")
    .WithTags("Motorbikes");

app.MapPut("api/motorbikes/{id}", ([FromQuery]int id, [FromBody]MotorbikeCreateModel motorbikeModel, RaceDb db) =>
{
    var dbMotorbike = db.Motorbikes.FirstOrDefault(x => x.Id == id);

    if (dbMotorbike == null)
    {
        return Results.NotFound($"Motorbike with id: {id} isn't found.");
    }

    dbMotorbike.TeamName = motorbikeModel.TeamName;
    dbMotorbike.Speed = motorbikeModel.Speed;
    dbMotorbike.MelfunctionChance = motorbikeModel.MelfunctionChance;

    db.SaveChanges();

    return Results.Ok(dbMotorbike);
})
    .WithName("UpdateMotorbike")
    .WithTags("Motorbikes");

app.MapDelete("api/motorbikes/{id}", (int id, RaceDb db) =>
{
    var dbMotorbike = db.Motorbikes.FirstOrDefault(x => x.Id == id);

    if (dbMotorbike == null)
    {
        return Results.NotFound($"Motorbike with id: {id} isn't found.");
    }

    db.Remove(dbMotorbike);
    db.SaveChanges();

    return Results.Ok($"Motorbike with id: {id} was successfully deleted");
})
    .WithName("DeleteMotorbike")
    .WithTags("Motorbikes");

#endregion

#region Default

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithTags("Default");

#endregion

app.Run();

#region Models

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record Car
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
    public int MelfunctionsOccured { get; set; }
    public int DistanceCoverdInMiles { get; set; }
    public bool FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}

public record CarCreateModel
{
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
}

public record Motorbike
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
    public int MelfunctionsOccured { get; set; }
    public int DistanceCoverdInMiles { get; set; }
    public bool FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}

public record MotorbikeCreateModel
{
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
}

#endregion


// Persistance

public class RaceDb : DbContext
{
    public RaceDb(DbContextOptions<RaceDb> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Motorbike> Motorbikes { get; set; }
}