using System;
using System.Text.Json;

public class Schedule : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public DateTime? startDate
    {
        get
        {
            return StartDateDate + StartDateTime;
        }
        set
        {
            DateTime dateTime = (DateTime)value;
            StartDateDate = dateTime.Date;
            StartDateTime = dateTime.TimeOfDay;
        }
    }
    public DateTime? StartDateDate { get; set; }
    public TimeSpan? StartDateTime { get; set; }

    public DateTime? endDate
    {
        get
        {
            return EndDateDate + EndDateTime;
        }
        set
        {
            DateTime dateTime = (DateTime)value;
            EndDateDate = dateTime.Date;
            EndDateTime = dateTime.TimeOfDay;
        }

    }
    public DateTime? EndDateDate { get; set; }
    public TimeSpan? EndDateTime { get; set; }

    public DateTime? StartDateMinDate { get => DateTime.Now.AddDays(-1); }
    public DateTime? StartDateMaxDate { get => EndDateDate; }
    public DateTime? EndDateMinDate
    {
        get
        {
            if (DateTime.Now < StartDateDate)
                return StartDateDate;
            else
                return DateTime.Now.AddDays(-1);
        }
    }


    public Zone zone { get; set; }

    public Poster poster { get; set; }

    public void InitializeAggregateObjects()
    {
        zone = new();
        poster = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                posterId = this.poster.id,
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                zone = this.zone.id,
            }
        );
    }
}