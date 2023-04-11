using System;

public class Breakfast
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDatetime { get; set; }
    public DateTime EndDatetime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }
    public List<string> Savory { get; set; }
    public List<string> Sweet { get; set; }

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