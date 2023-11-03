using System;
using System.Collections.Generic;
using System.Linq;
using carsaApi.Models;

namespace carsaApi.Data
{


    public class PostsRepo
    {

        private readonly CarsaApiContext _context;

        public PostsRepo(CarsaApiContext context)
        {
            _context = context;
        }









        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public void CreatePost(Post ct)
        {
            if (ct == null)
            {
                throw new ArgumentNullException(nameof(ct));
            }

            _context.Posts.Add(ct);
        }


        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void DeletePost(Post Post)
        {
            if (Post == null)
            {
                throw new ArgumentNullException(nameof(Post));
            }

            _context.Posts.Remove(Post);
        }



        public void UpdatePost(Post cmd)
        {

        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}