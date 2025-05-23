﻿using Microsoft.AspNetCore.Identity;

namespace SocialAssistanceFundApp.Models.ApplicationInfo
{
    public class Approver : IdentityUser
    {
        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        public string LastName { get; set; }
    }
}
