using Infrastructure.Core;
using Infrastructure.Core.PagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Domain.Service.IService
{
public   interface IBaseService<T,TDto>
    {
        bool Add(TDto dto);

        void Update(TDto dto);

        bool Deleted(Guid id);

        TDto GetById(Guid id);
        TDto GetByFun(Expression<Func<T, bool>> predicate);
        List<TDto> GetAll(Expression<Func<T, bool>> predicate);
        List<TDto> GetAll(Expression<Func<T, bool>> predicate, string order);
        Pager<TDto> GetPage(Expression<Func<T, bool>> where, Action<Orderable<T>> order, ref int totalRecord, int page, int pageSize);

    }
}
