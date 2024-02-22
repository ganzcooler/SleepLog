using EFLib;

namespace SleepLog
{
    public partial class MainPage : ContentPage
    {
        private readonly IEFDBContext eFDBContext;

        public MainPage(IEFDBContext eFDBContext)
        {
            this.eFDBContext = eFDBContext;
            InitializeComponent();
            lvSampleData.ItemsSource = eFDBContext.LogEntries;
        }

        private void generateSampleData(object sender, EventArgs e)
        {
            LogEntry logEntry = new LogEntry
            {
                Von = new DateTime(2024, 02, 21, 12, 00, 00),
                Bis = new DateTime(2024, 02, 21, 14, 00, 00),
                EventType = EventType.SLEEP
            };

            eFDBContext.LogEntries.Add(logEntry);
            eFDBContext.SaveChanges();

            lvSampleData.ItemsSource = eFDBContext.LogEntries;
        }
    }
}
