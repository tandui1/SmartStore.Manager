using SmartStore.Manager.Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base.Impl
{
   public interface IBaseService<T, TDto>
    {
        long Add(TDto dto);

        bool Update(TDto dto);

        bool Deleted(long id);

        TDto GetById(long id);
        TDto GetByFun(Expression<Func<T, bool>> where);
        List<TDto> GetAll(Expression<Func<T, bool>> where);
        PagerHelper<TDto> GetPageList(Expression<Func<T, bool>> where, int pageIndex, int pageSize, ref int totalRecord);
    }
}
