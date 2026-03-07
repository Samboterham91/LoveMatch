namespace ProfileApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        private string? Password { get; set; }

        public int LocationId { get; set; }

        public Profile? Profile { get; set; }

        public User()
        {

        }
    }
}
