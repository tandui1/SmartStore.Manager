using Infrastructure.Core;
using Infrastructure.Core.BaseEntity;
using Infrastructure.Core.PagerModel;
using SmartStore.Manager.Domain.Service.IService;
using SmartStore.Manager.Repository.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace SmartStore.Manager.Domain.Service
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : BaseEntity
    {
        IBaseRepository<T> _baseRepository;
        public bool Add(TDto dto)
        {
           return this._baseRepository.Add(AutoMapper.Mapper.Map<T>(dto)).OID!=null?true:false;
        }

        public bool Deleted(Guid id)
        {
            //this._baseRepository.FindSingle
            return this._baseRepository.Delete(a=>a.OID==id)>0;
        }

        public List<TDto> GetAll(Expression<Func<T, bool>> predicate)
        {
            return AutoMapper.Mapper.Map<List<TDto>>(this._baseRepository.Find(predicate).ToList());
        }

        public List<TDto> GetAll(Expression<Func<T, bool>> predicate, string order)
        {
            var query = this._baseRepository.FindBy(predicate,a => a.Desc(o => order));
            return AutoMapper.Mapper.Map<List<TDto>>(query.ToList());
        }

        public TDto GetByFun(Expression<Func<T, bool>> predicate)
        {
            return AutoMapper.Mapper.Map<TDto>(this._baseRepository.FindSingle(predicate));
        }

        public TDto GetById(Guid oid)
        {
            return AutoMapper.Mapper.Map<TDto>(this._baseRepository.FindSingle(a=>a.OID==oid));
        }

        public Pager<TDto> GetPage(Expression<Func<T, bool>> where, Action<Orderable<T>> order , ref int totalRecord,int page, int pageSize)
        {

            return AutoMapper.Mapper.Map<Pager<TDto>>(this._baseRepository.Find(where, order, ref totalRecord,page, pageSize));
        }

        public void Update(TDto dto)
        {
            this._baseRepository.Update(AutoMapper.Mapper.Map<T>(dto));
        }
    }
}
