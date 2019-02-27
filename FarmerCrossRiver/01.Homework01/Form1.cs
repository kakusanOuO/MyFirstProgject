using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateList();
            Reset();
            SetListBoxDataSource();
            ChangeData();
        }        
        //放進 _mylist 的每個資料都是字串 List<string> _mylist;
        private List<string> _leftList;
        private List<string> _rightList;
        private List<string> _listBox3;
        /// <summary>
        /// 建立陣列內容
        /// </summary>
        private void CreateList()
        {
            _leftList = new List<string> { "農夫", "狼", "羊", "菜" };
            _rightList = new List<string>();
            _listBox3 = new List<string>();
        }
        public void Reset()
        {
            _leftList = new List<string> { "農夫", "狼", "羊", "菜" };
            _rightList = new List<string>();
            _listBox3 = new List<string>();
        }
        /// <summary>
        /// 決定listBox的選擇方式
        /// </summary>
        private void SetListBoxDataSource()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }
        /// <summary>
        /// 宣告listBox資料來源
        /// </summary>
        private void ChangeData()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox3.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
            listBox3.DataSource = _listBox3;
            listBox3.TopIndex = _listBox3.Count - 1; //視窗永遠顯示在最下面
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string item = (string)listBox1.SelectedItem;
                //string Farmer = _leftList.Find((x) => x == "農夫");                
                if (item == "農夫")
                {
                    _leftList.Remove(item);
                    _rightList.Add(item);
                    _listBox3.Add("農夫到右岸");
                    _listBox3.Add("--------------");
                    ChangeData();
                }
                else
                {
                    if (_leftList.Contains("農夫"))
                    {
                        _leftList.Remove(item);
                        _leftList.Remove("農夫");
                        _rightList.Add(item);
                        _rightList.Add("農夫");
                        _listBox3.Add("農夫和" + item + "到右岸");
                        _listBox3.Add("--------------");
                        ChangeData();
                    }
                    else
                    {

                    }
                }
                if (_leftList.Contains("羊") && _leftList.Contains("狼"))
                {
                    MessageBox.Show("羊被狼吃掉了!");
                }
                if (_leftList.Contains("羊") && _leftList.Contains("菜"))
                {
                    MessageBox.Show("菜被羊吃掉了!");
                }
                if (_rightList.Contains("羊") && _rightList.Contains("菜") && _rightList.Contains("狼") && _rightList.Contains("農夫"))
                {
                    MessageBox.Show("成功過河!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string item = (string)listBox2.SelectedItem;
                if (item == "農夫")
                {
                    _rightList.Remove(item);
                    _leftList.Add(item);
                    _listBox3.Add("農夫到左岸");
                    _listBox3.Add("--------------");
                    ChangeData();
                }
                else
                {
                    if (_rightList.Contains("農夫"))
                    {
                        _rightList.Remove(item);
                        _rightList.Remove("農夫");
                        _leftList.Add(item);
                        _leftList.Add("農夫");
                        _listBox3.Add("農夫和" + item + "到左岸");
                        _listBox3.Add("--------------");
                        ChangeData();
                    }
                    else
                    {

                    }
                }
                if (_rightList.Contains("羊") && _rightList.Contains("狼"))
                {
                    MessageBox.Show("羊被狼吃掉了!");
                }
                if (_rightList.Contains("羊") && _rightList.Contains("菜"))
                {
                    MessageBox.Show("菜被羊吃掉了!");
                }
                if (_rightList.Contains("羊") && _rightList.Contains("菜") && _rightList.Contains("狼") && _rightList.Contains("農夫"))
                {
                    MessageBox.Show("成功過河!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
            ChangeData();
        }
    }
}
