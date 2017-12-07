namespace Forum.App
{
    using AutoMapper;
    using Forum.App.Models;
    using Forum.Models;

    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<Post, PostDetailsDto>()
                .ForMember(
                    replyDto => replyDto.ReplyCount, 
                    opt => opt.MapFrom(post => post.Replies.Count));

           CreateMap<Reply, ReplyDto>();

            CreateMap<User, User>();
        }
    }
}
