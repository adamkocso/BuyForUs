using buyforus.Models;

namespace buyforus.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public string OwnerId { get; set; }
        public Campaign Campaign { get; set; }
    }
}