namespace APBD_05.Database;

public static class Db
{
    public static List<Animal> Animals { get; set; }
    public static List<Visit> Visits { get; set; }

    static Db()
    {
        InitializeData();
    }

    private static void InitializeData()
    {
        Animals = new List<Animal>
        {
            new Animal { Id = 1, Name = "Aiko", Category = "Kot", Weight = 3.5, FurColor = "Brązowy" },
            new Animal { Id = 2, Name = "Tyler", Category = "Kot", Weight = 5.5, FurColor = "Czarny" },
            new Animal { Id = 3, Name = "Katsu", Category = "Kot", Weight = 3.0, FurColor = "Rudy" },
            new Animal { Id = 4, Name = "Moka", Category = "Kot", Weight = 100.0, FurColor = "Czarny" },
            new Animal { Id = 5, Name = "Basia", Category = "Pies", Weight = 8.0, FurColor = "Biało-brązowy" }
        };

        Visits = new List<Visit>
        {
            new Visit { Id = 1, AnimalId = 1, VisitDate = DateTime.Now.AddDays(-10), Description = "Roczne szczepienie", Price = 100.0m },
            new Visit { Id = 2, AnimalId = 2, VisitDate = DateTime.Now.AddDays(-5), Description = "Kontrola zdrowia", Price = 150.0m },
            new Visit { Id = 3, AnimalId = 3, VisitDate = DateTime.Now.AddDays(-2), Description = "Kastracja", Price = 200.0m }
        };
    }
}