using Cards.Models;
using DatabaseR;
using Users.Models;

namespace Users.Services;

public interface IUserService
{
    User PostUser(User user);
    User GetUser(string email);
    User UpdateUser(User user);
    User DeleteUser(string email);
}
public class UserService:IUserService
{
    private readonly CardsApi _context;
    public UserService(CardsApi context)
    {
        _context = context;
    }
    public User PostUser(User user)
    {
        try
        {
            User userExist = _context.Users.First( u => u.Email == user.Email);

            if (userExist == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }

            return userExist;
        }
        catch (System.Exception)
        {
            
            throw;
        }


    }
    public User GetUser(string email)
    {
        try
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public User UpdateUser(User user)
    {
        try
        {
            User userExist = _context.Users.First(u => u.Email == user.Email);

            if(userExist != null)
            {
                userExist.Email = user.Email;
                userExist.Name = user.Name;
                userExist.authId = user.authId;
                userExist.Cards = user.Cards;

                if(user.Cards.Count > 0)
                {
                    foreach (var item in user.Cards)
                    {
                        if(!userExist.Cards.Any(c => c.MultiverseId == item.MultiverseId))
                        {
                            userExist.Cards.Add(item);
                        }
                    }
                }
                _context.SaveChanges();
            } 
            return userExist;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public User DeleteUser(string email)
    {
        try
        {
            User userExist = _context.Users.First(u => u.Email == email);

            userExist.isDeleted = !userExist.isDeleted;

            _context.SaveChanges();

            return userExist;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}