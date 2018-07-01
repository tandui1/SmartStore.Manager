using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Core.Base.Model
{
  public  class PagerHelper<T>
    {
        public Pager<T> ToPageList(List<T> source, int pageIndex, int pageSize, int totalCount)
        {
            Pager<T> model = new Pager<T>();
            model.TotalCount = totalCount;
            model.TotalPages = model.TotalCount / pageSize;
            if (model.TotalCount % pageSize > 0)
                model.TotalPages++;
            model.PageSize = pageSize;
            model.PageIndex = pageIndex;
            model.Data = source;
            return model;
        }
    }
}
