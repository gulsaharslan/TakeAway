using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public interface IUserCommentService
    {
        Task<List<ResultUserCommentDto>> GetAllUserCommentAsync();
        Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto userCommentDto);
        Task DeleteUserCommentAsync(int id);
        Task<GetByIdUserCommentDto> GetUserCommentByIdAsync(int id);
        Task<List<ResultUserCommentDto>> GetProductUserCommentAsync(string ProductId);


    }
}
