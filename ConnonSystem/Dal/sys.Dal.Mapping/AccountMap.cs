﻿using sys.Dal.Entity;
using System.Data.Entity.ModelConfiguration;

namespace sys.Dal.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2016.05.11 16:23
    /// 描 述：注册账户
    /// </summary>
    public class AccountMap : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMap()
        {
            #region 表、主键
            //表
            this.ToTable("Account");
            //主键
            this.HasKey(t => t.AccountId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
