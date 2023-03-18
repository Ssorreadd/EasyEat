namespace EasyEat.HelperClasses
{
    public static class User
    {
        public static string? Gender { get; set; }
        public static string? Age { get; set; }
        public static string? Weight { get; set; }
        public static string? Height { get; set; }
        public static double Activity 
        {
            get
            {
                return 1.55;
            }
            private set { Activity = value; }
        }
    }
}