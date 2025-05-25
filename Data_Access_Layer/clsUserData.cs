using Data_Access_Layer_Clinic.DbContext;
using Data_Access_Layer_Clinic.Models;

public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(string username, string password, int permission, int personId)
    {
        var user = new User
        {
            UserName = username,
            Password = password,
            Permission = permission,
            PersonId = personId
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return user.Id;
    }

    public bool Update(int id, string username, string password, int permission, int personId)
    {
        var user = _context.Users.Find(id);
        if (user == null) return false;

        user.UserName = username;
        user.Password = password;
        user.Permission = permission;
        user.PersonId = personId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetByUsernameAndPassword(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
    }

    public User? GetByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.UserName == username);
    }

    public bool Exists(int id)
    {
        return _context.Users.Any(u => u.Id == id);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(u => u.UserName == username);
    }
}
