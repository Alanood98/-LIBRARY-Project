using LIBRARYEFCoreAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LIBRARYEFCoreAndDatabase.Models.User;

namespace LIBRARYEFCoreAndDatabase.Repository
{
    public class UserRepository { 
      private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<User> GetAll()
    {
        return _context.Useres.ToList();
    }





    public User GetByName(string name)
    {
        return _context.Useres.Where(a => a.Uname == name).FirstOrDefault();
    }
    public void Insert(User user)
    {
        _context.Useres.Add(user);
        _context.SaveChanges();
    }

    public void UpdateByName(string name)
    {
        var user = _context.Useres.FirstOrDefault(a => a.Uname == name);
        if (user != null)
        {
            _context.Useres.Add(user);
            _context.SaveChanges();
        }
    }
    public User GetById(int UID)
    {
        return _context.Useres.Find(UID);
    }
    public void Delete(int UID)
    {
        var user = GetById(UID);
        if (user != null)
        {
            _context.Useres.Remove(user);
                _context.SaveChanges();
            }
        }

        public int countByGender(gender gender)
        {
            return _context.Useres.Count(e => e.Ugender == gender);
        }



    }
}
