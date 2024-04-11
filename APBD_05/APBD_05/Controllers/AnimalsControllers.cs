using APBD_05;
using APBD_05.Database;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    // GET: api/animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals()
    {
        return Ok(Db.Animals);
    }

    // GET: api/animals/{id}
    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    // POST: api/animals
    [HttpPost]
    public ActionResult<Animal> PostAnimal(Animal animal)
    {
        Db.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }


    // PUT: api/animals/{id}
    [HttpPut("{id}")]
    public IActionResult PutAnimal(int id, Animal animal)
    {
        var existingAnimal = Db.Animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null) return NotFound();

        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;

        return NoContent();
    }

    // DELETE: api/animals/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        Db.Animals.Remove(animal);
        return NoContent();
    }
}