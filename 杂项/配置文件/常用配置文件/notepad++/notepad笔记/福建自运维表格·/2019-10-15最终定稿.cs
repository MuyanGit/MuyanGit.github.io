/*************************************************************************************************** 
* 版权所有：珠海优特电力科技股份有限公司 
* 版 本 号：2.00 
* 文 件 名：PowerBayManagerForm.cs 
* 生成日期：2017/08/15
* 更新日期：2017/08/15
* 作    者：李应连，许睿、魏威
* 功能说明：线路间隔窗口 
***************************************************************************************************/
#region 命名空间

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UT.LanguageSupport;
using UT.MemoryTables;
using UT.OSCommonDlg.Helpers;
using UT.Proxies;
using UT.Tables;
using UT.WFCommonUsed;
using UT.Resources;

#endregion

namespace ClientMonoMaintainUnlock
{
    public partial class AreaNoWinForm : Form
    {
        #region 变量定义
        /// <summary>
        /// 分段定义表（区域表）
        /// </summary>
        private DataTable _powerBayAreaCfg;
        private ComboBox _stationComboBox;
        private ComboBox _voltageComboBox;
        /// <summary>
        /// 电压等级表
        /// </summary>
        private DataTable _voltageTable;
        /// <summary>
        /// 分段定义表（区域表）的历史数据
        /// </summary>
        private PowerBayAreaCfgDataProcessor _powerBayAreaCfgDataPro;
        /// <summary>
        /// 是否可以修改数据表
        /// </summary>
        private readonly bool _canModifyPowerBayAreaCfg;
        /// <summary>
        /// 显示网格视图编辑器
        /// </summary>
        private bool showGridViewCellEditor;
        #endregion
        #region 构造函数
        public AreaNoWinForm()
        {
            InitializeComponent();//(string stationName)

            Icon = CommonResource.ResLoader.LoadIcon("JOYOJ.ico", "ICO", true);
            if (!DesignMode &&
                LanguageHelper.CurrentLanguageHelper != null &&
                LanguageHelper.CurrentLanguageHelper.LanguageType == LanguagesType.English_US)
                FreshFormUI.TranslateForm(this);

            _canModifyPowerBayAreaCfg = ObjectDepository.JoyoApplication.UserHasPermission(NamedUserRights.Sjpz).Result;

            btnDelete.Visible = _canModifyPowerBayAreaCfg;
            dgv_PowerBayAreaCfg.KeyDown += grv_PowerBay_KeyDown;

            if (!_canModifyPowerBayAreaCfg)
            {
                bt_Save.Visible = false;
            }
            else
            {
                btn_Add.Visible = true;
            }

            if (!InitDataGridView())
                return;

            UIHelper.SetUI(this);
            WFCommon.SetCurrentCursor(Cursors.Default);

            cbStation.DrawMode = DrawMode.OwnerDrawFixed;
            cbStation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStation.DrawItem += ComboBoxOnDrawItem;
            cbStation.SelectedValueChanged += ComboBoxSelectedValueChanged;

            _stationComboBox.Visible = false;
            _stationComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _stationComboBox.DrawItem += ComboBoxOnDrawItem;
            _stationComboBox.SelectedIndexChanged += _stationComboBox_SelectedIndexChanged;
            _stationComboBox.BackColor = System.Drawing.Color.LightBlue;
            dgv_PowerBayAreaCfg.Controls.Add(_stationComboBox);

            _voltageComboBox.Visible = false;
            _voltageComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            _voltageComboBox.DrawItem += ComboBoxOnDrawItem;
            _voltageComboBox.SelectedIndexChanged += _voltageComboBox_SelectedIndexChanged;
            _voltageComboBox.BackColor = Color.LightBlue;
            dgv_PowerBayAreaCfg.Controls.Add(_voltageComboBox);

        }
        #endregion
        #region 网格 -- 下拉框列

        private static void ComboBoxOnDrawItem(object sender, DrawItemEventArgs e)
        {
            DrawItemHelper.ComboBoxOnDrawItem(sender, e);
        }

        private void _stationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rowIndex = dgv_PowerBayAreaCfg.CurrentCell.RowIndex;
            var dataRowView = dgv_PowerBayAreaCfg.Rows[rowIndex].DataBoundItem as DataRowView;

            if (dataRowView == null)
            {
                return;
            }
            else if (_stationComboBox.Text == "全部厂站")
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("厂站不能选择‘全部厂站’!"), _powerBayAreaCfg.TableName),
                    UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!showGridViewCellEditor)
            {
                var row = dataRowView.Row;
                if (row["Station"] != null && row["Station"] != DBNull.Value)
                {
                    string oldStation = Convert.ToString(row["Station"]), newStation = CommonUsedTables.GetStationShortName(_stationComboBox.Text);
                    if (oldStation != newStation)
                        row["Station"] = newStation;
                }
            }
        }

        private void _voltageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rowIndex = dgv_PowerBayAreaCfg.CurrentCell.RowIndex;
            var dataRowView = dgv_PowerBayAreaCfg.Rows[rowIndex].DataBoundItem as DataRowView;

            if (dataRowView == null)
            {
                return;
            }
            else if (_voltageComboBox.Text == "全部")
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("电压不能选择‘全部’!"), _powerBayAreaCfg.TableName),
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

        private void SetComboBoxChecked(string columnName, DataGridViewCellMouseEventArgs e)
        {
            var dataTable = dgv_PowerBayAreaCfg.DataSource as DataTable;
            object focusedobj = null;

            if (columnName.Equals("Station", StringComparison.CurrentCultureIgnoreCase))
            {
                if (dataTable != null)
                    focusedobj = dgv_PowerBayAreaCfg.Rows[e.RowIndex].Cells[columnName].Value;

                if (focusedobj != null)
                {
                    string value = CommonUsedTables.GetStationFullName(focusedobj.ToString());
                    if (!string.IsNullOrEmpty(value))
                        _stationComboBox.Text = value;
                    else
                        _stationComboBox.SelectedIndex = -1;
                }
            }
            else if (columnName.Equals("Voltage", StringComparison.CurrentCultureIgnoreCase))
            {
                if (dataTable != null)
                    focusedobj = dgv_PowerBayAreaCfg.Rows[e.RowIndex].Cells[columnName].Value;

                if (focusedobj != null)
                {
                    string value = CommonUsedTables.GetVoltageName(focusedobj.ToString());
                    if (!string.IsNullOrEmpty(value))
                        _voltageComboBox.Text = value;
                    else
                        _voltageComboBox.SelectedIndex = -1;
                }
            }

        }

        #endregion

        #region 非界面响应函数

        /// <summary>
        /// 判断DataTale中判断“某几列”的表中“行数据”是否重复
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <param name="fieldData"></param>
        /// <returns></returns>
        public static Boolean IsIncludeData(DataTable dt, string[] strComuns)
        {

            if (dt.Rows.Count <= 0)
            {
                return false;//当数据为空时返回

            }
            //DataTable dtNew = dt.Clone();         //复制数据源的表结构
            //DataRow[] drs = dt.Select(strWhere);  //strWhere条件筛选出需要的数据！
            //if (drs.Length > 0)                   //判断是否存在符合的数据、为下面copy，不然报错
            //{
            //    dtNew = drs.CopyToDataTable();    //copy到新的datatable中！
            //}
            //打算将dt中的重复数据过滤掉  
            DataView myDataView = new DataView(dt);
            //此处可加任意数据项组合  
            DataTable dtBmzd = null;
            dtBmzd = myDataView.ToTable(true, strComuns);// 包含 具有与其所有列  不同的值    的行
            if (dtBmzd.Rows.Count < dt.Rows.Count)
            {
                return false;
                //message += "【列名1】、【列名2】值必须唯一，当前表中存在重复的数据，请确认！\n";
            }
            else
            {
                return true;
            }
        }



        /// <summary>
        /// 保存函数
        /// 保存当前修改后的表
        /// </summary>
        /// <returns></returns>
        private bool SavePowerBayAreaCfg()
        {
            #region 检查PowerBayTable中的记录是否都符合要求（Station、NO、Name字段不能为空），并给出提示

            var indexList = new List<int>();                                                       // 保存不符合条件的记录的索引   
            var stringList = new List<string>();                                                   // 保存不符合条件的记录的编号
            int countRows = this.dgv_PowerBayAreaCfg.Rows.Count;                                   // 保存不符合条件的记录的行

            foreach (DataRow row in _powerBayAreaCfg.Rows)
            {
                if (row.RowState == DataRowState.Deleted ||      // 检查PowerBayTable中的记录是否都符合要求（Station、NO、Name字段不能为空）
                    row.RowState == DataRowState.Detached)
                    continue;

                if (!String.IsNullOrEmpty(row["Name"].ToString()) &&
                    !String.IsNullOrEmpty(row["No"].ToString()) &&
                    !String.IsNullOrEmpty(row["Station"].ToString()))
                    continue;

                stringList.Add(row["No"].ToString());
                indexList.Add(_powerBayAreaCfg.Rows.IndexOf(row));
            }

            if (stringList.Count > 0)
            {
                var tmp = "";
                var count = 0;

                foreach (var s in stringList)
                {
                    count++;
                    tmp = stringList.IndexOf(s) == 0
                        ? string.Format("【{0}】", s) : string.Format(count % 6 == 0 ? "{0}、\n【{1}】" : "{0}、【{1}】", tmp, s);
                }

                var res = WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("“编号”为{0}的记录，\n“名称”字段为空，删除这些记录并保存？"), tmp),
                    UTLanguage.Translate("存在错误记录"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (res == DialogResult.Yes)
                {
                    for (var i = indexList.Count - 1; i >= 0; i--)                 // 选择YES，删除Name为空的记录
                    {
                        _powerBayAreaCfg.Rows.RemoveAt(indexList[i]);
                    }
                }
                else
                {
                    return false;
                }
            }

            //异站段位去重
            string[] strComuns = { "Station", "Name" };
            if (IsIncludeData(_powerBayAreaCfg, strComuns) == false)
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                   string.Format(UTLanguage.Translate("该站段位重复或存在空值!"), _powerBayAreaCfg.TableName),
                   UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (countRows > 1 && dgv_PowerBayAreaCfg.CurrentCell.RowIndex > 0)
            //{
            //    if (dgv_PowerBayAreaCfg.CurrentCell.ColumnIndex == 2)
            //    {
            //        for (int j = 0; j < this.dgv_PowerBayAreaCfg.CurrentCell.RowIndex; j++)
            //        {
            //            if (
            //                   //编辑表同站
            //                   dgv_PowerBayAreaCfg.Rows[j].Cells[1].Value.ToString() == dgv_PowerBayAreaCfg.Rows[dgv_PowerBayAreaCfg.CurrentCell.RowIndex].Cells[1].Value.ToString()
            //                //编辑表同段
            //                && dgv_PowerBayAreaCfg.Rows[j].Cells[2].Value.ToString() == dgv_PowerBayAreaCfg.Rows[dgv_PowerBayAreaCfg.CurrentCell.RowIndex].Cells[2].Value.ToString()
            //                )

            //            {
            //                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
            //         string.Format(UTLanguage.Translate("该站段位重复或存在空值!"), _powerBayAreaCfg.TableName),
            //         UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return false;
            //            }
            //        }
            //    }
            //}



            if (WFServerProxyBase.CurrentServer.WriteTable(_powerBayAreaCfg))
            {
                _powerBayAreaCfg.AcceptChanges();
                return true;
            }
            else
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("将数据写入表【{0}】失败!"), _powerBayAreaCfg.TableName),
                    UTLanguage.Translate("写数据失败"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #endregion
        }

        /// <summary>
        /// 从数据库中获取PowerBayAreaCfg、电压等级、厂站相关信息
        /// </summary>
        private void GetDataFormDb()
        {
            #region 获取电压等级信息
            if (CommonUsedTables.VoltageTable.Copy().Rows != null)
            {
                _voltageTable = CommonUsedTables.VoltageTable.Copy();

                var voltageStru = CommonUsedTables.VoltageTable.Copy();
                var row = voltageStru.NewRow();

                row["NO"] = 0;
                row["NAME"] = "全部";

                voltageStru.Rows.InsertAt(row, 0);


            }
            #endregion


            #region 获取厂站表
            var stationTable = CommonUsedTables.ClientStationTables.Copy();
            var stationStru = CommonUsedTables.ClientStationTables.Copy();

            var shortName = UTTableBasic.FindFieldName(stationTable, "ShortName");
            var description = UTTableBasic.FindFieldName(stationTable, "Description");
            var nameField = UTTableBasic.FindFieldName(stationTable, "Name");
            var noField = UTTableBasic.FindFieldName(stationTable, "No");
            var stationNewRow = stationTable.NewRow();

            stationNewRow[shortName] = UTLanguage.Translate("全部厂站");
            stationNewRow[noField] = -100;
            stationNewRow[description] = UTLanguage.Translate("全部厂站");
            stationNewRow[nameField] = UTLanguage.Translate("全部厂站");
            stationTable.Rows.InsertAt(stationNewRow, 0);

            cbStation.DataSource = stationTable;
            cbStation.ValueMember = UTTableBasic.FindFieldName(stationTable, "ShortName");
            cbStation.DisplayMember = UTTableBasic.FindFieldName(stationTable, "Name");
            cbStation.SelectedIndex = 0;
            #endregion

            _stationComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            for (var i = 0; i < stationStru.Rows.Count; i++)
            {
                _stationComboBox.Items.Add(stationStru.Rows[i]["Name"]);
            }



            _voltageComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            for (var i = 0; i < _voltageTable.Rows.Count; i++)
            {
                _voltageComboBox.Items.Add(_voltageTable.Rows[i]["Name"]);
            }
        }

        /// <summary>
        /// 初始化网格
        /// </summary>
        private bool InitDataGridView()
        {
            #region 获取线路表
            _powerBayAreaCfgDataPro = new PowerBayAreaCfgDataProcessor();
            _powerBayAreaCfg = _powerBayAreaCfgDataPro.PowerBayDataTableProcessor;

            if (_powerBayAreaCfg == null)
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm, UTLanguage.Translate("获取表PowerBayAreaCfg表失败！"));
                return false;
            }
            #endregion

            #region 获取需要显示的字段的描述
            DataTable powerBayStructure = WFCommon.GetStructureTableFromResourceDefination("PowerBayAreaCfg");

            if (powerBayStructure == null ||
                powerBayStructure.Rows == null ||
                powerBayStructure.Rows.Count == 0)
            {
                return false;
            }
            #endregion

            GetDataFormDb();         //从数据库中获取PowerBayAreaCfg、电压等级、厂站相关信息

            if (_powerBayAreaCfg == null)
            {
                return true;
            }

            #region 构造 DataGridView

            dgv_PowerBayAreaCfg.Columns.Add(new DataGridViewTextBoxColumn         // 编号
            {
                HeaderText = @"编号",
                Name = "No",
                DataPropertyName = "No",
                ValueType = typeof(int),
                Width = 70
            });
            dgv_PowerBayAreaCfg.Columns.Add(new DataGridViewTextBoxColumn         // 实际的厂站
            {
                HeaderText = @"厂站",
                Name = "Station",
                DataPropertyName = "Station",
                ReadOnly = true,
                ValueType = typeof(string)
            });
            dgv_PowerBayAreaCfg.Columns.Add(new DataGridViewTextBoxColumn         // 名称
            {
                HeaderText = @"名称",
                Name = "Name",
                DataPropertyName = "Name",
                ValueType = typeof(string)
            });
            #region 暂时移除电压等级
            dgv_PowerBayAreaCfg.Columns.Add(new DataGridViewTextBoxColumn         // 实际的电压等级
            {
                HeaderText = @"电压等级",
                Name = "Voltage",
                ReadOnly = true,
                DataPropertyName = "Voltage"
            });
            #endregion


            #endregion

            dgv_PowerBayAreaCfg.AutoGenerateColumns = false;

            return true;
        }

        /// <summary>
        /// 删除行
        /// 支持单选和多选
        /// </summary>
        private void DeletePowerBay()
        {
            #region 删除之前需要进行确认
            //if (WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
            //        UTLanguage.Translate("真要删除吗?"),
            //        UTLanguage.Translate("删除数据"), MessageBoxButtons.YesNo) != DialogResult.Yes)
            //{
            //    return;
            //} 
            #endregion

            if (dgv_PowerBayAreaCfg.CurrentRow == null ||
                dgv_PowerBayAreaCfg.CurrentRow.Index <= -1)
            {
                return;
            }

            var index = GridViewHelper.DeleteSelectedDataGridViewRows(dgv_PowerBayAreaCfg);

            if (index < 0)
            {
                return;
            }

            if (index == dgv_PowerBayAreaCfg.Rows.Count)
            {
                index--;
                _powerBayAreaCfg.Rows.RemoveAt(dgv_PowerBayAreaCfg.CurrentCell.RowIndex);
            }

            dgv_PowerBayAreaCfg.Rows[index].Selected = true;
            dgv_PowerBayAreaCfg.CurrentCell = dgv_PowerBayAreaCfg.Rows[index].Cells[0];
        }

        #endregion

        #region DataTable

        private void powerBayTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            bt_Save.Enabled = true;
        }

        private void powerBayTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            bt_Save.Enabled = true;
        }

        private void powerBayTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            bt_Save.Enabled = true;
        }

        #endregion

        #region 窗体相关
        private void PowerBayManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

            var dataTable = _powerBayAreaCfg.GetChanges();

            if (dataTable == null || (!bt_Save.Enabled || (dataTable.Rows.Count <= 0)))
            {
                return;
            }

            e.Cancel = WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm, UTLanguage.Translate("所作修改未保存，是否退出?"), UTLanguage.Translate("未保存修改"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }
        #endregion

        #region 按钮响应

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePowerBay();
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            bt_Save.Enabled = !SavePowerBayAreaCfg();

        }



        /// <summary>
        /// 新增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            var maxNo = UTTableBasic.FindLargestValue(_powerBayAreaCfg, "No");
            #region 逐行添加
            //DataTable tblMaxNo = WFServerProxyBase.CurrentServer.GetViewOnlyTable("select MAX(No) No from PowerBayAreaCfg");
            //int maxNo = 0;
            //if (tblMaxNo != null)
            //{
            //    maxNo = int.Parse(UTTableBasic.GetDataRowFieldValue(tblMaxNo, "No", "0"));
            //}
            //else
            //{
            //    WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
            //        string.Format(UTLanguage.Translate("获取最大编号失败!"), _powerBayAreaCfg.TableName),
            //        UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            #endregion
            if (maxNo < 0)
            {
                WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                    string.Format(UTLanguage.Translate("获取最大编号失败!"), _powerBayAreaCfg.TableName),
                    UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var arealRow = _powerBayAreaCfg.NewRow();

            if (cbStation.Text.Equals(UTLanguage.Translate("全部厂站")))
            {
                arealRow["Station"] = ObjectDepository.JoyoApplication.CurrentLinkInfo.Station.Name;
            }
            else
            {
                arealRow["Station"] = cbStation.SelectedValue.ToString();//CommonUsedTables.GetStationShortName(cbStation.Text);
            }

            arealRow["No"] = maxNo + 1;
            //arealRow["Name"] = "";
            arealRow["Name"] = string.Concat(arealRow["Station"].ToString()/*.Substring(0,2)*/, UTLanguage.Translate("段位"), arealRow["No"].ToString());//arealRow["Station"] ,
            arealRow["Voltage"] = 4;//默认220kV/*cbStation.SelectedValue.ToString();*///CommonUsedTables.GetStationShortName(cbStation.Text);
            _powerBayAreaCfg.Rows.Add(arealRow);

            foreach (DataGridViewCell cell in dgv_PowerBayAreaCfg.SelectedCells)
            {
                cell.Selected = false;
            }
            dgv_PowerBayAreaCfg.Rows[dgv_PowerBayAreaCfg.RowCount - 1].Selected = true;
            dgv_PowerBayAreaCfg.CurrentCell = dgv_PowerBayAreaCfg.Rows[dgv_PowerBayAreaCfg.RowCount - 1].Cells[0];

        }

        #endregion

        #region LookUpEdit

        private void ComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            var str = FilterType();
            RefreshDataGridView(str);

            _voltageComboBox.Visible = false;
            _stationComboBox.Visible = false;
        }

        #endregion

        #region 窗体事件

        private void PowerBayManagerForm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView(string.Empty);

            dgv_PowerBayAreaCfg.Columns["No"].Width = 70;
            dgv_PowerBayAreaCfg.Columns["No"].DefaultCellStyle.BackColor = UIHelper.TableCellDisableBackColor;
            dgv_PowerBayAreaCfg.Columns["No"].ReadOnly = true;

            UIHelper.RightAnchor(bt_Close, bt_Save, btnDelete, btn_Add);
        }

        /// <summary>
        /// 生成过滤条件
        /// </summary>
        /// <returns>返回过滤语句（sql）</returns>
        private string FilterType()
        {

            var stationName = cbStation.SelectedValue == null ? "" : cbStation.SelectedValue.ToString();//CommonUsedTables.GetStationShortName(cbStation.Text);

            if (stationName.Equals(UTLanguage.Translate("全部厂站")))
                stationName = "";

            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(stationName))
                sb.AppendFormat("{0} = '{1}'", (sb.Length > 0) ? "" : "Station", stationName);
            var seleCmd = sb.ToString();
            return seleCmd;
        }

        private void RefreshDataGridView(string filterStr)
        {
            DataView dv = _powerBayAreaCfg.DefaultView;
            dv.RowFilter = filterStr;
            //_powerBayTable.DefaultView.RowFilter = filterStr;
            _powerBayAreaCfg.RowChanged -= powerBayTable_RowChanged;
            _powerBayAreaCfg.RowDeleted -= powerBayTable_RowDeleted;
            _powerBayAreaCfg.ColumnChanged -= powerBayTable_ColumnChanged;
            _powerBayAreaCfg.RowChanged += powerBayTable_RowChanged;
            _powerBayAreaCfg.RowDeleted += powerBayTable_RowDeleted;
            _powerBayAreaCfg.ColumnChanged += powerBayTable_ColumnChanged;

            dgv_PowerBayAreaCfg.DataSource = dv.Table;// _powerBayTable;
        }

        /// <summary>
        /// 重新锚定按钮位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PowerBayManagerForm_Shown(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    UIHelper.RightAnchor(c as Button);
                }
            }
        }

        #endregion

        #region 网格事件

        /// <summary>
        /// delelte 键位删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grv_PowerBay_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_canModifyPowerBayAreaCfg)
            {
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                DeletePowerBay();
            }
        }

        private void dgv_PowerBay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dgv_PowerBayAreaCfg.ColumnCount)
            {
                return;
            }

            try
            {
                if (dgv_PowerBayAreaCfg.Columns[e.ColumnIndex].Name.Equals("Station", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (null != e.Value)
                    {
                        e.Value = CommonUsedTables.GetStationFullName(e.Value.ToString());
                    }
                }

                if (!dgv_PowerBayAreaCfg.Columns[e.ColumnIndex].Name.Equals("Voltage", StringComparison.CurrentCultureIgnoreCase))
                {
                    return;
                }

                if (null != e.Value)
                {
                    e.Value = CommonUsedTables.GetVoltageName(e.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                WFCommon.MessageBox.Show(UTLanguage.Translate("CellFormatting失败:") + ex);
            }
        }

        private void dgv_PowerBay_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Clicks < 2)
                return;

            var columnFieldName = dgv_PowerBayAreaCfg.Columns[e.ColumnIndex].DataPropertyName;
            var rect = dgv_PowerBayAreaCfg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

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

        private void dgv_PowerBay_Scroll(object sender, ScrollEventArgs e)
        {
            _voltageComboBox.Visible = false;
            _stationComboBox.Visible = false;

        }

        private void dgv_PowerBay_SelectionChanged(object sender, EventArgs e)
        {
            _voltageComboBox.Visible = false;
            _stationComboBox.Visible = false;

        }

        private void dgv_PowerBay_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            _voltageComboBox.Visible = false;
            _stationComboBox.Visible = false;

        }

        private void dgv_PowerBay_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            foreach (DataRow row in _powerBayAreaCfg.Rows)
            {
                // 检查PowerBayTable中的记录是否都符合要求（Station、NO、Name字段不能为空）
                if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Detached)
                    continue;

                if (String.IsNullOrEmpty(row["No"].ToString()))
                {
                    WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                        string.Format(UTLanguage.Translate("‘编号’列不允许存在空数据，操作失败。"), _powerBayAreaCfg.TableName),
                        UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (String.IsNullOrEmpty(row["Station"].ToString()))
                {
                    WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                        string.Format(UTLanguage.Translate("‘厂站’列不允许存在空数据，操作失败。"), _powerBayAreaCfg.TableName),
                        UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (String.IsNullOrEmpty(row["Name"].ToString()))
                {
                    WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                        string.Format(UTLanguage.Translate("‘名称’列不允许存在空数据，操作失败。"), _powerBayAreaCfg.TableName),
                        UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dgv_PowerBay_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        #endregion
    }

    /// <summary>
    /// 数据访问辅助类
    /// </summary>
    internal class PowerBayAreaCfgDataProcessor
    {
        #region 接口方法
        private DataTable _powerBayDataTableProcessor;

        /// <summary>
        /// 读取区域表的历史数据
        /// </summary>
        internal DataTable PowerBayDataTableProcessor
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                DataRow[] rows = CommonUsedTables.ClientStationTables.Copy().Select("1=1");
                for (int i = 0; i < rows.Length; i++)
                {
                    if (i == rows.Length - 1)
                    {
                        sb.Append(string.Format("'{0}'", rows[i]["ShortName"].ToString()));
                    }
                    else
                    {
                        sb.Append(string.Format("'{0}',", rows[i]["ShortName"].ToString()));
                    }
                }
                //非空
                return _powerBayDataTableProcessor ??
                    (_powerBayDataTableProcessor = WFServerProxyBase.CurrentServer.GetEditableTable(string.Format("select * from PowerBayAreaCfg where Station in ({0}) order by No ", sb.ToString())));
            }

            set
            {
                _powerBayDataTableProcessor = value;
            }
        }
        #endregion
    }
}