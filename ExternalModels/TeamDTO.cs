namespace SoccerWebAPI.ExternalModels
{
    public class TeamDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BestPlayer { get; set; }
        public Guid CoachId { get; set; }
        public CoachDTO Coach { get; set; }
    }
}