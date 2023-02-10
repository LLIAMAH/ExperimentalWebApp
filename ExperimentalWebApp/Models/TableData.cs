namespace ExperimentalWebApp.Models
{
    public enum EnumStatus
    {
        Unknown,
        Active,
        Postponed,
        Closed
    }

    public class TableData
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumStatus Status { get; set; }
        public DateTime DateCreated { get; set;}
        public DateTime? DateUpdated { get; set;}

        public string DatesString =>
            DateUpdated != null
                ? $"{DateCreated} / {DateUpdated}"
                : $"{DateCreated} / <empty>";

        public TableData()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}
