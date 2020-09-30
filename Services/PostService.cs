using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using handnotes.Data;
using handnotes.Domain;
using Microsoft.EntityFrameworkCore;

namespace handnotes.Services
{
    public class PostService : IPostService
    {

        private readonly ApplicationDbContext _dataContext;

        #region Constructor
        public PostService (ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

        }


        #endregion

        #region GetPostByIdAsync
        public async Task<Post> GetPostByIdAsync (Guid postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(post => post.Id == postId);
        }



        #endregion

        #region UpdatePostAsync
        public async Task<bool> UpdatePostAsync (Post updatePost)
        {

            _dataContext.Posts.Update(updatePost);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }


        #endregion

        #region GetPostsAsync

        public async Task<List<Post>> GetPostsAsync ()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        #endregion

        #region DeletePostAsync

        public async Task<bool> DeletePostAsync (Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            if (post == null)
            {
                return false;
            }
            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }


        #endregion

        #region CreatePostASync

        public async Task<bool> CreatePostASync (Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        #endregion
    }
}