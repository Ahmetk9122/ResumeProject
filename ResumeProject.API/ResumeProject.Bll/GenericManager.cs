using ResumeProject.Entity.Base;
using ResumeProject.Entity.IBase;
using ResumeProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Bll
{
    public class GenericManager<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        //Bir class bir internfaceden kalıtım aldığında implemente etme zorunluluğu vardır.
        //Bir class bir classdan kalıtım aldığında implement etme zorunluluğu yoktur direk üst sınıf protected ve public olan özellikleri kullanabilir.
        //Bir sınıfı abstract tasarlarsak (GenericService örn)  abstract classtan nesne türetemeyiz amacı bir şablon oluşturmak ve kalıtım vererek kullanmayı sağlar
        //Kalıtım verebilirim ve abstract classtan nesne türetemem. 
        //Soru=> bir class var nesne türetebileyim ancak kesinlikle kaltıım veremeyim.
        //Cevap =>sealed yaparsak kalıtım verilemez ancak türetmeye devam edebiliriz. => public sealed GenericManager.
        //Lazyloading  avantajları order çektiğimizde order a bağlı tüm alt detaylarla birlikte gelir örneğin orderin içinde order detail ve customer bilgileri
        //varsa lazy loadıng yaptığımızda her şey gelir. Avantajı az kod çok iş dezavantajı sorgu süresi uzar.
        //EagerLoading de Orderi çekersek sadece order gelir eğer order içinde OrderDetail veya cstomer bilgisini de istersek ozaman include ile içine aktarırız.
        //unitOfWork
        //IServiceProvider
        //GenericRepository
        //constructor
        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDto> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
