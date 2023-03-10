using ResumeProject.Entity.Base;
using ResumeProject.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResumeProject.Interface
{
    public interface IGenericService<T,TDto> where T : IEntityBase where TDto:IDtoBase
    {
        //Listeleme
        IResponse<List<TDto>> GetAll();
        //Filtreli Listeleme
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        //Getirme
        IResponse<TDto> Find(int id );
        //Kaydetme

        //sistem bir tane ekleme yapacağı zaman yapabilir
        //ancak birden fazla ekleme yapacağı zaman biz işlemleri biriktirerek daha sonra yapmak istiyorsak saveChanges değerini false verip kendimiz yönetebiliriz.
        //Transaction için kurulan yapımız.
        IResponse<TDto> Add(TDto item,bool saveChanges =true);
        //Async Kaydetme
        //Asenkron yapı ilgili işlem bitmeden diğer işlemlerin devam edebilmesini sağlıyor. 
        Task<IResponse<TDto>>  AddAsync(TDto item, bool saveChanges = true);
        //Güncelleme
        IResponse<TDto> Update(TDto item, bool saveChanges = true);
        //Async Güncelleme
        Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true);
        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
        //Async Silme
        Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);
        //IQueryable Listeleme
        //performans için IQueryable çalıştırılır.
        IResponse<IQueryable<TDto>> GetQueryable();
        void Save();
        //Params ile getirme
        //Patch ile güncelleme

        //Task Asenkronlaştırma tekniği 
        //unit of works transaction yönetimi tekniği
        //Ienumerayble bütün veriyi çeker ve bellekte sonucu döndürmeye çalışır.
        //IQueryable sorguyu database de yapar ve sonucu döndürür. bütün veiyi çekmediği için bizim için daha hızlı ve kullanışlıdır.
        // List mantığı => bir sorgumuz var ve çıktı için sürekli sorguları ekliyoruz Kocaelinde yaşayan arabası olan rengi beyaz olan bütün sorgu bittiğinde ve toList
        //dediğimizde bize gerekli olan sorguyu döndürür.

    }
}
