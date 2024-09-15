namespace FoxmindedCrudProject.Models
{
    public static class DbInitializer
    {
        public static EventContext db = new EventContext();

        public static void Seed(EventContext db)
        {
            db.Events = new List<Event>();
            db.Events.Add(new Event { Id = 1, Category = "Critical", Name = "Critical failure", Description = "Critical failure description", AdditionalInfo = "Critical failure AdditionalInfo", Place = "Critical failure place 1", Time = new DateTime(2024, 04, 30, 0, 0, 0), Images = "url1" });
            db.Events.Add(new Event { Id = 2, Category = "Minor", Name = "Minor failure", Description = "Minor failure description", AdditionalInfo = "Minor failure AdditionalInfo", Place = "Minor failure place 1", Time = new DateTime(2024, 04, 29, 0, 0, 0), Images = "url2" });
            db.Events.Add(new Event { Id = 3, Category = "Major", Name = "Major failure", Description = "Major failure description", AdditionalInfo = "Major failure AdditionalInfo", Place = "Major failure place 1", Time = new DateTime(2024, 03, 29, 0, 0, 0), Images = "url3" });
        }
    }
}
