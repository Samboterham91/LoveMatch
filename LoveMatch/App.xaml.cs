namespace LoveMatch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Start met BioSelectionPage in NavigationPage
            MainPage = new NavigationPage(new BioSelectionPage());
        }
    }
}