using LIBRARYEFCoreAndDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Repository
{
    public class CategoryRepository
    {

        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categoryes.ToList();
        }


        public Category GetByName(string name)
        {
            return _context.Categoryes.Where(a => a.Cname == name).FirstOrDefault();
        }
        public void Insert(Category category)
        {
            _context.Categoryes.Add(category);
            _context.SaveChanges();
        }

        public void UpdateByName(string name)
        {
            var category = _context.Categoryes.FirstOrDefault(a => a.Cname == name);
            if (category != null)
            {
                _context.Categoryes.Add(category);
                _context.SaveChanges();
            }
        }
        public Category GetById(int CID)
        {
            return _context.Categoryes.Find(CID);
        }
        public void Delete(int CID)
        {
            var category = GetById(CID);
            if (category != null)
            {
                _context.Categoryes.Remove(category);
                _context.SaveChanges();
            }
        }



    }
}

