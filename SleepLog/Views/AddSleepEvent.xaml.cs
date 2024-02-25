using EFLib;

namespace SleepLog.Views;

public partial class AddSleepEvent : ContentPage
{
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
        vonDate = VonDatePicker.Date;
        vonDate.Add(VonTimePicker.Time);
        vonDate = vonDate.Date.Add(vonDate.TimeOfDay);

        // get BIS date and time
        DateTime bisDate;
        bisDate = BisDatePicker.Date;
        bisDate.Add(BisTimePicker.Time);
        bisDate = bisDate.Date.Add(bisDate.TimeOfDay);

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

        await Navigation.PopModalAsync();
    }
}