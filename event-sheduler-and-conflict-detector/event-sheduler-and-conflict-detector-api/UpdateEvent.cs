namespace event_sheduler_and_conflict_detector_api
{
    public class UpdateEvent
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public required string Location { get; set; }
        public required string Attendees { get; set; }
        public string? EventType { get; set; }
    }
}
