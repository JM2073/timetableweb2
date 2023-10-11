public class Tickets
{

    public string? ticket_id { get; set; }
    public string? ticket_subject { get; set; }
    public string? ticket_description { get; set; }
    public string? created_by { get; set; }
    public DateTime created_at { get; set; }
    public string? priority { get; set; }
    public string? status { get; set; }

    public int DaysOld(DateTime d)
    {
        DateTime d1 = DateTime.Now;


        TimeSpan t = d1 - d;
        double NrOfDays = t.TotalDays;
        return (int)NrOfDays;
    }

}