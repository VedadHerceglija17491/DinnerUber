using BubberDinner.Application.Common.Interfaces.Services;

namespace BubberDinner.InfraStructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
      public DateTime UtcNow => DateTime.UtcNow;
}