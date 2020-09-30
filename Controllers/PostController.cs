using System;
using System.Threading.Tasks;
using handnotes.Contacts.v1.Requests;
using handnotes.Contacts.v1.Responses;
using handnotes.Contacts.v1.Routes;
using handnotes.Domain;
using handnotes.Services;
using Microsoft.AspNetCore.Mvc;

namespace handnotes.Controllers
{

    public class PostController : Controller
    {
        // It's gonna fed-up
        // Will be refactor soon...KEEP CLAM

        #region PostService
        private readonly IPostService _postService;

        #endregion

        #region Constructor

        public PostController (IPostService service)
        {
            _postService = service;
        }

        #endregion

        #region GetAllPosts

        [HttpGet(AppRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll ()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        #endregion

        #region GetPostByIdAsync

        [HttpGet(AppRoutes.Posts.Get)]
        public async Task<IActionResult> Get ([FromRoute] Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            if (post == null) return NotFound();
            return Ok(post);
        }

        #endregion

        #region UpdatePostAsync
        [HttpPut(AppRoutes.Posts.Update)]
        public async Task<IActionResult> Update ([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            post.Title = request.Title;
            post.Descriptions = request.Descriptions;

            var isUpdate = await _postService.UpdatePostAsync(post);
            if (isUpdate)
            {
                return Ok(post);
            }

            return NotFound();
        }


        #endregion

        #region CreatePostASync

        [HttpPost(AppRoutes.Posts.Create)]
        public async Task<IActionResult> Create ([FromBody] CreatePostRequest postRequest)
        {

            Post post = new Post { Title = postRequest.Title,Descriptions = postRequest.Descriptions ,Id = Guid.NewGuid()};
            await _postService.CreatePostASync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}:// {HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + AppRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };
            return Created(locationUrl, response);

        }

        #endregion

        #region DeletePostAsync

        [HttpDelete(AppRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete ([FromRoute] Guid postId)
        {
          
            var isDeleted = await _postService.DeletePostAsync(postId);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        #endregion
    }
}