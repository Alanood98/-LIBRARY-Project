using LIBRARYEFCoreAndDatabase;
using Microsoft.EntityFrameworkCore;
using LIBRARYEFCoreAndDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Repository
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Bookes.ToList();
        }

        public Book GetByName(string Bname)
        {
            return _context.Bookes.Find(Bname);
        }

        public void Add(Book book)
        {
            _context.Bookes.Add(book);
            _context.SaveChanges();
        }

        public void UpdateByName(Book name)
        {
            _context.Bookes.Update(name);
            _context.SaveChanges();
        }
        public Book GetById(int BID)
        {
            return _context.Bookes.Find(BID);
        }
        public void Delete(int BID)
        {
            var book = GetById(BID);
            if (book != null)
            {
                _context.Bookes.Remove(book);
                _context.SaveChanges();
            }
        }

        public decimal GetTotalPrice()
        {
            return _context.Bookes.Sum(b => b.Price);
        }
        public decimal getMaxPrice()
        {
            return _context.Bookes.Max(b => b.Price);
        }
        public int getTotalBorrowedBooks()
        {
            return _context.Bookes.Sum(b => b.BorrowedCopies);
        }
        public int getTotalBooksPerCategoryName(string Cname)
        {
            return _context.Bookes
                            .Where(b => b.category.Cname == Cname)
                            .Count();
        }

    }
}
