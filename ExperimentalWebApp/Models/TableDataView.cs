namespace ExperimentalWebApp.Models
{
    public class TableDataView
    {
        public IList<TableData> Data { get; set; }

        public TableDataView()
        {
            this.Data = new List<TableData>();
        }
    }
}
