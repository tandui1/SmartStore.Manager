
using SmartStore.Manager.Model.BaseEntity;
using SmartStore.Manager.Service.Interface.Repository;
using SmartStore.Manager.Service.Interface.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Manager.Domain
{
   public interface IBaseApp<T,TDto> where T : Entity
    {
        /// <summary>
        /// 用于事务操作
        /// </summary>
        /// <value>The unit work.</value>
         IUnitWork UnitWork { get; set; }
        /// <summary>
        /// 用于普通的数据库操作
        /// </summary>
        /// <value>The repository.</value>
        IRepository<T> Repository { get; set; }

        /// <summary>
        /// 按id批量删除
        /// </summary>
        /// <param name="ids"></param>
        void Delete(string[] ids);
        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //bool Add(T model);
        /// <summary>
        /// 根据ID返回对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(string id);
        /// <summary>
        /// 返回子节点
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="entity"></param>
        void ChangeModuleCascade<U>(U entity) where U : TreeEntity;
    }
}
