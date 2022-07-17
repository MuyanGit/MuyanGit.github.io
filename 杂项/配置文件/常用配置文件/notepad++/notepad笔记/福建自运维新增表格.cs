目标
1·完成自动隐藏其他列表
2·删除其他列表 --> 增加站表

测试
世间好物不坚固
	
	彩云易散琉璃翠
	
	窗边日光最易过
	
	身前花影座前移
	
	
	且将新货试新茶
	
	诗酒趁年华
	
	一壶清酒醉风尘
	
	言念君子，温其如玉
	
	竹杖芒鞋轻胜马
	
	天地如逆旅
	
	我亦是过客
	
	(*^▽^*)






1·修改表结构
2·新增表结构

数据库结构
14 
2037  
.
初始化表格
E:\项目控制\ScadaIV\JOYOJ6\五防平台\数据库表单\UTDbTable\DatabaseDataRestoreBase.cs


1· this.dgv_PowerBay.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_PowerBay_CellFormatting);

归属网格事件 --> 
2· private void dgv_PowerBay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)

鼠标移开事件
   private void dgv_PowerBay_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Clicks < 2)
                return;

            var columnFieldName = dgv_PowerBay.Columns[e.ColumnIndex].DataPropertyName;
            var rect = dgv_PowerBay.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);//单元格显示的界限 --> Rectangle -->  存储一组整数，共四个，表示一个矩形的位置和大小

            if (columnFieldName.Equals("Station", StringComparison.CurrentCultureIgnoreCase))
            {
                _stationComboBox.Left = rect.Left;
                _stationComboBox.Top = rect.Top;
                _stationComboBox.Width = rect.Width;
                _stationComboBox.Height = rect.Height;
                _stationComboBox.Visible = true;
            }
            else
                _stationComboBox.Visible = false;

            if (columnFieldName.Equals("Voltage", StringComparison.CurrentCultureIgnoreCase))
            {
                _voltageComboBox.Left = rect.Left;
                _voltageComboBox.Top = rect.Top;
                _voltageComboBox.Width = rect.Width;
                _voltageComboBox.Height = rect.Height;
                _voltageComboBox.Visible = true;
            }
            else
                _voltageComboBox.Visible = false;

            this.showGridViewCellEditor = true;
            SetComboBoxChecked(columnFieldName, e);
            this.showGridViewCellEditor = false;
        }

E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\WFInterfaceWinForm\PowerBayManagerForm.Designer.cs
        private System.Windows.Forms.ComboBox cbAreaNo;
230

e:\项目控制\scadaiv\joyoj6\五防平台\人机交互\wfinterfacewinform\powerbaymanagerform.cs
 private void _voltageComboBox_SelectedIndexChanged(object sender, EventArgs e)
194 --> 电压等级不可以选择全部




修改控制代码
  private void _voltageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rowIndex = dgv_PowerBay.CurrentCell.RowIndex;
            var dataRowView = dgv_PowerBay.Rows[rowIndex].DataBoundItem as DataRowView;

            if (dataRowView == null)
            {
                return;
            }
            else if (_voltageComboBox.Text == "全部")
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("电压不能选择‘全部’!"), _powerBayTable.TableName),
                    UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!showGridViewCellEditor)
            {
                var row = dataRowView.Row;
                if (row["Voltage"] != null && row["Voltage"] != DBNull.Value)
                {
                    int oldVoltage = Convert.ToInt32(row["Voltage"]), newVoltage = CommonUsedTables.GetVoltageCode(_voltageComboBox.Text);
                    if (oldVoltage != newVoltage)
                        row["Voltage"] = newVoltage;
                }
                else
                {
                    row["Voltage"] = Convert.ToInt32(CommonUsedTables.GetVoltageCode(_voltageComboBox.Text));
                }
            }
        }

		
		
		获取区域
		   /// <summary>
        /// 根据电压等级名或值获取电压等级编码
        /// </summary>
        /// <param name="voltageName"></param>
        /// <returns></returns>
        static public int GetVoltageCode(string voltageName)
        {
            if (!string.IsNullOrEmpty(voltageName))
            {
                DataRow r = UTTableBasic.LocateInTable(VoltageTable, "Name", voltageName);
                if (r != null)
                {
                    return int.Parse(UTTableBasic.GetDataRowFieldValue(r, "no", "0"));
                }
                r = UTTableBasic.LocateInTable(VoltageTable, "Voltage", voltageName);
                if (r != null)
                {
                    return int.Parse(UTTableBasic.GetDataRowFieldValue(r, "no", "0"));
                }
                voltageName = AjustVoltageValuelName(voltageName);
                r = UTTableBasic.LocateInTable(VoltageTable, "Name", voltageName);
                if (r != null)
                {
                    return int.Parse(UTTableBasic.GetDataRowFieldValue(r, "no", "0"));
                }
                r = UTTableBasic.LocateInTable(VoltageTable, "Voltage", voltageName);
                if (r != null)
                {
                    return int.Parse(UTTableBasic.GetDataRowFieldValue(r, "no", "0"));
                }
            }
            return 0;
        }


/// <summary>
        /// 查找某站的站名缩写
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        static public string GetStationShortName(string stationName)
        {
            if (StationTable != null)
            {
                DataRow r = LocateStationRow(stationName);
                if (r != null)
                {
                    return UTTableBasic.GetDataRowFieldValue(r, "ShortName", stationName);
                }
            }
            return stationName;
        }

cbSpecialty
lblAreaNo
cbAreaNo
		
		
		
#第二部分 --> 		
		
		dgv_PowerBay.Columns.Add(new DataGridViewTextBoxColumn         // 区域归属
            {
                HeaderText = @"区域",
                Name = "AreaNo",
                DataPropertyName = "AreaNo",
                ReadOnly = true,
                //ValueType = typeof(string)
            });
		voltageTable
		areaNoTable
		PowerBay 	,AreaNo
##等待增加的代码

1· 初始化网格
private bool InitDataGridView()

		/// <summary>
        /// 区域表查询
        /// </summary>
        static public DataTable AreaNoTabe
        {
            get
            {
                if (areaNoTable == null)
                {
                    areaNoTable = ReadTable("PowerBay","AreaNo");// UTCommonTables.ReadDataTableFromResource("Voltage");
                }
                return areaNoTable;

            }
            set
            {
                areaNoTable = value;
            }

        }



		/// <summary>
        /// 线路表
        /// </summary>
        private DataTable _powerBayTable;
        private ComboBox _stationComboBox;
        private ComboBox _voltageComboBox;
        private ComboBox _areaNoComboBox;

        /// <summary>
        /// 电压等级表
        /// </summary>
        private DataTable _voltageTable;

        /// <summary>
        /// 区域归属表
        /// </summary>
        private DataTable _areaNoTable;

		
		
			_areaNoComboBox.Visible = false;
            _areaNoComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _areaNoComboBox.DrawItem += ComboBoxOnDrawItem;
            _areaNoComboBox.SelectedIndexChanged += _areaNoComboBox_SelectedIndexChanged;
            _areaNoComboBox.BackColor = Color.LightBlue;
            dgv_PowerBay.Controls.Add(_areaNoComboBox);
		
		
		
		
		  /// <summary>
        /// 写入区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _areaNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rowIndex = dgv_PowerBay.CurrentCell.RowIndex;
            var dataRowView = dgv_PowerBay.Rows[rowIndex].DataBoundItem as DataRowView;

            if (dataRowView == null)
            {
                return;
            }
            else if (_stationComboBox.Text == "全部厂站")
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("厂站不能选择‘全部厂站’!"), _powerBayTable.TableName),
                    UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!showGridViewCellEditor)
            {
                var row = dataRowView.Row;
                if (row["AreaNo"] != null && row["AreaNo"] != DBNull.Value)
                {
                    string oldAreaNo = Convert.ToString(row["AreaNo"]), newStation = CommonUsedTables.GetStationShortName(_stationComboBox.Text);
                    if (oldAreaNo != newStation)
                        row["AreaNo"] = newStation;
                }
            }
        }
		
		
		
		AreaNoTable
		AreaNo
		
		
		E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\ClientExtraDll\ClientMonoData\ClientMonoData.cs
		#电压等级
		f = new FunctionSpotExt("btnShowVoltage", JoyoSystemType.All, JoyoServerClassification.Unknown, AuthorizedRunMode.Undefined, NamedUserRights.None, false, false, true, true, "电压等级配置.png",false, true, OpenedDrawType.None)
            {
                PageName = "pageData",
                GroupName = "gpData5",
                PagePosition = 50,
                GroupPositon = 5,
                Position = 1,
                PageTitle = "数据管理",
                Caption = "电压等级",
                OnClick = ObjectDepository.JoyoApplication.ShowVoltage
            };
			
			#遍历按钮
			 /// <summary>
        /// 数据管理 --> 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataManagerment_ItemClick(object sender, EventArgs e)
		
		
		#菜单点击
  E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\JoyoNoMenuForm\MainForm.cs(1503):            mnShowVoltage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.systemApp.ShowVoltage);
  
  #电压等级表
   /// <summary>
        /// 电压等级表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowVoltage(object sender, EventArgs e)
        {
            if (ProxyManager.WFServer.ServerClass != JoyoServerClassification.Screen && ServerAvailable)
            {
                UIProxyBase.CurrentUIProxy.VoltageFormShow(SystemMainForm.ContainerControl);
            }
        }
				
		
		
区域归属
  //名称
            dc = new DataGridViewTextBoxColumn();
            dc.Name = "VolName";
            dc.DataPropertyName = "Name".ToUpper();
            dc.HeaderText = "名称";
            dc.Width += 100;
            dc.Visible = true;
            dc.SortMode = DataGridViewColumnSortMode.NotSortable;
            grc_Voltage.Columns.Add(dc);
		
		
		//区域归属
            dc = new DataGridViewTextBoxColumn();
            dc.Name = "AreaNo";
            dc.DataPropertyName = "AreaNo".ToUpper();
            dc.HeaderText = "区域归属";
            dc.Width += 50;
            dc.Visible = false;
            grc_Voltage.Columns.Add(dc);
			
			


voltageTable
		
		areaNoTable
		
		
		
		
		
		 static private DataTable stationTable;	//站信息表
        /// <summary>
        /// 站信息表，访问时如果表不存在则从数据库中读取，设置该属性则将表删除以便重新从数据库读取。
        /// </summary>
        static public DataTable StationTable
        {
            get
            {
                if (stationTable == null)
                {
                    string stationTableName = "StationCfg";

                    if (MemoryTableLoadMode == TableLoadMode.FromDatabase)
                    {
                        if (UTTableInst != null && UTTableInst.Utdb.UTDatabaseInfo.Code == UTDatabaseInformationCode.Available)
                        {
                            stationTable = UTTableInst.GetEditableTable(string.Format("select * from {0} order by {1}", UTTableInst.QuotedTableName(stationTableName), UTTableInst.QuotedFieldName("NO")));
                        }
                        else
                        {
                            UTMessageBase.ShowOneMessage(string.Format(UTLanguage.Translate("数据库连接不正常,无法从数据库中读取内存表:{0}"), stationTableName), PopupMessageType.Error);
                        }
                    }
                    else
                    {
                        if (stationTable == null)
                        {
                            UTMessageBase.ShowOneMessage(string.Format(UTLanguage.Translate("还没有从服务器读取表:{0}便需访问该表"), stationTableName), PopupMessageType.Error);
                        }
                    }
                }
                return stationTable;
            }
            set
            {
                stationTable = value;  //设置后便于重新读取
            }
        }
		
		
		
		
		文件
		E:\项目控制\ScadaIV\JOYOJ6\五防平台\公共模块\MemoryTables\MemoryTables.cs
		E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\ClientExtraDll\ClientMonoMaintainUnlock\AreaNoWinForm.cs
		e:\项目控制\scadaiv\joyoj6\五防平台\人机交互\clientextradll\clientmonomaintainunlock\clientmonomaintainunlock.cs
		E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\WFInterfaceWinForm\PowerBayManagerForm.cs
		E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\ClientExtraDll\ClientMonoMaintainUnlock\AreaNoWinForm.designer.cs