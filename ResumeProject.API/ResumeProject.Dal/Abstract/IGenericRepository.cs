using ResumeProject.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Dal.Abstract
{
    public interface IGenericRepository<T> where T:IEntityBase
    {
        //Veri tabanına kaydetme katmanı dal dan bll e T döner Bll den Api katmanına TDto olur.



        //Listeleme
        List<T> GetAll();
        //Filtreli Listeleme
         List<T> GetAll(Expression<Func<T, bool>> expression);
        //Getirme
         T Find(int id);
        //Kaydetme

        //sistem bir tane ekleme yapacağı zaman yapabilir
        //ancak birden fazla ekleme yapacağı zaman biz işlemleri biriktirerek daha sonra yapmak istiyorsak saveChanges değerini false verip kendimiz yönetebiliriz.
        //Transaction için kurulan yapımız.
        T Add(T item);
        //Async Kaydetme
        //Asenkron yapı ilgili işlem bitmeden diğer işlemlerin devam edebilmesini sağlıyor. 
        Task<T> AddAsync(T item);
        //Güncelleme
        T Update(T item);
        //Silme
        bool DeleteById(int id);
        //Nesne silme
        bool Delete(T item);
        //IQueryable Listeleme
        //performans için IQueryable çalıştırılır.
        IQueryable<T> GetQueryable();
    }
}
