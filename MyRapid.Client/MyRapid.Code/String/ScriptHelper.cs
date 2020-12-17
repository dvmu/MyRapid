/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
namespace MyRapid.Code
{
    public static class ScriptHelper
    {
        public static string GenerateSql(string TableName, List<Sys_Schema> sys_Schemas, string Operation)
        {
            switch (Operation)
            {
                case "Insert":
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("INSERT INTO ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append(" (");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (ReservedHelper.GridDeleteField.Contains(sys_Schema.FieldName) ||
                                ReservedHelper.GridUpdateField.Contains(sys_Schema.FieldName) ||
                                sys_Schema.IsIdentity || sys_Schema.SqlDbType.ToLower() == "timestamp")
                            {
                                continue;
                            }
                            else
                            {
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,");
                            }
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(") \r\n");
                        stringBuilder.Append("VALUES (");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (sys_Schema.FieldName.Equals("Create_Time"))
                            {
                                stringBuilder.Append("GETDATE()");
                                stringBuilder.Append(" ,");
                            }
                            else if (ReservedHelper.GridDeleteField.Contains(sys_Schema.FieldName) ||
                                ReservedHelper.GridUpdateField.Contains(sys_Schema.FieldName) ||
                                sys_Schema.IsIdentity || sys_Schema.SqlDbType.ToLower() == "timestamp")
                            {
                                continue;
                            }
                            else if (sys_Schema.IsPrimary && sys_Schema.SqlDbType.Equals("uniqueidentifier"))
                            {
                                stringBuilder.Append("ISNULL(@");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,NEWID()),");
                            }
                            else if (sys_Schema.IsPrimary && sys_Schema.SqlDbType.Contains("varchar"))
                            {
                                stringBuilder.Append("ISNULL(@");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,NEWID()) ,");
                            }
                            else if (sys_Schema.SqlDbType.Equals("bit"))
                            {
                                stringBuilder.Append("ISNULL(@");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,0) ,");
                            }
                            else
                            {
                                stringBuilder.Append("@");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,");
                            }
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append(") \r\n");
                        return stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                case "Update":
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("UPDATE A");
                        stringBuilder.Append("\r\nSET ");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (ReservedHelper.GridInsertField.Contains(sys_Schema.FieldName) ||
                                ReservedHelper.GridDeleteField.Contains(sys_Schema.FieldName) ||
                                sys_Schema.IsIdentity || sys_Schema.SqlDbType.ToLower() == "timestamp" ||
                                sys_Schema.IsPrimary.Equals(true))
                            {
                                continue;
                            }
                            else
                            {
                                //修改人修改时间
                                if (sys_Schema.FieldName.Equals("Modify_Time"))
                                {
                                    stringBuilder.Append("A.");
                                    stringBuilder.Append(sys_Schema.FieldName);
                                    stringBuilder.Append(" = GETDATE() ,");
                                    continue;
                                }
                                stringBuilder.Append("A.");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" = @");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,");
                            }
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append("\r\nFROM ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append(" A\r\n");
                        stringBuilder.Append("WHERE 1 = 1");
                        foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => s.IsPrimary.Equals(true)))
                        {
                            stringBuilder.Append("\r\nAND A.");
                            stringBuilder.Append(sys_Schema.FieldName);
                            stringBuilder.Append(" = @");
                            stringBuilder.Append(sys_Schema.FieldName);
                        }
                        return stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                case "Delete":
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("UPDATE A");
                        stringBuilder.Append("\r\nSET ");
                        stringBuilder.Append("A.Delete_Time = GETDATE(),\r\n");
                        stringBuilder.Append("A.Delete_User = @Delete_User,\r\n");
                        stringBuilder.Append("A.IsDelete = 1\r\n");
                        stringBuilder.Append("FROM ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append(" A\r\n");
                        stringBuilder.Append("WHERE 1 = 1");
                        foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => s.IsPrimary.Equals(true)))
                        {
                            stringBuilder.Append("\r\nAND A.");
                            stringBuilder.Append(sys_Schema.FieldName);
                            stringBuilder.Append(" = @");
                            stringBuilder.Append(sys_Schema.FieldName);
                        }
                        stringBuilder.Append("\r\n");
                        stringBuilder.Append("--DELETE ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append("\r\n--WHERE 1 = 1");
                        foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => s.IsPrimary.Equals(true)))
                        {
                            stringBuilder.Append("\r\n--AND ");
                            stringBuilder.Append(sys_Schema.FieldName);
                            stringBuilder.Append(" = @");
                            stringBuilder.Append(sys_Schema.FieldName);
                        }
                        return stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                case "Select":
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("SELECT ");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (sys_Schema.FieldName.Equals("IsEnabled"))
                            {
                                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                                stringBuilder.Append("\r\n--,CONVERT(BIT ,1) IsEditable \r\n,");
                            }
                            stringBuilder.Append("A.");
                            stringBuilder.Append(sys_Schema.FieldName);
                            stringBuilder.Append(" ,");
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append("\r\nFROM ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append(" A \r\nWHERE 1 = 1");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (sys_Schema.SqlDbType.Contains("char"))
                            {
                                stringBuilder.Append("\r\nAND ISNULL(A.");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(",'') LIKE '%'+ ISNULL(@c");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,'') +'%'");
                            }
                            else if (sys_Schema.SqlDbType.Contains("date"))
                            {
                                stringBuilder.Append("\r\nAND DATEDIFF(D,ISNULL(A.");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(",GETDATE()),ISNULL(@c");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(",GETDATE())) = 0");
                            }
                        }
                        stringBuilder.Append("\r\nAND A.IsDelete = 0");
                        return stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                case "SelectPage":
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("DECLARE @Total INT\r\n");
                        stringBuilder.Append("SELECT @Total = COUNT(0) \r\nFROM ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append(" A \r\n");
                        stringBuilder.Append("\r\nSELECT B.* FROM(\r\n\r\n");
                        stringBuilder.Append("SELECT ");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (sys_Schema.FieldName.Equals("IsEnabled"))
                            {
                                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                                stringBuilder.Append("\r\n--,CONVERT(BIT ,1) IsEditable \r\n,");
                            }
                            stringBuilder.Append("A.");
                            stringBuilder.Append(sys_Schema.FieldName);
                            stringBuilder.Append(" ,");
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append("\r\n,");
                        stringBuilder.Append("ROW_NUMBER() OVER (ORDER BY ");
                        stringBuilder.Append("A.Create_Time");
                        stringBuilder.Append(") Record_Id ,");
                        //stringBuilder.Append("@PageIndex PageIndex ,");
                        stringBuilder.Append("(@Total / @PageSize) + 1 PageCount --, @Total Record_Total ");
                        //stringBuilder.Append("@PageSize PageSize");
                        stringBuilder.Append("\r\nFROM ");
                        stringBuilder.Append(TableName);
                        stringBuilder.Append(" A \r\nWHERE 1 = 1");
                        foreach (Sys_Schema sys_Schema in sys_Schemas)
                        {
                            if (sys_Schema.SqlDbType.Contains("char"))
                            {
                                stringBuilder.Append("\r\nAND ISNULL(A.");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(",'') LIKE '%'+ ISNULL(@c");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(" ,'') +'%'");
                            }
                            else if (sys_Schema.SqlDbType.Contains("date"))
                            {
                                stringBuilder.Append("\r\nAND DATEDIFF(D,ISNULL(A.");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(",GETDATE()),ISNULL(@c");
                                stringBuilder.Append(sys_Schema.FieldName);
                                stringBuilder.Append(",GETDATE())) = 0");
                            }
                        }
                        stringBuilder.Append("\r\nAND A.IsDelete = 0");
                        stringBuilder.Append("\r\n\r\n) B\r\n");
                        stringBuilder.Append("WHERE B.Record_Id > (@PageIndex - 1) * @PageSize\r\n");
                        stringBuilder.Append("AND B.Record_Id <= (@PageIndex) * @PageSize");
                        return stringBuilder.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                default:
                    try
                    {
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
            }
        }
        public static string GenerateTable(string tableName, List<Sys_Schema> sys_Schemas)
        {
            try
            {
                string tmpName = "TMP_" + tableName;
                #region  创建临时表
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("BEGIN TRAN CREATE_TABLE\r\n");
                stringBuilder.Append("--创建表 \r\n");
                stringBuilder.Append("CREATE TABLE ");
                stringBuilder.Append(tmpName);
                stringBuilder.Append("(");
                foreach (Sys_Schema sys_Schema in sys_Schemas)
                {
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append(" ");
                    stringBuilder.Append(sys_Schema.SqlDbType);
                    if (sys_Schema.IsIdentity)
                        stringBuilder.Append(" IDENTITY(1,1) ");
                    if (!sys_Schema.IsNullable || sys_Schema.IsPrimary || sys_Schema.IsIdentity)
                        stringBuilder.Append(" NOT ");
                    stringBuilder.Append(" NULL ");
                    stringBuilder.Append(" \r\n,");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append(") ON [PRIMARY] \r\n");
                stringBuilder.Append("COMMIT TRAN CREATE_TABLE\r\n");
                stringBuilder.Append("\r\n\r\n");
                #endregion

                #region  转移数据
                if (sys_Schemas.Where(s => !string.IsNullOrEmpty(s.FieldNameOld)).Count() > 0)
                {
                    stringBuilder.Append("BEGIN TRAN INSERT_INTO\r\n");
                    stringBuilder.Append("--转移数据 \r\n");
                    stringBuilder.Append("IF EXISTS (SELECT 0 FROM ");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append(")\r\n");
                    stringBuilder.Append("BEGIN \r\n");
                    if (sys_Schemas.Where(s => s.IsIdentity.Equals(true)).Count() > 0)
                    {
                        stringBuilder.Append("SET IDENTITY_INSERT ");
                        stringBuilder.Append(tmpName);
                        stringBuilder.Append(" ON\r\n");
                    }
                    stringBuilder.Append("INSERT INTO ");
                    stringBuilder.Append(tmpName);
                    stringBuilder.Append("(");
                    foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => !string.IsNullOrEmpty(s.FieldNameOld) && s.SqlDbType.ToLower() != "timestamp"))
                    {
                        stringBuilder.Append(sys_Schema.FieldName);
                        stringBuilder.Append(" ,");
                    }
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    stringBuilder.Append(")\r\n");
                    stringBuilder.Append("SELECT ");
                    foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => !string.IsNullOrEmpty(s.FieldNameOld) && s.SqlDbType.ToLower() != "timestamp"))
                    {
                        stringBuilder.Append(sys_Schema.FieldNameOld);
                        stringBuilder.Append(" AS ");
                        stringBuilder.Append(sys_Schema.FieldName);
                        stringBuilder.Append(" ,");
                    }
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    stringBuilder.Append("\r\nFROM ");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append(" \r\n");
                    if (sys_Schemas.Where(s => s.IsIdentity.Equals(true)).Count() > 0)
                    {
                        stringBuilder.Append("SET IDENTITY_INSERT ");
                        stringBuilder.Append(tmpName);
                        stringBuilder.Append(" OFF\r\n");
                    }
                    stringBuilder.Append("END \r\n");
                    stringBuilder.Append("COMMIT TRAN INSERT_INTO\r\n");
                    stringBuilder.Append("\r\n\r\n");
                }
                #endregion

                #region 删除旧表 转移触发器
                //为了减少重命名触发器的次数直接将旧表删除，执行触发器创建语句，这样更方便
                stringBuilder.Append("BEGIN TRAN DROP_TABLE\r\n");
                string sql = @"DECLARE CURSOR_NAME CURSOR SCROLL FOR
	SELECT TRIGGERS.NAME   AS [TRIGGER_NAME],
		   TABLES.NAME     AS [TABLE_NAME],
		   TRIGGERS.IS_DISABLED,
		   --CASE
		   --WHEN TRIGGERS.IS_INSTEAD_OF_TRIGGER = 1 THEN 'INSTEAD OF'
		   --WHEN TRIGGERS.IS_INSTEAD_OF_TRIGGER = 0 THEN 'AFTER'
		   --ELSE NULL END AS [IS_INSTEAD_OF_TRIGGER],
		   COMMENTS.TEXT [SQL_TEXT]
	FROM SYS.TRIGGERS TRIGGERS
	INNER JOIN SYS.TABLES TABLES ON TRIGGERS.PARENT_ID = TABLES.OBJECT_ID, SYSCOMMENTS COMMENTS
	WHERE TRIGGERS.TYPE = 'TR'
	AND TRIGGERS.OBJECT_ID = COMMENTS.ID
	AND TABLES.NAME = '{0}'


	OPEN CURSOR_NAME
	DECLARE   @TRIGGER_NAME NVARCHAR(50), @TABLE_NAME NVARCHAR(50) ,@IS_DISABLED BIT,@SQL_TEXT NVARCHAR(MAX)
	FETCH NEXT FROM CURSOR_NAME INTO @TRIGGER_NAME ,@TABLE_NAME ,@IS_DISABLED ,@SQL_TEXT
    DROP TABLE {0}
    EXEC SP_RENAME {1} ,{0}
	WHILE @@FETCH_STATUS=0
	BEGIN		
		EXEC sp_sqlexec @SQL_TEXT
		DECLARE @RSQL NVARCHAR(MAX)
		SET @RSQL = 'ALTER TABLE {0} DISABLE TRIGGER ' + @TRIGGER_NAME
        IF @IS_DISABLED = 1
            EXEC sp_sqlexec @RSQL
     
		FETCH NEXT FROM CURSOR_NAME INTO @TRIGGER_NAME ,@TABLE_NAME ,@IS_DISABLED ,@SQL_TEXT
	END 
	CLOSE CURSOR_NAME
	DEALLOCATE CURSOR_NAME";
                sql = string.Format(sql, tableName, tmpName);
                stringBuilder.Append(sql);
                stringBuilder.Append("\r\n");
                stringBuilder.Append("COMMIT TRAN DROP_TABLE\r\n");
                stringBuilder.Append("\r\n\r\n");
                #endregion

                #region 添加约束
                stringBuilder.Append("BEGIN TRAN ALTER_TABLE\r\n");
                if (sys_Schemas.Where(s => s.IsPrimary.Equals(true)).Count() > 0)
                {
                    stringBuilder.Append("--添加约束 \r\n");
                    stringBuilder.Append("ALTER TABLE ");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append(" ADD CONSTRAINT PK_");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append(" PRIMARY KEY(");
                    foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => s.IsPrimary.Equals(true)))
                    {
                        stringBuilder.Append(sys_Schema.FieldName);
                        stringBuilder.Append(" ,");
                    }
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    stringBuilder.Append(" )\r\n");
                }
                foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => s.IsUnique.Equals(true) && s.IsPrimary.Equals(false)))
                {
                    stringBuilder.Append("ALTER TABLE ");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append(" ADD CONSTRAINT UNIQUE_");
                    stringBuilder.Append(sys_Schema.TableName);
                    stringBuilder.Append("_");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append(" UNIQUE(");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append(")\r\n");
                }
                foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => s.IsIndex.Equals(true) && s.IsPrimary.Equals(false) && s.IsUnique.Equals(false)))
                {
                    stringBuilder.Append("CREATE INDEX ");
                    stringBuilder.Append("INDEX_");
                    stringBuilder.Append(sys_Schema.TableName);
                    stringBuilder.Append("_");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append(" ON ");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append("(");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append(")\r\n");
                }
                foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => !string.IsNullOrEmpty(s.DefaultValue)))
                {
                    //ALTER TABLE tablename ADD CONSTRAINT constratintname DEFAULT '默认值' FOR 字段名;
                    stringBuilder.Append("ALTER TABLE ");
                    stringBuilder.Append(sys_Schema.TableName);
                    stringBuilder.Append(" ADD CONSTRAINT DEFAULT_");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append(" DEFAULT '");
                    stringBuilder.Append(sys_Schema.DefaultValue);
                    stringBuilder.Append("' FOR ");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append("\r\n");
                }
                #endregion

                #region 添加备注
                foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => !string.IsNullOrEmpty(s.Description)))
                {
                    stringBuilder.Append("exec sp_addextendedproperty N'MS_Description', N'");
                    stringBuilder.Append(sys_Schema.Description);
                    stringBuilder.Append("', N'user', N'dbo', N'table', N'");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append("', N'column', N'");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append("'");
                    stringBuilder.Append("\r\n");
                }
                foreach (Sys_Schema sys_Schema in sys_Schemas.Where(s => !string.IsNullOrEmpty(s.Detail)))
                {
                    stringBuilder.Append("exec sp_addextendedproperty N'EX_Description', N'");
                    stringBuilder.Append(sys_Schema.Detail);
                    stringBuilder.Append("', N'user', N'dbo', N'table', N'");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append("', N'column', N'");
                    stringBuilder.Append(sys_Schema.FieldName);
                    stringBuilder.Append("'");
                    stringBuilder.Append("\r\n");
                }
                stringBuilder.Append("COMMIT TRAN ALTER_TABLE\r\n");
                #endregion
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}