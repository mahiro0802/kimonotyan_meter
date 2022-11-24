using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kimonoちゃんストレスメーター
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ロード時に前回設定したフォントを読み込む
            label2.Font = Properties.Settings.Default.font;
        }

        private void フォント変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                //フォント変更
                label2.Font = fontDialog1.Font;
                //設定ファイルの変更・保存
                Properties.Settings.Default.font = fontDialog1.Font;
                Properties.Settings.Default.Save();
            }
        }

        
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //押されたキーがスペースキーか調べる
            if(e.KeyCode == Keys.Space)
            {
                //新しい数値
                int new_score = int.Parse(label2.Text) + 1;
                //新しい数値をテキストにセットする
                label2.Text = new_score.ToString();

                //文字色の変更処理
                
                //旧式
                /*if(new_score >= 50)
                {
                    if (new_score >= 100)
                    {
                        label2.ForeColor = Color.Red;
                    }
                    else
                    {
                        label2.ForeColor = Color.DarkOrange;
                    }

                }*/

                //新式、初めてのswitch式
                switch (new_score)
                {
                    case 50:
                        label2.ForeColor = Color.DarkOrange;
                        break;
                    case 100:
                        label2.ForeColor = Color.Red;
                        break;
                }
                
                //プログレスバーのvalueが100を超えないようにする
                if (progressBar1.Value != 100)
                {
                    //プログレスバーの数字にプラス1する
                    progressBar1.Value = progressBar1.Value + 1;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //終了時にダイアログの作成
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログ内でキャンセルされた場合終了処理をキャンセル
            if(dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void リセットToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //すべてをリセット
            label2.Text = "0";
            label2.ForeColor = Color.Black;
            progressBar1.Value = 0;
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //終了
            this.Close();
        }
    }
}
