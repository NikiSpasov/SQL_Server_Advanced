namespace TeamBuilder.App.Utilities
{
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context.Invitations
                    .Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context
                    .Teams
                    .Any(t => t.Name == teamName && t.Creator == user);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context
                    .Events
                    .Any(e => e.Name == eventName && e.Creator == user);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context.Teams
                    .Single(t => t.Name == teamName)
                    .UserTeams.Any(ut => ut.User.Username == username);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderDbContext context = new TeamBuilderDbContext())
            {
                return context.Events
                    .Any(e => e.Name == eventName);
            }
        }
    }
}
