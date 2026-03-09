namespace ProfileApi.Models
{
    public class Profile
    {
        public Profile()
        {
        }

        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public Genders Gender { get; set; }

        public int Height { get; set; }

        public string? EyeColor { get; set; }

        public string? BioText { get; set; }

        public enum Genders
        {
            Male,
            Female,
            Other
        }




    }

 }
