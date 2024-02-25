using EFLib;
using SleepLog.Views;

namespace SleepLog
{
    public partial class MainPage : ContentPage
    {
        private readonly IEFDBContext eFDBContext;
        private readonly AddSleepEvent addSleepEvent;

        public MainPage(IEFDBContext eFDBContext, AddSleepEvent addSleepEvent)
        {
            this.eFDBContext = eFDBContext;
            this.addSleepEvent = addSleepEvent;
            InitializeComponent();
            RefreshUI();

            addSleepEvent.DBDataSent += AddSleepEvent_DBDataSent;
        }

        private void AddSleepEvent_DBDataSent()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            lvSampleData.ItemsSource = null;
            lvSampleData.ItemsSource = eFDBContext.LogEntries;
        }

        private void AddEntryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(addSleepEvent);
        }
    }
}
