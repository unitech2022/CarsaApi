using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class CommentsRepo
    {

        private readonly CarsaApiContext _context;

        public CommentsRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public void CreateComment(Comment ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Comments.Add(ct);
        }


        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteComment(Comment Comment)
        {
            if (Comment == null)
            {
                throw new ArgumentNullException(nameof(Comment));
            }

            _context.Comments.Remove(Comment);
        }



        public void UpdateComment(Comment cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}