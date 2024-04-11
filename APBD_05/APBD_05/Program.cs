using APBD_05;
using APBD_05.Database;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// MapGet for animals
app.MapGet("/api/animals", () => Db.Animals)
    .WithName("GetAnimals")
    .WithOpenApi();

// MapGet for a single animal
app.MapGet("/api/animals/{id}", (int id) =>
    {
        var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
        return animal is not null ? Results.Ok(animal) : Results.NotFound();
    })
    .WithName("GetAnimal")
    .WithOpenApi();

// MapPost to add an animal
app.MapPost("/api/animals", (Animal animal) =>
    {
        Db.Animals.Add(animal);
        return Results.Created($"/api/animals/{animal.Id}", animal);
    })
    .WithName("AddAnimal")
    .WithOpenApi();

// MapPut to update an animal
app.MapPut("/api/animals/{id}", (int id, Animal updatedAnimal) =>
    {
        var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return Results.NotFound();
        
        animal.Name = updatedAnimal.Name;
        animal.Category = updatedAnimal.Category;
        animal.Weight = updatedAnimal.Weight;
        animal.FurColor = updatedAnimal.FurColor;
        
        return Results.NoContent();
    })
    .WithName("UpdateAnimal")
    .WithOpenApi();

// MapDelete to delete an animal
app.MapDelete("/api/animals/{id}", (int id) =>
    {
        var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return Results.NotFound();
        
        Db.Animals.Remove(animal);
        return Results.NoContent();
    })
    .WithName("DeleteAnimal")
    .WithOpenApi();

// MapGet for visits associated with an animal
app.MapGet("/api/visits/animal/{animalId}", (int animalId) =>
    Db.Visits.Where(v => v.AnimalId == animalId).ToArray())
    .WithName("GetVisitsForAnimal")
    .WithOpenApi();

// MapPost to add a visit
app.MapPost("/api/visits", (Visit visit) =>
    {
        Db.Visits.Add(visit);
        return Results.Created($"/api/visits/{visit.Id}", visit);
    })
    .WithName("AddVisit")
    .WithOpenApi();

app.Run();
