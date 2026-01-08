namespace Localhost.AI.KaonashiWeb.Models
{
    public class Cv : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AddressStreet { get; set; } = string.Empty;
        public string AddressNumber { get; set; } = string.Empty;
        public string AddressCity { get; set; } = string.Empty;
        public string AddressZip { get; set; } = string.Empty;
        public string AddressCountry { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string LinkedInProfile { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();   
        public List<string> Skills { get; set; } = new List<string>();
        public List<Creation> Creations { get; set; } = new List<Creation>();
    }

    public class Experience
    {
        public string Company { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new List<string>();
        
    }

    public class Creation
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class Education
    {
        public string Institution { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string FieldOfStudy { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

