﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.Dal.Entity.AppManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件分类
    /// </summary>
    public class MessageReadEntity: BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 邮件分类主键
        /// </summary>		
        public string Uniqueid { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>		
        public string MessageId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public string UserId { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>		
        public bool? Flag { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>		
        public bool IsRead { get; set; }
        /// <summary>
        /// 收藏
        /// </summary>		
        public bool IsLike { get; set; }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime? LikeDate { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public int? Score { get; set; }
        /// <summary>
        /// 评分时间
        /// </summary>
        public DateTime? ScoreDate { get; set; }
        /// <summary>
        /// 分类  1：会议，2:公告
        /// </summary>		
        public string Category { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>		
        public bool AppRead { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>		
        public bool PCRead { get; set; } 
        /// <summary>
        /// 签到标识
        /// </summary>
        public bool SignInMark { get; set; }
        /// <summary>
        /// 确认参会标识
        /// </summary>
        public bool AttendExpo { get; set; }
        /// <summary>
        /// 执行提交操作
        /// </summary>
        public bool SubmitMark { get; set; }
        /// 执行提交操作 时间
        public DateTime? SubmitDate { get; set; }
        
        /// <summary>
        /// 签到备注
        /// </summary>
        public string SignInDescription { get; set; }
        
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>		
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>		
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 签到日期
        /// </summary>		
        public DateTime? SignInDate { get; set; }
        
        /// <summary>
        /// 修改用户主键
        /// </summary>		
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>		
        public string ModifyUserName { get; set; }


        
        #endregion

        #region 扩展操作

        #endregion
    }
}
