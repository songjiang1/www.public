
using sys.Dal.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace sys.Dal.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c)  
    /// �� ������������Ա
    /// �� �ڣ�2017-03-01 09:20
    /// �� ����ѧ����
    /// </summary>
    public class studentMap : EntityTypeConfiguration<studentEntity>
    {
        public studentMap()
        {
            #region ������
            //��
            this.ToTable("student");
            //����
            this.HasKey(t => t.id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
