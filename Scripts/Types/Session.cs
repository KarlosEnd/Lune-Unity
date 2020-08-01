namespace Lune {
    public class User {
        public int ban_time { get; set; }
        public string ban_reason { get; set; } 
        public string _id { get; set; } 
        public string email { get; set; } 
        public string firstName { get; set; } 
        public string lastName { get; set; } 
        public string username { get; set; } 
        public int __v { get; set; } 
    }

    public class Session {public string address { get; set; } 
        public string token { get; set; } 
        public User user { get; set; } 
        public bool success { get; set; } 

        public string error { get; set; }
    }
}