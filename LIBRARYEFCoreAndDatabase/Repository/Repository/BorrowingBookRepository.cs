using LIBRARYEFCoreAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Repository
{
    public class BorrowingBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BorrowingBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public IEnumerable<BorrowingBook> GetAll()
        {
            return _context.BorrowingBookes.ToList();
        }
        public IEnumerable<BorrowingBook> GetBookByName(string BName)
        {
            return _context.BorrowingBookes
                    .Include(e => e.book)
                    .Where(e => e.book.Bname == BName)
                    .ToList();
        }
        public void Insert(BorrowingBook borrow)
        {
            _context.BorrowingBookes.Add(borrow);
            _context.SaveChanges();
        }
        public void UpdateByBookName(string Name)
        {
            var borrow = _context.BorrowingBookes.
                        Include(e => e.book)
                        .FirstOrDefault(c => c.book.Bname == Name);
            if (borrow != null)
            {
                _context.BorrowingBookes.Update(borrow);
                _context.SaveChanges();
            }
        }
        public void DeleteById(int Bid, int Uid)
        {
            var borrow = _context.BorrowingBookes.Find(Bid, Uid);
            if (borrow != null)
            {
                _context.BorrowingBookes.Remove(borrow);
                _context.SaveChanges();
            }
        }


    }
}

