using LIBRARYEFCoreAndDatabase;
using Microsoft.EntityFrameworkCore;
using LIBRARYEFCoreAndDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Repositories
{
    public class AdminRepository
    {


        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Admin> GetAll()
        {
            return _context.Admines.ToList();
        }

        



        public Admin GetByName(string name)
        {
            return _context.Admines.Where(a => a.Aname == name).FirstOrDefault();
        }
        public void Insert(Admin admin)
        {
            _context.Admines.Add(admin);
            _context.SaveChanges();
        }

        public void UpdateByName(string name)
        {
            var admin = _context.Admines.FirstOrDefault(a => a.Aname == name);
            if (admin != null)
            {
                _context.Admines.Add(admin);
                _context.SaveChanges();
            }
        }
        public Admin GetById(int AID)
        {
            return _context.Admines.Find(AID);
        }
        public void Delete(int AID)
        {
            var admin = GetById(AID);
            if (admin != null)
            {
                _context.Admines.Remove(admin);
                _context.SaveChanges();
            }
        }

       

    }
}
