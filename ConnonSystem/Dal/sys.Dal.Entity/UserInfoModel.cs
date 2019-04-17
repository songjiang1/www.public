﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.Dal.Entity
{
    /// <summary>
    /// 版 本
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2016.04.21 09:58
    /// 描 述：连接用户信息类(包括web端登录,或者接口形式的连接)
    /// </summary>
    public class UserInfoModel
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime ConnectTime { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 对象用户关系Id,对象分类:1-部门2-角色3-岗位4-群组
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 登录IP地址所在地址
        /// </summary>
        public string IPAddressName { get; set; }
        /// <summary>
        /// 是否系统账户；拥有所以权限
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Secretkey { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 用户来源 如 微信用户，APP用户
        /// </summary>
        public string Usource { get; set; }

        #region MyRegion 新增字段
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        public string Identity { get; set; }
        /// <summary>
        /// 党派
        /// </summary>
        public string Party { get; set; }
        /// <summary>
        /// 审核标记 1通过审核； 0提交；2打回，信息有误
        /// </summary> 
        public int VerifyMark { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        #endregion
    }
}
