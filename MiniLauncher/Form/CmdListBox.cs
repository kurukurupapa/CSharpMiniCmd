using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiniLauncher.Form
{
    /// <summary>
    /// コマンド候補を表示するリストボックスです。
    /// </summary>
    internal class CmdListBox : ListBox
    {
        public List<Cmd> CmdList
        {
            set {
                Items.Clear();
                foreach (Cmd cmd in value)
                {
                    Items.Add(cmd);
                }
                SelectedIndex = Items.Count - 1;
            }
        }

        public Cmd SelectedCmd
        {
            get
            {
                return (Cmd)SelectedItem;
            }
        }

        /// <summary>
        /// 一つ上の候補を選択状態にする。
        /// </summary>
        public void Up()
        {
            if (SelectedIndex > 0)
            {
                SelectedIndex--;
            }
        }

        /// <summary>
        /// 一つ下の候補を選択状態にする。
        /// </summary>
        public void Down()
        {
            if (SelectedIndex < Items.Count - 1)
            {
                SelectedIndex++;
            }
        }
    }
}
