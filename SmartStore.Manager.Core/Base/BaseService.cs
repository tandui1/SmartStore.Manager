using SmartStore.Manager.Core.Base.Impl;
using SmartStore.Manager.Core.Base.Model;
using SmartStore.Manager.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : BaseEntity
    {
        IRepository<T> _baseRepository;
        public long Add(TDto dto)
        {
            return _baseRepository.Add(AutoMapper.Mapper.Map<T>(dto));
        }

        public bool Deleted(long id)
        {
            _baseRepository.Delete(id);
            return true;
        }

        public List<TDto> GetAll(Expression<Func<T, bool>> where)
        {
          return AutoMapper.Mapper.Map<List<TDto>>(_baseRepository.GetAll(where));
        }

       

        public TDto GetByFun(Expression<Func<T, bool>> where)
        {
            return AutoMapper.Mapper.Map<TDto>(_baseRepository.GetAll(where));
        }

        public TDto GetById(long id)
        {
            return AutoMapper.Mapper.Map<TDto>(_baseRepository.GetSingle(id));
        }

        public PagerHelper<TDto> GetPageList(Expression<Func<T, bool>> where, int pageIndex, int pageSize, ref int totalRecord)
        {
            return AutoMapper.Mapper.Map<PagerHelper<TDto>>(_baseRepository.GetAll(where,pageIndex,pageSize, ref totalRecord));
        }

        public bool Update(TDto dto)
        {
            return _baseRepository.Update(AutoMapper.Mapper.Map<T>(dto))>0;
        }
    }
}
