using System;

public class Breakfast
{
    public Guid Id { get;  }
    public string Name { get;  }
    public string Description { get; }
    public DateTime StartDatetime { get; }
    public DateTime EndDatetime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    public Breakfast (Guid id, string name, string description, DateTime startDatetime, DateTime endDatetime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet)
    {
        // enforce invariants
        Id = id;
        Name = name;
        Description = description;
        StartDatetime = startDatetime;
        EndDatetime = endDatetime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }
}