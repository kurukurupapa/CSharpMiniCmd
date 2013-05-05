using MiniLauncher.Model;
using System.Collections.Generic;

namespace MiniLauncher
{
    public class CmdLogic
    {
        private List<Cmd> cmdList = new List<Cmd>();
        private FileDao fileDao = new FileDao();
        private DbDao dbDao = new DbDao();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CmdLogic()
        {
            // 処理なし
        }

        /// <summary>
        /// コマンドリストを取得する。
        /// </summary>
        /// <returns></returns>
        public List<Cmd> FindAll()
        {
            return cmdList;
        }

        /// <summary>
        /// コマンドリストを抽出する。
        /// </summary>
        /// <param name="keyword">キーワード</param>
        /// <returns></returns>
        public List<Cmd> Find(string keyword)
        {
            // キーワードが空の場合、全コマンドリストを返却する。
            if (string.IsNullOrEmpty(keyword))
            {
                return FindAll();
            }

            List<Cmd> list = new List<Cmd>();

            // キーワードをディレクトリパスと見なしてファイルを検索する。
            list.AddRange(fileDao.GetFileCmdList(keyword));

            // コマンドリストからキーワードに該当するコマンドを抽出する。
            keyword = keyword.ToUpper();
            foreach (Cmd cmd in cmdList)
            {
                if (cmd.name.ToUpper().Contains(keyword))
                {
                    list.Add(cmd);
                }
            }

            return list;
        }

        /// <summary>
        /// リストを更新する。
        /// </summary>
        public void Update()
        {
            cmdList.Clear();
            cmdList.AddRange(dbDao.GetDbList());
            cmdList.AddRange(fileDao.GetPathEnvList());
            cmdList.AddRange(fileDao.GetMiniCmdList());
            cmdList.AddRange(GetAppList());
        }

        private List<Cmd> GetAppList()
        {
            List<Cmd> list = new List<Cmd>();

            Cmd cmd = new SettingCmd();
            cmd.name = "Setting";
            //cmd.type = Cmd.CommandType.Setting;
            list.Add(cmd);

            return list;
        }

        public void RunWithCmd(Cmd cmd)
        {
            if (!Contains(cmdList, cmd.name))
            {
                cmdList.Add(cmd);
                dbDao.InsertCmd(cmd);
            }
            cmd.Start();
        }

        private bool Contains(List<Cmd> cmdList, string name)
        {
            bool result = false;

            foreach (Cmd cmd in cmdList)
            {
                if (cmd.name.Equals(name))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
