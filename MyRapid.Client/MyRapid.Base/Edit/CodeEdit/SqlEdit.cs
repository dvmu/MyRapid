/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using System.Text.RegularExpressions;
using MyRapid.Code;
namespace MyRapid.Base
{
    [Docking(DockingBehavior.Ask)]
    public partial class SqlEdit : UserControl, INotifyPropertyChanged
    {

        public bool HasFont(string fontName = "Code Font")
        {
            Font font;
            try
            {
                font = new Font(fontName, 10);
                if (font.Name != fontName)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #region 基本配置
        public SqlEdit()
        {
            InitializeComponent();
            //InitFindBox();
            InitDrop();
            codeEdit.WrapMode = WrapMode.Whitespace;
            codeEdit.BorderStyle = BorderStyle.None;
            codeEdit.IndentationGuides = IndentView.LookBoth;
            //scintilla1.Lexer = ScintillaNET.Lexer.Sql;
            codeEdit.StyleResetDefault();

            if (HasFont())
                codeEdit.Styles[Style.Default].Font = "Code Font";
            else
                codeEdit.Styles[Style.Default].Font = "Consolas";

            codeEdit.Styles[Style.Default].Size = 10;
            codeEdit.StyleClearAll();
            //Default
            codeEdit.Styles[ScintillaNET.Style.MSSql.Default].ForeColor = Color.Black;

            //备注
            codeEdit.Styles[ScintillaNET.Style.MSSql.Comment].ForeColor = Color.Green;
            //codeEdit.Styles[ScintillaNET.Style.MSSql.Comment].Font = "微软雅黑";
            //备注
            codeEdit.Styles[ScintillaNET.Style.MSSql.LineComment].ForeColor = Color.Green;
            //codeEdit.Styles[ScintillaNET.Style.MSSql.LineComment].Font = "微软雅黑";
            //Number
            codeEdit.Styles[ScintillaNET.Style.MSSql.Number].ForeColor = Color.Black;
            //String
            codeEdit.Styles[ScintillaNET.Style.MSSql.String].ForeColor = Color.Red;
            //Identifier
            codeEdit.Styles[ScintillaNET.Style.MSSql.Identifier].ForeColor = Color.Teal;
            //Variable
            codeEdit.Styles[ScintillaNET.Style.MSSql.Variable].ForeColor = Color.Maroon;
            //ColumnName
            codeEdit.Styles[ScintillaNET.Style.MSSql.ColumnName].ForeColor = Color.Green;
            //ColumnName2 [col]
            codeEdit.Styles[ScintillaNET.Style.MSSql.ColumnName2].ForeColor = Color.Teal;
            //下面的可以自定义keywords
            //Statement
            codeEdit.Styles[ScintillaNET.Style.MSSql.Statement].ForeColor = Color.Blue;
            codeEdit.Styles[ScintillaNET.Style.MSSql.Statement].Case = StyleCase.Upper;
            //DataType
            codeEdit.Styles[ScintillaNET.Style.MSSql.DataType].ForeColor = Color.Blue;
            codeEdit.Styles[ScintillaNET.Style.MSSql.DataType].Case = StyleCase.Upper;
            //Systable
            codeEdit.Styles[ScintillaNET.Style.MSSql.Systable].ForeColor = Color.Green;
            codeEdit.Styles[ScintillaNET.Style.MSSql.Systable].Case = StyleCase.Upper;
            //GlobalVariable @@开头 keywords不需要@@
            codeEdit.Styles[ScintillaNET.Style.MSSql.GlobalVariable].ForeColor = Color.OrangeRed;
            codeEdit.Styles[ScintillaNET.Style.MSSql.GlobalVariable].Case = StyleCase.Upper;
            //Function
            codeEdit.Styles[ScintillaNET.Style.MSSql.Function].ForeColor = Color.Gray;
            codeEdit.Styles[ScintillaNET.Style.MSSql.Function].Case = StyleCase.Upper;
            //Procedure
            codeEdit.Styles[ScintillaNET.Style.MSSql.Procedure].ForeColor = Color.Gray;
            codeEdit.Styles[ScintillaNET.Style.MSSql.Procedure].Case = StyleCase.Upper;
            //Operator
            codeEdit.Styles[ScintillaNET.Style.MSSql.Operator].ForeColor = Color.Gray;
            codeEdit.Styles[ScintillaNET.Style.MSSql.Operator].Case = StyleCase.Upper;
            codeEdit.Lexer = Lexer.MSSql;
            string globalVariable = @"connections cpu_busy cursor_rows datefirst dbts error fetch_status identity idle io_busy langid language lock_timeout max_connections max_precision nestlevel options packet_errors procid remserver rowcount servername servicename spid textsize trancount version";
            string sysTable = @"sys.extended_properties syscolumns syscomments sysdepends sysfilegroups sysfiles sysfiles1 sysforeignkeys sysfulltextcatalogs sysfulltextnotify sysindexes sysindexkeys sysmembers sysobjects syspermissions sysprotects sysreferences systypes sysusers";
            string dataType = @"bigint binary bit char date datetime datetime2 datetimeoffset decimal float hierarchyid image int money nchar ntext numeric nvarchar real smalldatetime smallint smallmoney sql_variant table text time timestamp tinyint uniqueidentifier varbinary varchar xml";
            string function = @"abs acos app_name ascii asin assemblyproperty asymkey_id asymkeyproperty atan atn2 avg case cast ceiling cert_id certproperty charindex checksum_agg coalesce col_length col_name collationproperty columnproperty columns_updated containstable convert cos cot count count_big crypt_gen_random current_timestamp current_user cursor_status database_principal_id databaseproperty databasepropertyex datalength dateadd datediff datename datepart day db_id db_name decryptbyasymkey decryptbycert decryptbykey decryptbykeyautoasymkey decryptbykeyautocert decryptbypassphrase degrees dense_rank difference encryptbyasymkey encryptbycert encryptbykey encryptbypassphrase error_line error_message error_number error_procedure error_severity error_state eventdata exp file_id file_idex file_name filegroup_id filegroup_name filegroupproperty fileproperty floor fn_helpcollations fn_listextendedproperty fn_servershareddrives fn_virtualfilestats formatmessage freetexttable fulltextcatalogproperty fulltextserviceproperty getansinull getdate getutcdate grouping has_perms_by_name host_id host_name ident_current ident_incr ident_seed index_col indexkey_property indexproperty is_member is_objectsigned is_srvrolemember isdate isnull isnumeric key_id key_name key_string len log log10 lower ltrim max min month newid ntile nullif object_definition object_id object_name object_schema_name objectproperty objectpropertyex opendatasource openquery openrowset openxml original_login parsename patindex permissions pi power publishingservername pwdcompare pwdencrypt quotename radians rand rank replicate reverse round row_number rowcount_big rtrim schema_id schema_name scope_identity serverproperty session_user sessionproperty setuser sign signbyasymkey signbycert sin soundex space sql_variant_property sqrt square stats_date stdev stdevp str stuff substring sum suser_id suser_name suser_sid suser_sname switchoffset symkeyproperty sysdatetime sysdatetimeoffset system_user sysutcdatetime tan tertiary_weights textptr todatetimeoffset trigger_nestlevel type_id type_name typeproperty unicode upper user_id user_name var varp verifysignedbyasymkey verifysignedbycert xact_state year";
            string ddl = @"aggregate alter application assembly asymmetric audit authorization binding broker bulk catalog certificate collection contract create credential cryptographic database declare default delete disable drop enable encryption endpoint event exec execute from fulltext function governor group in index insert into key login master merge message notification option output partition pool priority procedure provider queue remote replace resource role route rule schema scheme select server service session set signature spatial specification statistics stoplist symmetric synonym top trigger truncate type update user view where with workload";
            string oper = @"add all and any as asc backup begin between break browse by cascade check checkpoint close clustered collate column commit compute constraint contains continue cross current current_date current_time cursor dbcc deallocate deny desc disk distinct distributed double dump else end errlvl escape except exists exit external fetch file fillfactor for foreign freetext full goto grant having holdlock identity_insert identitycol if inner intersect is join kill left like lineno load national nocheck nonclustered not null of off offsets on open or order outer over percent pivot plan precision primary print proc public raiserror read readtext reconfigure references replication restore restrict return revert revoke right rollback rowstringcol save securityaudit shutdown some tablesample then to tran transaction tsequal union unique unpivot updatetext use values varying waitfor when while writetext";
            string prc = @"sp_activedirectory_obj sp_activedirectory_scp sp_add_agent_parameter sp_add_agent_profile sp_add_alert sp_add_category sp_add_job sp_add_jobschedule sp_add_jobserver sp_add_jobstep sp_add_log_shipping_alert_job sp_add_log_shipping_primary_database sp_add_log_shipping_primary_secondary sp_add_log_shipping_secondary_database sp_add_log_shipping_secondary_primary sp_add_maintenance_plan sp_add_maintenance_plan_db sp_add_maintenance_plan_job sp_add_notification sp_add_operator sp_add_proxy sp_add_schedule sp_add_targetservergroup sp_add_targetsvrgrp_member sp_addapprole sp_addarticle sp_adddistpublisher sp_adddistributiondb sp_adddistributor sp_adddynamicsnapshot_job sp_addextendedproc sp_addextendedproperty sp_addlinkedserver sp_addlinkedsrvlogin sp_addlogin sp_addlogreader_agent sp_addmergealternatepublisher sp_addmergearticle sp_addmergefilter sp_addmergepartition sp_addmergepublication sp_addmergepullsubscription sp_addmergepullsubscription_agent sp_addmergepushsubscription_agent sp_addmergesubscription sp_addmessage sp_addpublication sp_addpublication_snapshot sp_addpullsubscription sp_addpullsubscription_agent sp_addpushsubscription_agent sp_addqreader_agent sp_addremotelogin sp_addrole sp_addrolemember sp_addscriptexec sp_addserver sp_addsrvrolemember sp_addsubscriber sp_addsubscriber_schedule sp_addsubscription sp_addsynctriggers sp_addtabletocontents sp_addtype sp_addumpdevice sp_adduser sp_adjustpublisheridentityrange sp_altermessage sp_apply_job_to_targets sp_approlepassword sp_article_validation sp_articlecolumn sp_articlefilter sp_articleview sp_attach_db sp_attach_schedule sp_attach_single_file_db sp_attachsubscription sp_autostats sp_batch_params sp_bindefault sp_bindrule sp_bindsession sp_browsemergesnapshotfolder sp_browsereplcmds sp_browsesnapshotfolder sp_can_tlog_be_applied sp_catalogs sp_cdc_add_job sp_cdc_change_job sp_cdc_cleanup_change_table sp_cdc_disable_db sp_cdc_disable_table sp_cdc_drop_job sp_cdc_enable_db sp_cdc_enable_table sp_cdc_generate_wrapper_function sp_cdc_get_captured_columns sp_cdc_get_ddl_history sp_cdc_scan sp_cdc_start_job sp_cdc_stop_job sp_certify_removable sp_change_agent_parameter sp_change_agent_profile sp_change_log_shipping_primary_database sp_change_log_shipping_secondary_database sp_change_log_shipping_secondary_primary sp_change_subscription_properties sp_change_users_login sp_changearticle sp_changearticlecolumndatatype sp_changedbowner sp_changedistpublisher sp_changedistributiondb sp_changedistributor_password sp_changedistributor_property sp_changedynamicsnapshot_job sp_changelogreader_agent sp_changemergearticle sp_changemergefilter sp_changemergepublication sp_changemergepullsubscription sp_changemergesubscription sp_changeobjectowner sp_changepublication sp_changepublication_snapshot sp_changeqreader_agent sp_changereplicationserverpasswords sp_changesubscriber sp_changesubscriber_schedule sp_changesubscription sp_changesubscriptiondtsinfo sp_changesubstatus sp_check_dynamic_filters sp_check_for_sync_trigger sp_check_join_filter sp_check_subset_filter sp_cleanup_log_shipping_history sp_column_privileges sp_column_privileges_ex sp_columns sp_columns_ex sp_configure sp_configure_peerconflictdetection sp_control_dbmasterkey_password sp_control_plan_guide sp_copymergesnapshot sp_copysnapshot sp_copysubscription sp_create_plan_guide sp_create_plan_guide_from_handle sp_create_removable sp_createstats sp_cursor_list sp_cycle_agent_errorlog sp_cycle_errorlog sp_databases sp_datatype_info sp_db_vardecimal_storage_format sp_dbcmptlevel sp_dbfixedrolepermission sp_dbmmonitoraddmonitoring sp_dbmmonitorchangealert sp_dbmmonitorchangemonitoring sp_dbmmonitordropalert sp_dbmmonitordropmonitoring sp_dbmmonitorhelpalert sp_dbmmonitorhelpmonitoring sp_dbmmonitorresults sp_dbmmonitorupdate sp_dboption sp_dbremove sp_defaultdb sp_defaultlanguage sp_delete_alert sp_delete_backuphistory sp_delete_category sp_delete_database_backuphistory sp_delete_job sp_delete_jobschedule sp_delete_jobserver sp_delete_jobstep sp_delete_jobsteplog sp_delete_log_shipping_alert_job sp_delete_log_shipping_primary_database sp_delete_log_shipping_primary_secondary sp_delete_log_shipping_secondary_database sp_delete_log_shipping_secondary_primary sp_delete_maintenance_plan sp_delete_maintenance_plan_db sp_delete_maintenance_plan_job sp_delete_notification sp_delete_operator sp_delete_proxy sp_delete_schedule sp_delete_targetserver sp_delete_targetservergroup sp_delete_targetsvrgrp_member sp_deletemergeconflictrow sp_deletepeerrequesthistory sp_deletetracertokenhistory sp_denylogin sp_depends sp_describe_cursor sp_describe_cursor_columns sp_describe_cursor_tables sp_detach_db sp_detach_schedule sp_drop_agent_parameter sp_drop_agent_profile sp_dropalias sp_dropanonymousagent sp_dropapprole sp_droparticle sp_dropdevice sp_dropdistpublisher sp_dropdistributiondb sp_dropdistributor sp_dropdynamicsnapshot_job sp_dropextendedproc sp_dropextendedproperty sp_droplinkedsrvlogin sp_droplogin sp_dropmergealternatepublisher sp_dropmergearticle sp_dropmergefilter sp_dropmergepartition sp_dropmergepublication sp_dropmergepullsubscription sp_dropmergesubscription sp_dropmessage sp_droppublication sp_droppullsubscription sp_dropremotelogin sp_droprole sp_droprolemember sp_dropserver sp_dropsrvrolemember sp_dropsubscriber sp_dropsubscription sp_droptype sp_dropuser sp_dsninfo sp_enum_login_for_proxy sp_enum_proxy_for_subsystem sp_enum_sqlagent_subsystems sp_enumcustomresolvers sp_enumdsn sp_enumeratependingschemachanges sp_estimate_data_compression_savings sp_estimated_rowsize_reduction_for_vardecimal sp_executesql sp_expired_subscription_cleanup sp_fkeys sp_foreignkeys sp_fulltext_catalog sp_fulltext_column sp_fulltext_keymappings sp_fulltext_load_thesaurus_file sp_fulltext_pendingchanges sp_fulltext_resetfdhostaccount sp_fulltext_service sp_fulltext_table sp_generatefilters sp_get_distributor sp_get_query_template sp_getagentparameterlist sp_getapplock sp_getbindtoken sp_getdefaultdatatypemapping sp_getmergedeletetype sp_getqueuedrows sp_getsubscriptiondtspackagename sp_gettopologyinfo sp_grant_login_to_proxy sp_grant_proxy_to_subsystem sp_grant_publication_access sp_grantdbaccess sp_grantlogin sp_help sp_help_agent_default sp_help_agent_parameter sp_help_agent_profile sp_help_alert sp_help_category sp_help_downloadlist sp_help_fulltext_catalog_components sp_help_fulltext_catalogs sp_help_fulltext_catalogs_cursor sp_help_fulltext_columns sp_help_fulltext_columns_cursor sp_help_fulltext_system_components sp_help_fulltext_tables sp_help_fulltext_tables_cursor sp_help_job sp_help_jobactivity sp_help_jobcount sp_help_jobhistory sp_help_jobs_in_schedule sp_help_jobschedule sp_help_jobserver sp_help_jobstep sp_help_jobsteplog sp_help_log_shipping_alert_job sp_help_log_shipping_monitor sp_help_log_shipping_monitor_primary sp_help_log_shipping_monitor_secondary sp_help_log_shipping_primary_database sp_help_log_shipping_primary_secondary sp_help_log_shipping_secondary_database sp_help_log_shipping_secondary_primary sp_help_maintenance_plan sp_help_notification sp_help_operator sp_help_peerconflictdetection sp_help_proxy sp_help_publication_access sp_help_schedule sp_help_targetserver sp_help_targetservergroup sp_helparticle sp_helparticlecolumns sp_helparticledts sp_helpconstraint sp_helpdatatypemap sp_helpdb sp_helpdbfixedrole sp_helpdevice sp_helpdistpublisher sp_helpdistributiondb sp_helpdistributor sp_helpdistributor_properties sp_helpdynamicsnapshot_job sp_helpextendedproc sp_helpfile sp_helpfilegroup sp_helpindex sp_helplanguage sp_helplinkedsrvlogin sp_helplogins sp_helplogreader_agent sp_helpmergealternatepublisher sp_helpmergearticle sp_helpmergearticlecolumn sp_helpmergearticleconflicts sp_helpmergeconflictrows sp_helpmergedeleteconflictrows sp_helpmergefilter sp_helpmergepartition sp_helpmergepublication sp_helpmergepullsubscription sp_helpmergesubscription sp_helpntgroup sp_helppeerrequests sp_helppeerresponses sp_helppublication sp_helppublication_snapshot sp_helppullsubscription sp_helpqreader_agent sp_helpremotelogin sp_helpreplfailovermode sp_helpreplicationdboption sp_helpreplicationoption sp_helprole sp_helprolemember sp_helprotect sp_helpserver sp_helpsort sp_helpsrvrole sp_helpsrvrolemember sp_helpstats sp_helpsubscriberinfo sp_helpsubscription sp_helpsubscription_properties sp_helpsubscriptionerrors sp_helptext sp_helptracertokenhistory sp_helptracertokens sp_helptrigger sp_helpuser sp_helpxactsetjob sp_indexes sp_indexoption sp_invalidate_textptr sp_ivindexhasnullcols sp_link_publication sp_linkedservers sp_lock sp_lookupcustomresolver sp_manage_jobs_by_login sp_markpendingschemachange sp_marksubscriptionvalidation sp_mergearticlecolumn sp_mergedummyupdate sp_monitor sp_mschange_distribution_agent_properties sp_mschange_logreader_agent_properties sp_mschange_merge_agent_properties sp_mschange_snapshot_agent_properties sp_mshasdbaccess sp_msx_defect sp_msx_enlist sp_msx_get_account sp_msx_set_account sp_notify_operator sp_oacreate sp_oadestroy sp_oageterrorinfo sp_oagetproperty sp_oamethod sp_oasetproperty sp_oastop sp_password sp_pkeys sp_post_msx_operation sp_posttracertoken sp_primarykeys sp_publication_validation sp_publisherproperty sp_purge_jobhistory sp_recompile sp_refresh_log_shipping_monitor sp_refreshsqlmodule sp_refreshsubscriptions sp_refreshview sp_register_custom_scripting sp_registercustomresolver sp_reinitmergepullsubscription sp_reinitmergesubscription sp_reinitpullsubscription sp_reinitsubscription sp_releaseapplock sp_remoteoption sp_remove_job_from_targets sp_removedbreplication sp_removedistpublisherdbreplication sp_rename sp_renamedb sp_repladdcolumn sp_replcmds sp_replcounters sp_repldone sp_repldropcolumn sp_replflush sp_replication_agent_checkup sp_replicationdboption sp_replmonitorchangepublicationthreshold sp_replmonitorhelpmergesession sp_replmonitorhelpmergesessiondetail sp_replmonitorhelppublication sp_replmonitorhelppublicationthresholds sp_replmonitorhelppublisher sp_replmonitorhelpsubscription sp_replmonitorsubscriptionpendingcmds sp_replqueuemonitor sp_replrestart sp_replsetoriginator sp_replshowcmds sp_repltrans sp_requestpeerresponse sp_requestpeertopologyinfo sp_resetsnapshotdeliveryprogress sp_resetstatus sp_restoredbreplication sp_restoremergeidentityrange sp_resync_targetserver sp_resyncmergesubscription sp_revoke_login_from_proxy sp_revoke_proxy_from_subsystem sp_revoke_publication_access sp_revokedbaccess sp_revokelogin sp_schemafilter sp_script_synctran_commands sp_scriptdynamicupdproc sp_scriptpublicationcustomprocs sp_scriptsubconflicttable sp_send_dbmail sp_server_info sp_serveroption sp_setapprole sp_setdefaultdatatypemapping sp_setnetname sp_setreplfailovermode sp_setsubscriptionxactseqno sp_settriggerorder sp_showpendingchanges sp_showrowreplicainfo sp_spaceused sp_sproc_columns sp_srvrolepermission sp_start_job sp_startpublication_snapshot sp_statistics sp_stop_job sp_stored_procedures sp_subscription_cleanup sp_syscollector_create_collection_item sp_syscollector_create_collection_set sp_syscollector_create_collector_type sp_syscollector_delete_collection_item sp_syscollector_delete_collection_set sp_syscollector_delete_collector_type sp_syscollector_delete_execution_log_tree sp_syscollector_disable_collector sp_syscollector_enable_collector sp_syscollector_run_collection_set sp_syscollector_set_cache_directory sp_syscollector_set_cache_window sp_syscollector_set_warehouse_database_name sp_syscollector_set_warehouse_instance_name sp_syscollector_start_collection_set sp_syscollector_stop_collection_set sp_syscollector_update_collection_item sp_syscollector_update_collection_set sp_syscollector_update_collector_type sp_syscollector_upload_collection_set sp_table_privileges sp_table_privileges_ex sp_table_validation sp_tableoption sp_tables sp_tables_ex sp_testlinkedserver sp_trace_create sp_trace_generateevent sp_trace_setevent sp_trace_setfilter sp_trace_setstatus sp_unbindefault sp_unbindrule sp_unregister_custom_scripting sp_unregistercustomresolver sp_unsetapprole sp_update_agent_profile sp_update_alert sp_update_category sp_update_job sp_update_jobschedule sp_update_jobstep sp_update_notification sp_update_operator sp_update_proxy sp_update_schedule sp_update_targetservergroup sp_updateextendedproperty sp_updatestats sp_upgrade_log_shipping sp_validatelogins sp_validatemergepublication sp_validatemergesubscription sp_validname sp_vupgrade_mergeobjects sp_vupgrade_replication sp_who sp_xml_preparedocument sp_xml_removedocument sp_xp_cmdshell_proxy_account sys.sp_cdc_help_change_data_capture sys.sp_cdc_help_jobs xp_cmdshell xp_deletemail xp_enumgroups xp_fixeddrives xp_grantlogin xp_logevent xp_loginconfig xp_logininfo xp_msver xp_readmail xp_revokelogin xp_sendmail xp_sprintf xp_sqlmaint xp_sscanf xp_startmail xp_stopmail";

            codeEdit.SetKeywords(0, ddl);
            codeEdit.SetKeywords(1, dataType);
            codeEdit.SetKeywords(2, sysTable);
            codeEdit.SetKeywords(3, globalVariable);
            codeEdit.SetKeywords(4, function);
            codeEdit.SetKeywords(5, prc);
            codeEdit.SetKeywords(6, oper);

            //codeEdit.ClearAllCmdKeys();
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.S);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.F);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.R);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.H);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.L);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.U);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.G);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.B);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.E);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.K);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.N);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.O);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.P);
            codeEdit.ClearCmdKey(Keys.Shift | Keys.Control | Keys.W);
            codeEdit.ClearCmdKey(Keys.Control | Keys.F);
            codeEdit.ClearCmdKey(Keys.Control | Keys.Q);
            codeEdit.ClearCmdKey(Keys.Control | Keys.S);
            codeEdit.ClearCmdKey(Keys.Control | Keys.R);
            codeEdit.ClearCmdKey(Keys.Control | Keys.H);
            codeEdit.ClearCmdKey(Keys.Control | Keys.L);
            codeEdit.ClearCmdKey(Keys.Control | Keys.U);
            codeEdit.ClearCmdKey(Keys.Control | Keys.G);
            codeEdit.ClearCmdKey(Keys.Control | Keys.B);
            codeEdit.ClearCmdKey(Keys.Control | Keys.E);
            codeEdit.ClearCmdKey(Keys.Control | Keys.K);
            codeEdit.ClearCmdKey(Keys.Control | Keys.N);
            codeEdit.ClearCmdKey(Keys.Control | Keys.O);
            codeEdit.ClearCmdKey(Keys.Control | Keys.P);
            codeEdit.ClearCmdKey(Keys.Control | Keys.W);
            InitNumberMargin();
            //InitCodeFolding();
            //codeEdit.con
            codeEdit.TextChanged += InitTextChanaged;
            this.TextChanged += InitTextChanaged;
            /***********************自动完成*********************/
            codeEdit.AutoCIgnoreCase = true;
            string ac = Combine(globalVariable, sysTable, dataType, function, ddl, oper, prc);
            codeEdit.UpdateUI += delegate (object sender, UpdateUIEventArgs e)
            {
                if (UpdateChange.Content == e.Change)
                {
                    if (codeEdit.CurrentPosition == 0) return;
                    int len = codeEdit.GetWordFromPosition(codeEdit.CurrentPosition).Length;
                    if (len == 0) return;
                    codeEdit.AutoCShow(len, ac);
                }
            };
            /***********************自动完成*********************/
        }

        private string Combine(params string[] str)
        {
            List<string> strList = new List<string>();
            foreach (var item in str)
            {
                List<string> strItem = item.Split(' ').ToList<string>().Distinct().ToList();
                strList.AddRange(strItem);
            }
            strList.Add(" ");
            StringBuilder sb = new StringBuilder();
            foreach (string item in strList.OrderBy(s => s).Distinct().ToList())
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    sb.Append(item.Trim());
                    sb.Append(" ");
                }
            }
            return sb.ToString().ToUpper(); ;
        }

        private void InitDrop()
        {
            codeEdit.AllowDrop = true;
            codeEdit.DragEnter += delegate (object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            codeEdit.DragOver += delegate (object sender, DragEventArgs e)
            {
                Point p = codeEdit.PointToClient(new Point(e.X, e.Y));
                int pos = codeEdit.CharPositionFromPoint(p.X, p.Y);
            };
            codeEdit.DragDrop += delegate (object sender, DragEventArgs e)
            {
                // get file drop
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    //先做验证如果拖拽到选中的位置不作任何操作
                    Point p = codeEdit.PointToClient(new Point(e.X, e.Y));
                    int pos = codeEdit.CharPositionFromPoint(p.X, p.Y);
                    if (pos >= codeEdit.SelectionStart && pos <= codeEdit.SelectionEnd)
                        return;
                    string a = (string)e.Data.GetData(DataFormats.Text);
                    int s1 = codeEdit.SelectionStart;
                    int s2 = codeEdit.SelectionEnd;
                    //拖放到前面和拖放到后面的操作不同
                    if (pos > codeEdit.SelectionStart)
                    {
                        codeEdit.InsertText(pos, a);
                        codeEdit.DeleteRange(s1, s2 - s1);
                        codeEdit.CurrentPosition = pos - (s2 - s1);
                        codeEdit.SelectionEnd = pos - (s2 - s1);
                        codeEdit.SelectionStart = pos - (s2 - s1);
                    }
                    else
                    {
                        codeEdit.DeleteRange(s1, s2 - s1);
                        codeEdit.InsertText(pos, a);
                        codeEdit.CurrentPosition = pos;
                        codeEdit.SelectionEnd = pos;
                        codeEdit.SelectionStart = pos;
                    }
                }
            };
        }

        private void InitNumberMargin()
        {
            var nums = codeEdit.Margins[0];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = false;
            nums.Mask = 0;
            //codeEdit.MarginClick += TextArea_MarginClick;
        }

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == 2)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << 2);
                var line = codeEdit.Lines[codeEdit.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(2);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(2);
                }
            }
        }

        private void InitCodeFolding()
        {
            //codeEdit.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            //codeEdit.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));
            // Enable code folding
            codeEdit.SetProperty("fold", "1");
            codeEdit.SetProperty("fold.compact", "1");
            // Configure a margin to display folding symbols
            codeEdit.Margins[2].Type = MarginType.Symbol;
            codeEdit.Margins[2].Mask = Marker.MaskFolders;
            codeEdit.Margins[2].Sensitive = true;
            codeEdit.Margins[2].Width = 20;
            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                codeEdit.Markers[i].SetForeColor(Color.Black); // styles for [+] and [-]
                codeEdit.Markers[i].SetBackColor(Color.White); // styles for [+] and [-]
            }
            // Configure folding markers with respective symbols
            codeEdit.Markers[Marker.Folder].Symbol = MarkerSymbol.CirclePlus;// MarkerSymbol.BoxPlus;
            codeEdit.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.CircleMinus;// MarkerSymbol.BoxMinus;
            codeEdit.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.CirclePlusConnected;// MarkerSymbol.BoxPlusConnected;
            codeEdit.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            codeEdit.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.CircleMinusConnected;// MarkerSymbol.BoxMinusConnected;
            codeEdit.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            codeEdit.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            // Enable automatic folding
            codeEdit.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }
        #endregion
        #region 按钮事件       
        private void toolUndo_Click(object sender, EventArgs e)
        {
            codeEdit.Undo();
        }

        private void toolRedo_Click(object sender, EventArgs e)
        {
            codeEdit.Redo();
        }

        private void toolCut_Click(object sender, EventArgs e)
        {
            codeEdit.Cut();
        }

        private void toolCopy_Click(object sender, EventArgs e)
        {
            codeEdit.Copy();
        }

        private void tolPaste_Click(object sender, EventArgs e)
        {
            codeEdit.Paste();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            CmdAdd();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            CmdRemove();
        }

        private void CmdAdd()
        {
            List<int> addPos = new List<int>();
            foreach (Line item in codeEdit.Lines)
            {
                //codeEdit.NativeInterface.SetCodePage((int)ScintillaNET.Constants.SC_CP_UTF8);
                if (item.EndPosition <= codeEdit.SelectionEnd && item.EndPosition > codeEdit.SelectionStart)
                {
                    addPos.Add(item.Position);
                    //scintilla1.InsertText(item.Position, "--");
                }
                if (item.EndPosition > codeEdit.SelectionEnd && item.Position <= codeEdit.SelectionEnd)
                {
                    addPos.Add(item.Position);
                    //scintilla1.InsertText(item.Position, "--");
                }
            }
            foreach (var item in addPos.OrderByDescending(p => p))
            {
                codeEdit.InsertText(item, "--");
            }
        }

        private void CmdRemove()
        {
            List<int> addPos = new List<int>();
            foreach (Line item in codeEdit.Lines)
            {
                if (item.EndPosition <= codeEdit.SelectionEnd && item.EndPosition > codeEdit.SelectionStart)
                {
                    if (item.Text.StartsWith("--"))
                        addPos.Add(item.Position);
                    //scintilla1.InsertText(item.Position, "--");
                }
                if (item.EndPosition > codeEdit.SelectionEnd && item.Position <= codeEdit.SelectionEnd)
                {
                    if (item.Text.StartsWith("--"))
                        addPos.Add(item.Position);
                    //scintilla1.InsertText(item.Position, "--");
                }
            }
            foreach (var item in addPos.OrderByDescending(p => p))
            {
                codeEdit.DeleteRange(item, 2);
            }
        }

        #endregion
        #region 扩展属性
        public override string Text
        {
            get
            {
                return codeEdit.Text;
            }
            set
            {
                codeEdit.Text = value;
                OnPropertyChanged("Text");
            }
        }

        public string Script
        {
            get
            {
                return codeEdit.Text;
            }
            set
            {

                codeEdit.Text = value;
                OnPropertyChanged("Script");
                codeEdit.EmptyUndoBuffer();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void InitTextChanaged(object sender, EventArgs e)
        {
            OnPropertyChanged("Text");
            OnPropertyChanged("Script");
        }

        public void Insert(int pos, string str)
        {
            codeEdit.InsertText(pos, str);
        }

        public void Insert(string str)
        {
            codeEdit.InsertText(codeEdit.SelectionStart, str);
        }
        #endregion
        #region Find&Relpace
        private void fClose_MouseDown(object sender, MouseEventArgs e)
        {
            FindBox.Hide();
        }

        private void BoxShow()
        {
            if (string.IsNullOrEmpty(ftxtSearch.Text))
            {
                ftxtSearch.Text = codeEdit.SelectedText;
            }
            FindBox.Top = 25;
            FindBox.Left = this.Width - FindBox.Width;
            FindBox.Show();
        }

        private void BoxFind()
        {
            ftxtReplace.Hide();
            fReplace.Hide();
            fReplaceAll.Hide();
            FindBox.Height = 42;
        }

        private void BoxRelpace()
        {
            ftxtReplace.Show();
            fReplace.Show();
            fReplaceAll.Show();
            FindBox.Height = 72;
        }

        private void toolFind_Click(object sender, EventArgs e)
        {
            CmdFind();
        }

        private void toolReplace_Click(object sender, EventArgs e)
        {
            CmdReplace();
        }

        private void CmdFind()
        {
            BoxFind();
            BoxShow();
        }

        private void CmdReplace()
        {
            BoxRelpace();
            BoxShow();
        }

        private void fSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ftxtSearch.Text))
                return;
            Find(true, false);
        }
        int LastSearchIndex;
        string LastSearch;
        public void Find(bool next, bool incremental)
        {
            bool first = LastSearch != ftxtSearch.Text;
            LastSearch = ftxtSearch.Text;
            if (LastSearch.Length > 0)
            {
                if (next)
                {
                    // SEARCH FOR THE NEXT OCCURANCE
                    // Search the document at the last search index
                    codeEdit.TargetStart = LastSearchIndex - 1;
                    codeEdit.TargetEnd = LastSearchIndex + (LastSearch.Length + 1);
                    codeEdit.SearchFlags = SearchFlags.None;
                    // Search, and if not found..
                    if (!incremental || codeEdit.SearchInTarget(LastSearch) == -1)
                    {
                        // Search the document from the caret onwards
                        codeEdit.TargetStart = codeEdit.CurrentPosition;
                        codeEdit.TargetEnd = codeEdit.TextLength;
                        codeEdit.SearchFlags = SearchFlags.None;
                        // Search, and if not found..
                        if (codeEdit.SearchInTarget(LastSearch) == -1)
                        {
                            // Search again from top
                            codeEdit.TargetStart = 0;
                            codeEdit.TargetEnd = codeEdit.TextLength;
                            // Search, and if not found..
                            if (codeEdit.SearchInTarget(LastSearch) == -1)
                            {
                                // clear selection and exit
                                codeEdit.ClearSelections();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    // SEARCH FOR THE PREVIOUS OCCURANCE
                    // Search the document from the beginning to the caret
                    codeEdit.TargetStart = 0;
                    codeEdit.TargetEnd = codeEdit.CurrentPosition;
                    codeEdit.SearchFlags = SearchFlags.None;
                    // Search, and if not found..
                    if (codeEdit.SearchInTarget(LastSearch) == -1)
                    {
                        // Search again from the caret onwards
                        codeEdit.TargetStart = codeEdit.CurrentPosition;
                        codeEdit.TargetEnd = codeEdit.TextLength;
                        // Search, and if not found..
                        if (codeEdit.SearchInTarget(LastSearch) == -1)
                        {
                            // clear selection and exit
                            codeEdit.ClearSelections();
                            return;
                        }
                    }
                }
                // Select the occurance
                LastSearchIndex = codeEdit.TargetStart;
                codeEdit.SetSelection(codeEdit.TargetEnd, codeEdit.TargetStart);
                codeEdit.ScrollCaret();
            }
            ftxtSearch.Focus();
        }

        private void fReplace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ftxtSearch.Text))
                return;
            string rpl = ftxtReplace.Text;
            if (codeEdit.TargetStart > 0)
            {
                codeEdit.ReplaceTarget(rpl);
            }
            Find(true, false);
        }

        private void fReplaceAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ftxtSearch.Text))
                return;
            string rpl = ftxtReplace.Text;
            if (codeEdit.TargetStart > 0)
            {
                codeEdit.ReplaceTarget(rpl);
            }
            Find(true, false);
            while (codeEdit.TargetStart > 0)
            {
                codeEdit.ReplaceTarget(rpl);
                Find(true, false);
            }
        }

        private void fMore_Click(object sender, EventArgs e)
        {
            BoxRelpace();
        }

        private void codeEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                toolFind.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                toolReplace.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                toolAdd.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.K)
            {
                toolRemove.PerformClick();
            }
        }
        #endregion

        #region Tool
        private void cUndo_Click(object sender, EventArgs e)
        {
            codeEdit.Undo();
        }

        private void cRedo_Click(object sender, EventArgs e)
        {
            codeEdit.Redo();
        }

        private void cCut_Click(object sender, EventArgs e)
        {
            codeEdit.Cut();
        }

        private void cCopy_Click(object sender, EventArgs e)
        {
            codeEdit.Copy();
        }

        private void cPaste_Click(object sender, EventArgs e)
        {
            codeEdit.Paste();
        }

        private void cSelectAll_Click(object sender, EventArgs e)
        {
            codeEdit.SelectAll();
        }

        private void cFind_Click(object sender, EventArgs e)
        {
            CmdFind();
        }

        private void cReplace_Click(object sender, EventArgs e)
        {
            CmdReplace();
        }

        private void cAdd_Click(object sender, EventArgs e)
        {
            CmdAdd();
        }

        private void cRemove_Click(object sender, EventArgs e)
        {
            CmdRemove();
        }

        #endregion


    }
}