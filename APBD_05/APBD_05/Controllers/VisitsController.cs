using APBD_05;
using APBD_05.Database;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    // GET: api/visits/animal/{animalId}
    [HttpGet("animal/{animalId}")]
    public ActionResult<IEnumerable<Visit>> GetVisitsForAnimal(int animalId)
    {
        var visits = Db.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);
    }

    // POST: api/visits
    [HttpPost]
    public ActionResult<Visit> PostVisit(Visit visit)
    {
        Db.Visits.Add(visit);
        return CreatedAtAction("GetVisitsForAnimal", new { animalId = visit.AnimalId }, visit);
    }
}