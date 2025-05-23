namespace SocialAssistanceFundApp.Models.ViewModels
{
    public class ApplicantViewModel
    {
        public string Sex { get; set; }

        public string MaritalStatus { get; set; }
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string IdNumber { get; set; }

        public string Village { get; set; }

        public string? TelePhoneContact { get; set; }

        public string FullName
        {
            get
            {
                var names = new List<string> { FirstName };

                if (!string.IsNullOrWhiteSpace(MiddleName))
                    names.Add(MiddleName);

                names.Add(LastName);

                return string.Join(" ", names);
            }
        }
    }
}
