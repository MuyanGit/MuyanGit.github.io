DataView --> 验证重复
 public static DataTable Distinct(DataTable dt, string[] filedNames)
        {
            DataView dv = dt.DefaultView;
            DataTable DistTable = dv.ToTable("Dist", true, filedNames);
            return DistTable;
        }

/// <summary>
/// 验证上传文件中是否含有数据库数据
/// </summary>
/// <param name="dt1">excel文件中数据</param>
/// <param name="dt2">数据库中数据</param>
/// <returns></returns>
public string GetTableDiffer(DataTable dt1,DataTable dt2)
{
DataTable myTable = dt1.Clone();
for (int i = 0; i < dt1.Rows.Count; i++)
{
DataRow[] Row = dt2.Select("CouponNO='"+dt1.Rows[i]["券号"].ToString()+"'");
if (Row.Length > 0)
{
return "该优惠券号【" + dt1.Rows[i]["券号"].ToString() + "】数据库中已存在";
}
}
return "无重复";
}

///泛型比较重复数据
using System.Collections.Generic;
namespace GeZhongTest
{   
    /// <summary>   
    /// 泛型去重复比较类    
    /// </summary>    
    class ListComparer:IEqualityComparer<string>    
    {        
        public bool Equals(string a, string b)        
        {            
            if (a == b)            
            {                
                return true;            
            }            
            else            
            {                
                return false;               
            }        
        }        
        public int GetHashCode(string obj)        
        {            
            return 0;        
        }    
    }
}


遍历list
static void Main(string[] args)        
{            
List<string> list = new List<string>();            
for (int i = 0; i < 5; i++)            
{                
list.Add("shenme" + i);            
}            
list.Add("shenme2");            
list.Add("shenme3");            
for (int j = 10; j < 15; j++)            
{                
list.Add("ha" + j);           
}            
list.Add("ha12");            
Console.WriteLine("去重之前");            
Console.WriteLine("******************************");            
foreach (string eve in list)            
{                
Console.Write(eve + "\t");            
}            
Console.WriteLine("******************************");                        
Console.WriteLine("去重之后");            
Console.WriteLine("******************************");           
//调用方法去重复            
var resultList = list.Distinct(new ListComparer());             
foreach(var item in resultList)            
{               
Console.Write(item.ToString() + "\t");            
}            
Console.WriteLine("******************************");           
Console.ReadKey();        
}


/// <summary>
///GridViewMergeCell 合并GridView 
/// </summary>
public class GridViewMerge
{
    public static void spanRow(SuperGridControl dg, string GroupColumn)
    {
        int i = 0;
        int j = 0;
        int rowSpan;
        string strTemp = "";
        string strTemp2 = "";
        GridElement col;
        GridRow a;
 
        for (i = 0; i < dg.PrimaryGrid.Rows.Count; i++)
        {
            rowSpan = 1;
            col = dg.PrimaryGrid.Rows[i];
            a = col as GridRow;
            strTemp = a.Cells[GroupColumn].Value.ToString();
            for (j = i + 1; j < dg.PrimaryGrid.Rows.Count; j++)
            {
                col = dg.PrimaryGrid.Rows[j];
                a = col as GridRow;
                strTemp2 = a.Cells[GroupColumn].Value.ToString();
 
                if (string.Compare(strTemp, strTemp2) == 0)
                {
                    rowSpan += 1;
                    //dg.Items[i].Cells[GroupColumn].RowSpan = rowSpan;
                    //dg.Items[j].Cells[GroupColumn].Visible = false;
                    a.Cells[GroupColumn].Visible = false;  
                }
                else
                {
                    break;
                }
            }
            i = j - 1;
        }
    }
     
}

优选代码
  private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ///获取总行
			int count = this.dataGridView1.Rows.Count;
			///行数大于1
             
            if (count > 1 && dataGridView1.CurrentCell.RowIndex>0)
            {
					///当前单元格 --> 列编号 
                if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
                {
					//////当前单元格 --> 行编号 
                    for (int i = 0; i <this .dataGridView1.CurrentCell .RowIndex ; i++)
                    {
                        if (this.dataGridView1.Rows[i].Cells[1].Value.ToString() == this.dataGridView1.Rows [this .dataGridView1 .CurrentCell .RowIndex ].Cells [1].Value .ToString ())
                        {
                            MessageBox.Show("此值重复了！！！","提示");
                            break;
                        }
                    }
                }
            }
        }


遍历所有名 --> 
是否名相同 --> 


同站 --> 异名





 if (stationName.Equals(UTLanguage.Translate("全部厂站")))
            {
                dgv_PowerBayAreaCfg.ReadOnly = true;
                stationName = "";
            }



bt_Save.Visible = false;






1 2 3
1.1
1.2
1.3
禁用禁止编辑厂站 --> 下拉框
111111111111111111111111111111111111111111111111111111111111111111111111111111



 private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }





		
		 //异站段位去重
            if (countRows > 1 && dgv_PowerBayAreaCfg.CurrentCell.RowIndex > 0)


            {
                if (dgv_PowerBayAreaCfg.CurrentCell.ColumnIndex == 2)

                {
                    for (int j = 0; j < this.dgv_PowerBayAreaCfg.CurrentCell.RowIndex; j++)
                    {
                        if (
                               //编辑表同站
                               dgv_PowerBayAreaCfg.Rows[j].Cells[1].Value.ToString() == dgv_PowerBayAreaCfg.Rows[dgv_PowerBayAreaCfg.CurrentCell.RowIndex].Cells[1].Value.ToString()
                            //编辑表同段
                            && dgv_PowerBayAreaCfg.Rows[j].Cells[2].Value.ToString() == dgv_PowerBayAreaCfg.Rows[dgv_PowerBayAreaCfg.CurrentCell.RowIndex].Cells[2].Value.ToString()
                            /*&& String.IsNullOrEmpty(dgv_PowerBayAreaCfg.Rows[j].Cells[1].Value.ToString())*/
                            )
                        {
                            WFCommon.MessageBox.Show(ObjectDepository.SystemMainForm,
                     string.Format(UTLanguage.Translate("该站段位重复或存在空值!"), _powerBayAreaCfg.TableName),
                     UTLanguage.Translate("提示"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
回车键
			 protected override bool ProcessDialogKey(Keys keyData)

    {

        if (keyData == Keys.Enter)

        {

            int col = this.CurrentCell.ColumnIndex;

            int row = this.CurrentCell.RowIndex;

            if (row != this.NewRowIndex)

            {

                if (col == (this.Columns.Count - 1))

                {

                    col = -1;

                    row++;

                }

                this.CurrentCell = this[col + 1, row];

            }

            return true;

        }

        return base.ProcessDialogKey(keyData);

    }

 

    protected override void OnKeyDown(KeyEventArgs e)

    {

        if (e.KeyData == Keys.Enter)

        {

            int col = this.CurrentCell.ColumnIndex;

            int row = this.CurrentCell.RowIndex;

            if (row != this.NewRowIndex)

            {

                if (col == (this.Columns.Count - 1))

                {

                    col = -1;

                    row++;

                }

                this.CurrentCell = this[col + 1, row];

            }

            e.Handled = true;

        }

        base.OnKeyDown(e);

    }

}



//多列主键

DataTable dtsegment = CmmDb.GetDataTable(string.Format("select * from {0}.segment where 1=2",CmmDb.dbUser));
dtsegment.PrimaryKey=new DataColumn[2]{dtsegment.Columns["AIRWAY_POINT1"],dtsegment.Columns["AIRWAY_POINT2"]};

//按主键查找行

DataRow segrow=dtsegment.Rows.Find( new object[]{ pid1, pid2}) ; 该行与总表是应用关系，改变dr也就改变了主表


//如果该DataTable要整体写入数据库，最后在写入前删除主键，避免出错

fdt.PrimaryKey = null;








private void CheckDataRepeat(DataSet dataSet, out string message)  
       {  
           message = string.Empty;  
           DataView dv = new DataView(dataSet.Tables[0]);  
           DataTable dtBmzd = null;  
           dtBmzd = dv.ToTable(true, new string[] { "Station", "Name" });  
           if (dtBmzd.Rows.Count < dataSet.Tables[0].Rows.Count)  
           {  
               message += "【厂站列】、【名称列】值必须唯一，当前表中存在重复的数据，请确认！\n";  
           }  
       }  


DataTable dt = new DataTable();  
dt = ......//给dt赋值  
//将dt中的重复数据过滤掉  
DataView myDataView = new DataView(dt);  
//此处可加任意数据项组合  
string[] strComuns = { "列1", "列2", "列3"};  
dt = myDataView.ToTable(true, strComuns);  





列名A	列名1
列名B	列名1
列名B	列名1





















