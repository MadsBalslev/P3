using System;
using System.Collections.Generic;
using System.Text.Json;

[APIAttribute("/Posters")]
public class Poster : IManageable
{
    [ManagerMetadata("ID", AccessLevel.SysAdmin, AccessLevel.None, FormRepresentation.None)]
    public int posterId { get; set; } = -1;

    [ManagerMetadata("Name", AccessLevel.User, AccessLevel.User, FormRepresentation.TextField)]
    public string name { get; set; } = "";

    [ManagerMetadata("Start date", AccessLevel.User, AccessLevel.User, FormRepresentation.DatePicker)]
    public DateTime? startDate
    {
        get => _startDate;
        set
        {
            // if (value < endDate || endDate == null)
            if (value <= endDate || endDate == null)
            {
                _startDate = value;
            }
            else
            {
                throw new ArgumentException("startDate can not be after endDate");
            }
        }
    }

    [ManagerMetadata("End date", AccessLevel.User, AccessLevel.User, FormRepresentation.DatePicker)]
    public DateTime? endDate
    {
        get => _endDate;
        set
        {
            if (startDate <= value || startDate == null)
            {
                _endDate = value;
            }
            else
            {
                throw new ArgumentException("endDate can not be before startDate");
            }
        }
    }

    [ManagerMetadata("Creator", AccessLevel.InstAdmin, AccessLevel.None, FormRepresentation.None)]
    public string Creator { get => createdBy.name; }

    [ManagerMetadata("Institution", AccessLevel.SysAdmin, AccessLevel.None, FormRepresentation.None)]
    public string Institution { get => institution.name; }

    [ManagerMetadata("Image url", AccessLevel.User, AccessLevel.User, FormRepresentation.PictureUpload)]
    public string image { get; set; } = "";

    public User createdBy { get; set; } = new User();

    public Institution institution { get; set; } = new Institution();

    private DateTime? _startDate = null;

    private DateTime? _endDate = null;

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                createdBy = this.createdBy.id,
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                imageUrl = this.image

            }
        );
    }
}