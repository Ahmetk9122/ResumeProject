using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ResumeProject.Dal.Abstract;
using ResumeProject.Dal.Concrete.Entityframework.UnitOfWork;
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

        #region Variables
        private readonly IUnitOfWork unitofWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        #endregion

        #region Constructor

        public GenericManager(IServiceProvider service)
        {
            this.service = service;
            unitofWork = service.GetService<IUnitOfWork>();
            repository = unitofWork.GetRepository<T>();

        }
        #endregion

        #region Methods
        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
               try
            {
                //dto tipi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=> $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = repository.Add(model);

                if (saveChanges)
                    Save();//kaydetme işlemi olduğundan transaction'ı commit'liyoruz.

                //dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto tipi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=> $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = await repository.AddAsync(model);

                if (saveChanges)
                    Save();//kaydetme işlemi olduğundan transaction'ı commit'liyoruz.

                //dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.DeleteById(id);

                if (saveChanges)
                    Save();

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = false
                };
            }
        }

        public Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id));

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = entity
                };
            }
            catch (Exception ex)
            {

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll()
        {
            try
            {
                var list = repository.GetAll();

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                var list = repository.GetAll(expression);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {

                return new Response<List<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<IQueryable<TDto>> GetQueryable()
        {
            try
            {
                var list = repository.GetQueryable();

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x));

                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {

                return new Response<IQueryable<TDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        public IResponse<TDto> Update(TDto item, bool saveChanges = true)
        {
            try
            {
                //dto tipi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.
                var model = ObjectMapper.Mapper.Map<T>(item);
                //var resolvesResult = String.Join(',',model.GetType().GetProperties().Select(x=> $" - {x.Name} : {x.GetValue(model) ?? ""} - "));
                var result = repository.Update(model);

                if (saveChanges)
                    Save();//kaydetme işlemi olduğundan transaction'ı commit'liyoruz.

                //dönüş tipini ayarlıyoruz
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
          unitofWork.SaveChanges();
        }
        #endregion
    }
}
