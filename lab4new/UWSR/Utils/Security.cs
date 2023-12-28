using UWSR.Models;

namespace UWSR.Utils
{
    public static class Security
    {
        public static bool CheckIsAdmin(HttpContext context)
        {
            var check = context.Session.Get("isAdmin");
            if (check == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckIsCommentUser(HttpContext context, Comment comment)
        {
            if (comment.SessionId != context.Session.Id)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
