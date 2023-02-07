using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    //partial class bir classı parçalamak için kullanılır.
    //aynı isimde iki class olmaz ancak partial kullanarak oluşturabiliriz.
    //Certificate class ise bir tane tanımlanabilir ancak birden fazla olması için partial olarak yapılabilir.
    public partial class Skill : EntityBase
    {
        public Skill()
        {
            Certificates = new HashSet<Certificate>();
            Projects = new HashSet<Project>();
            WorkExperiences = new HashSet<WorkExperience>();
        }

        public int Id { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
