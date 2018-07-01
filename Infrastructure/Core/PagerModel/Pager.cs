using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.PagerModel
{
    /// <summary>
    /// 分页实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
  public  class Pager<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }
    }
    /// <summary>
    /// 分页辅助
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageHelper<T>
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
            model.Items = source;
            return model;
        }
    }
   
}
