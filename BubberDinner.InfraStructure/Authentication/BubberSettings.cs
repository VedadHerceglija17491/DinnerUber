
namespace BubberDinner.InfraStructure.Authentication;
public class BubberSettings
{
   public string SecretKey {get; init; } = null!;
   public string Issuer {get; init; } = null!;
   public int ExpirationHours {get; init; } 

}