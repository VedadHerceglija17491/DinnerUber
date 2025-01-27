using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Domain.Entities;
using BubberDinner.Application.Common.Interfaces.Persistance;

namespace BubberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Login (string email, string password)
    {
        //1 validate user exist
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }

        //2 validate the password is correct

        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        //3 create jwt token

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check if user exist

        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exist"); 
        }

        //create user

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);


        var token = _jwtTokenGenerator.GenerateToken(user);
        
           return new AuthenticationResult(user, token);
    }
}