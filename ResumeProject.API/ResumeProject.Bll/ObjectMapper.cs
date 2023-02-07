using AutoMapper;
using ResumeProject.Entity.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Bll
{
    //kalıtım yöntemiyle yapılırsa class => protected
    //türetme yöntemiyle yapılırsa class => internal
    //Herbir class a kalıtım vermemek için türetme yöntemiyle yaptık.

    internal class ObjectMapper
    {
        //Proje ayağa kaltığında yok ancak Neyen ne zaman ihtiyacımız varsa o zaman kullanılacak
        //Tek bir tane mapping Profile olmasına gerek yok proje büyüklüğüne göre birden fazla mapping profile olabilir.Örn => stok ,müşteri mapping profile gibi.
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;
    }
}
