namespace handnotes.Contacts.v1.Routes
{
    public class AppRoutes
    {

        #region Base Config

        public const string Root = "api";
        public const string Versions = "v1";
        public const string Base = Root + "/" + Versions;

        #endregion


        #region Posts Route
        public static class Posts
        {
            public const string GetAll = Base + "/posts";
            public const string Get = Base + "/posts/{postId}";
            public const string Update = Base + "/posts/{postId}";
            //public const string Get = Base + "/posts/{postId:Guid}"; // For more specific and secure : Use if Needed;
            public const string Create = Base + "/posts";
            public const string Delete = Base + "/posts/{postId}";

        }


        #endregion

    }
}