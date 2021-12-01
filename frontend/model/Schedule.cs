using System;
using System.Text.Json;

public class Schedule : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? StartDateDate
    {
        get => GetDate(startDate);
        set => startDate = UpdateDate(value, this.startDate, StartDateTime);
    }

    public TimeSpan? StartDateTime
    {
        get => GetTime(startDate);
        set => startDate = UpdateTime(value, startDate);
    }

    public DateTime? endDate { get; set; }

    public DateTime? EndDateDate
    {
        get => GetDate(endDate);
        set => endDate = UpdateDate(value, endDate, StartDateTime);
    }

    public TimeSpan? EndDateTime
    {
        get => GetTime(endDate);
        set => endDate = UpdateTime(value, endDate);
    }

    public DateTime? StartDateMinDate { get => DateTime.Now.AddDays(-1); }

    public DateTime? StartDateMaxDate { get => EndDateDate; }

    public TimeSpan? StartDateMaxTime { get => TimeConstraintHelper(EndDateTime); }

    public DateTime? EndDateMinDate { get => StartDateDate; }

    public TimeSpan? EndDateMinTime { get => TimeConstraintHelper(StartDateTime); }

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

    private DateTime? GetDate(DateTime? source)
    {
        if (source != null)
        {
            DateTime sourceCast = (DateTime)source;
            return sourceCast.Date;
        }
        return null;
    }

    private DateTime? UpdateDate(DateTime? value, DateTime? update, TimeSpan? timeOffset)
    {
        if (value != null && update != null)
            return value + timeOffset;
        else if (value != null && update == null)
            return value;
        else
            return null;
    }

    private TimeSpan? GetTime(DateTime? source)
    {
        if (source != null)
        {
            DateTime sourceCast = (DateTime)source;
            return sourceCast.TimeOfDay;
        }
        return null;
    }

    private DateTime? UpdateTime(TimeSpan? value, DateTime? update)
    {
        if (value != null && update != null)
            return update + value;
        else if (value != null && update == null)
            return DateTime.Now.AddDays(-1) + value;
        else
            return null;
    }

    private TimeSpan? TimeConstraintHelper(TimeSpan? source)
    {
        if (StartDateDate == EndDateDate)
            return source;
        else
            return null;
    }
}