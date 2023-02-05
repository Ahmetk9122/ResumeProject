using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Organization
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Degree { get; set; }
        public string CertificateUrl { get; set; }
    }
}
