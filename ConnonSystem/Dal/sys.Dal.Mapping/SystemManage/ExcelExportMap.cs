
using sys.Dal.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace sys.Dal.Mapping.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c)  
    /// �� ������������Ա
    /// �� �ڣ�2017-04-17 12:09
    /// �� ����Excel����
    /// </summary>
    public class ExcelExportMap : EntityTypeConfiguration<ExcelExportEntity>
    {
        public ExcelExportMap()
        {
            #region ��������
            //��
            this.ToTable("Base_ExcelExport");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}