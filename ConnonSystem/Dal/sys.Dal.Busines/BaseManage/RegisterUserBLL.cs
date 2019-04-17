﻿using sys.Dal.Entity.BaseManage;
//using sys.Dal.Entity.MessageManage;
using sys.Dal.IService.BaseManage;
using sys.Dal.Service.BaseManage;
using sys.Cache.Factory;
using sys.Util;
using sys.Util.Extension;
using sys.Util.Offices;
using sys.Util.SignalR;
using sys.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using sys.Aplication.Code;
namespace sys.Dal.Busines.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户管理
    /// </summary>
    public class RegisterUserBLL
    {
        private IRegisterUserService service = new RegisterUserService();
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "userCache";

        #region 获取数据
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            return service.GetTable();
        }
        /// <summary>
        /// 用户首字母
        /// </summary>
        /// <returns></returns>
        public DataTable GetInitials()
        {
            return service.GetInitials();
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegisterUserEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegisterUserEntity> GetUserSearch(RegisterUserEntity user)
        {
            return service.GetUserSearch(user);
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RegisterUserEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTable()
        {
            return service.GetAllTable();
        }
        /// <summary>
        /// 用户实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RegisterUserEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// 查询手机号
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public RegisterUserEntity CheckMobile(string Mobile)
        { 
            return service.CheckMobile(Mobile);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue = "")
        {
            return service.ExistAccount(account, keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
                CacheFactory.Cache().RemoveCache(cacheKey);
                UpdateIMUserList(keyValue,false,null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public string SaveForm(string keyValue, RegisterUserEntity userEntity)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(userEntity.SimpleSpelling))
                {
                    if (Str.CheckStringChineseReg(userEntity.RealName))
                    {
                        userEntity.SimpleSpelling = Str.PinYin(userEntity.RealName).ToUpper();
                        userEntity.Initials = userEntity.SimpleSpelling.Substring(0,1);
                    }
                    else
                    {
                        userEntity.SimpleSpelling = userEntity.RealName.ToUpper();
                        userEntity.Initials = userEntity.SimpleSpelling.Substring(0, 1);
                    }
                } 
                keyValue = service.SaveForm(keyValue, userEntity);
                CacheFactory.Cache().RemoveCache(cacheKey);
                //UpdateIMUserList(keyValue, true, userEntity);
                return keyValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="Password">新密码（MD5 小写）</param>
        public void RevisePassword(string keyValue, string Password)
        {
            try
            {
                service.RevisePassword(keyValue, Password);
                CacheFactory.Cache().RemoveCache(cacheKey);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="Password">新密码（MD5 小写）</param>
        public int  ForgetPassword(string Mobile, string Password)
        {
            try
            {
                CacheFactory.Cache().RemoveCache(cacheKey);
               return   service.ForgetPassword(Mobile, Password);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="audit"> 审核结果1，通过，2未通过</param>
        /// <param name="verifyDescribe">备注 </param>
        public void SaveReviseAudit(string keyValue, int audit, string verifyDescribe)
        {
            try
            {
                service.SaveReviseAudit(keyValue, audit, verifyDescribe);
                CacheFactory.Cache().RemoveCache(cacheKey);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="State">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int State)
        {
            try
            {
                service.UpdateState(keyValue, State);
                CacheFactory.Cache().RemoveCache(cacheKey);
                if (State == 0)
                {
                    UpdateIMUserList(keyValue, false, null);
                }
                else
                {
                    RegisterUserEntity entity = service.GetEntity(keyValue);
                    //UpdateIMUserList(keyValue, true, entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public RegisterUserEntity CheckLogin(string username, string password)
        {
            RegisterUserEntity userEntity = service.CheckLogin(username);
            if (userEntity != null)
            {
                if (userEntity.EnabledMark == 1)
                {
                    if (userEntity.VerifyMark == 1)
                    {
                        string dbPassword = Md5Helper.MD5(DESEncrypt.Encrypt(password.ToLower(), userEntity.Secretkey).ToLower(), 32).ToLower();
                        if (dbPassword == userEntity.Password)
                        {
                            DateTime LastVisit = DateTime.Now;
                            int LogOnCount = (userEntity.LogOnCount).ToInt() + 1;
                            if (userEntity.LastVisit != null)
                            {
                                userEntity.PreviousVisit = userEntity.LastVisit.ToDate();
                            }
                            userEntity.LastVisit = LastVisit;
                            userEntity.LogOnCount = LogOnCount;
                            userEntity.UserOnLine = 1;
                            service.UpdateEntity(userEntity);
                            return userEntity;
                        }
                        else
                        {
                            throw new Exception("密码和账户名不匹配");
                        }

                    }
                    else if (userEntity.VerifyMark == 0)
                    {
                        throw new Exception("账户正在审核中");
                    }
                    else
                    {
                        throw new Exception("账户审核未通过，请联系管理员");
                    }
                    
                }
                else
                {
                    throw new Exception("账户名被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
        /// <summary>
        /// 更新实时通信用户列表
        /// </summary>
        private void UpdateIMUserList(string keyValue, bool isAdd, UserEntity userEntity)
        {
            try
            {
                //IMUserModel entity = new IMUserModel();
                //OrganizeBLL bll = new OrganizeBLL();
                //DepartmentBLL dbll = new DepartmentBLL();
                //entity.UserId = keyValue;
                //if (userEntity != null)
                //{
                //    entity.RealName = userEntity.RealName;
                //    entity.DepartmentId = dbll.GetEntity(userEntity.DepartmentId).FullName;
                //    entity.Gender = (int)userEntity.Gender;
                //    entity.HeadIcon = userEntity.HeadIcon;
                //    entity.OrganizeId = bll.GetEntity(userEntity.OrganizeId).FullName; ;
                //}
                //SendHubs.callMethod("upDateUserList", entity, isAdd);
            }
            catch
            {
                
            }
        }
        #endregion

        #region 处理数据
        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        public void GetExportList()
        {
            //取出数据源
            DataTable exportTable = service.GetExportList();
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = "测试用户导出";
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 25;
            excelconfig.FileName = "用户导出.xls";
            excelconfig.IsAllSizeColumn = true;
            //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
            List<ColumnEntity> listColumnEntity = new List<ColumnEntity>();
            excelconfig.ColumnEntity = listColumnEntity;
            ColumnEntity columnentity = new ColumnEntity();
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "account", ExcelColumn = "账户" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "realname", ExcelColumn = "姓名" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "gender", ExcelColumn = "性别" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "birthday", ExcelColumn = "生日" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "mobile", ExcelColumn = "手机", Background = Color.Red });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "telephone", ExcelColumn = "电话", Background = Color.Red });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "wechat", ExcelColumn = "微信" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "manager", ExcelColumn = "主管" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "organize", ExcelColumn = "公司" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "department", ExcelColumn = "部门" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "description", ExcelColumn = "说明" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "createdate", ExcelColumn = "创建日期" });
            excelconfig.ColumnEntity.Add(new ColumnEntity() { Column = "createusername", ExcelColumn = "创建人" });
            //调用导出方法
            ExcelHelper.ExcelDownload(exportTable, excelconfig);
            //从泛型Lis导出
            //TExcelHelper<DepartmentEntity>.ExcelDownload(department.GetList().ToList(), excelconfig);
        }
        #endregion
    }
}
