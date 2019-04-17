using sys.Dal.Entity.PublicInfoManage;
using sys.Dal.IService.PublicInfoManage;
using sys.Dal.Service.PublicInfoManage;
using sys.Util.WebControl;
using System.Collections.Generic;
using System;

namespace sys.Dal.Busines.PublicInfoManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创 建：佘赐雄
    /// 日 期：2016-04-25 10:45
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleBLL
    {
        private IScheduleService service = new ScheduleService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<ScheduleEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ScheduleEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ScheduleEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
