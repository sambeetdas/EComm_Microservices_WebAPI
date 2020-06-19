using System;

namespace Model
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public Guid GeoLocationId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleInit { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string MaritialStatus { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string CompanyName { get; set; }
        public string JoinDate { get; set; }
        public string SourceCode { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string PrimaryCountryCode { get; set; }
        public string SecondaryCountryCode { get; set; }
        public string AcceptsText { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string SocialTagCode { get; set; }
        public string SocialUserName { get; set; }
        public string Url { get; set; }
    }
}
