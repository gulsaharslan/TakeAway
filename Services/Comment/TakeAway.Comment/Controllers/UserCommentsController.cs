using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Comment.Dtos;
using TakeAway.Comment.Services;

namespace TakeAway.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly IUserCommentService _userCommentService;

        public UserCommentsController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserCommentList()
        {
            var values=await _userCommentService.GetAllUserCommentAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserComment(CreateUserCommentDto createUserCommentDto)
        {
            await _userCommentService.CreateUserCommentAsync(createUserCommentDto);
            return Ok("Yorum eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserComment(int id)
        {
            await _userCommentService.DeleteUserCommentAsync(id);
            return Ok("Yorum silindi");
        }

        [HttpGet("{GetUserCommentById}")]
        public async Task<IActionResult> GetUserCommentById(int id)
        {
            var values = await _userCommentService.GetUserCommentByIdAsync(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
        {
            await _userCommentService.UpdateUserCommentAsync(updateUserCommentDto);
            return Ok("Yorum güncellendi");
        }

        
    }
}
