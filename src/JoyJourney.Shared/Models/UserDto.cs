namespace JoyJourney.Shared.Models;

using JoyJourney.Data.Entities;

public record UserDto(string FirstName, string LastName, string UserName)
{
    public ApplicationUser MapToDomain()
    {
        return new ApplicationUser
        {
            FirstName = FirstName,
            LastName = LastName,
            UserName = UserName
        };
    }

    public static UserDto FromDomain(ApplicationUser user)
    {
        return new UserDto(user.FirstName, user.LastName, user.UserName!);
    }
}
