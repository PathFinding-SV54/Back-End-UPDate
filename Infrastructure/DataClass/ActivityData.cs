using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DataClass;

public class ActivityData
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime Date { get; set; }
}