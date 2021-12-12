namespace ForumSystem.Web.ViewModels.Post
{
    using System;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class CommentsViewModel : IMapFrom<Comment>
    {
        public string Title { get; set; }

        public int PostId { get; set; }

        public string UserUserName { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
