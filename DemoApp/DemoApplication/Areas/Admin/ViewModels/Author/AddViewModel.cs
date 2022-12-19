namespace DemoApplication.Areas.Admin.ViewModels.Author
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AddViewModel(int id, string firstname, string lastName)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastName;
        }
    }
}
