namespace EFLib
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public EventType EventType { get; set; }
    }
}