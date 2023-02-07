using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    //partial class bir classı parçalamak için kullanılır.
    //aynı isimde iki class olmaz ancak partial kullanarak oluşturabiliriz.
    //Certificate class ise bir tane tanımlanabilir ancak birden fazla olması için partial olarak yapılabilir.
    public partial class Technology : EntityBase
    {
        public Technology()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
