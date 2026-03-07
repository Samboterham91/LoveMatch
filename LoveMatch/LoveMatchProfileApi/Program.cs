//using ProfileApi.Models;

//public class Program
//{
//    static void Main(string[] args)
//    {
//        Profile profile = new Profile();
//        Console.WriteLine("Fill in your first name");

//        profile.FirstName = Console.ReadLine();
//        Console.WriteLine("Fill in your last name");
//        profile.LastName = Console.ReadLine();

//        Console.WriteLine("Fill in your date of birth (dd-mm-yy)");
//        profile.DateOfBirth = Convert.To(Console.ReadLine());

//        Console.WriteLine(profile.ToString());
//        Console.WriteLine("What is your gender?");
//        profile.Gender = 

//        Console.WriteLine("What is your heigt?(cm)");
//        profile.Height = Convert.ToInt32(Console.ReadLine());

//        Console.WriteLine("What is your eye color?");
//        profile.EyeColor = Console.ReadLine();

//        Console.WriteLine("Write here a short bio text");
//        profile.BioText = Console.ReadLine();



//    }
//}


using ProfileApi.Controllers;
using ProfileApi.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ProfileService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Dating API",
        Version = "v2"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Dating API v2");
        c.ConfigObject.AdditionalItems["persistAuthorization"] = true;
    });
}

app.UseHttpsRedirection();


app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();