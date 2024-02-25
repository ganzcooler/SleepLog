using EFLib;

namespace SleepLog.Views;

public partial class AddSleepEvent : ContentPage
{
    public event Action DBDataSent;
    private readonly IEFDBContext eFDBContext;

    public AddSleepEvent(IEFDBContext eFDBContext)
    {
        InitializeComponent();
        this.eFDBContext = eFDBContext;
    }

    private async void CancelButton_ClickedAsync(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void AddEventButton_Clicked(object sender, EventArgs e)
    {
        // get VON date and time
        DateTime vonDate;
        vonDate = VonDatePicker.Date + VonTimePicker.Time;

        // get BIS date and time
        DateTime bisDate;
        bisDate = BisDatePicker.Date + BisTimePicker.Time;

        // get eventtype
        EventType eventType = (EventType)EventTypePicker.SelectedIndex;

        // Write data to DB
        eFDBContext.LogEntries.Add(new LogEntry
        {
            Von = vonDate,
            Bis = bisDate,
            EventType = eventType
        });
        eFDBContext.SaveChanges();

        DBDataSent?.Invoke();
        await Navigation.PopModalAsync();
    }
}