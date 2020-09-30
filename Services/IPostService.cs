using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using handnotes.Domain;

namespace handnotes.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync ();
        Task<bool> CreatePostASync (Post post);
        Task<Post> GetPostByIdAsync (Guid postId);
        Task<bool> UpdatePostAsync (Post updatePost);
        Task<bool> DeletePostAsync (Guid postId);

        //Task<bool> UserOwnPostAsync (Guid postId, string getUserId);
    }
}
