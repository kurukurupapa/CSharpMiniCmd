using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace MiniExcel
{
    class ExcelService
    {
        public string fileExt = ".txt";
        public string separator = ",";
        public string newLine = "\r\n";
        public bool fileNameOutputFlag = false;
        public bool sheetNameOutputFlag = false;
        public bool lineNoOutputFlag = false;
        public bool completeMsgFlag = false;

        public void OutputTextFile(string[] pathArr)
        {
            string msg = "";

            foreach (string path in pathArr)
            {
                try
                {
                    OutputTextFile(path);
                }
                catch (Exception ex)
                {
                    // 1件ごとにエラーを表示し、正常処理に復帰する。
                    MessageBox.Show(ex.Message, Properties.Settings.Default.AppName);
                }

                msg += path + newLine;
            }

            // 完了メッセージを表示する
            if (completeMsgFlag)
            {
                MessageBox.Show("テキストファイルへの変換が完了しました。\r\n" + msg,
                    Properties.Settings.Default.AppName);
            }
        }

        public void OutputTextFile(string src)
        {
            string dest = src + fileExt;

            // Excelファイルの内容を読み込む
            string text = ReadExcelFile(src);

            // テキストファイルへ出力する
            using (StreamWriter writer = new StreamWriter(dest))
            {
                writer.Write(text);
            }

            Console.WriteLine("Service.OutputTextFile: src=[" + src + "]");
            Console.WriteLine("Service.OutputTextFile: dest=[" + dest + "]");
        }

        /// <summary>
        /// Excelのバージョンを取得する
        /// </summary>
        /// <returns>Excelバージョン文字列</returns>
        private string GetExcelVersion()
        {
            Type classType = Type.GetTypeFromProgID("Excel.Application");
            object app = Activator.CreateInstance(classType);

            object version = app.GetType().InvokeMember(
                "Version", BindingFlags.GetProperty, null, app, null);
            return version.ToString();
        }

        /// <summary>
        /// Excelファイルを読み込む
        /// </summary>
        /// <param name="path">Excelファイルパス</param>
        private string ReadExcelFile(string path)
        {
            string result = "";
            object app = null;

            try
            {
                object[] args = null;

                // Excelアプリケーションを起動する
                Type classType = Type.GetTypeFromProgID("Excel.Application");
                app = Activator.CreateInstance(classType);

                // Excelファイルを開く
                object books = app.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, app, null);
                args = new object[15];
                args[0] = path;
                for (int i = 1; i < 15; i++)
                {
                    args[i] = Type.Missing;
                }
                object book = books.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, books, args);
                if (fileNameOutputFlag)
                {
                    result = "FilePath: " + path + newLine;
                }

                // ファイル内容を読み込む
                object sheets = book.GetType().InvokeMember("Sheets", BindingFlags.GetProperty, null, book, null);
                object sheetCount = sheets.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, sheets, null);
                Console.WriteLine("sheetCount=[" + sheetCount + "]");
                foreach (object sheet in (IEnumerable)sheets)
                {
                    result += GetSheetContent(sheet);
                }
            }
            finally
            {
                if (app != null)
                {
                    app.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, app, null);
                }
            }

            return result;
        }

        private string GetSheetContent(object sheet)
        {
            string result = "";
            object[] args = null;

            // シート名を取得する
            object sheetName = sheet.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, sheet, null);
            if (sheetNameOutputFlag)
            {
                result += "SheetName: " + sheetName + newLine;
            }
            Console.WriteLine("sheetName=[" + sheetName + "]");

            // 最終行、最終列を取得する
            // Excelを編集中の場合、正しい値を読み込めない場合がある。
            object cells = sheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, sheet, null);
            args = new object[2];
            args[0] = 11; //xlCellTypeLastCell
            args[1] = Type.Missing;
            object lastCell = cells.GetType().InvokeMember("SpecialCells", BindingFlags.InvokeMethod, null, cells, args);
            int maxRow = (int)lastCell.GetType().InvokeMember("Row", BindingFlags.GetProperty, null, lastCell, null);
            int maxColumn = (int)lastCell.GetType().InvokeMember("Column", BindingFlags.GetProperty, null, lastCell, null);

            Console.WriteLine("最終行=[" + maxRow + "]");
            Console.WriteLine("最終列=[" + maxColumn + "]");

            // シートの内容をCSV形式で文字列化する。
            for (int row = 1; row <= maxRow; row++)
            {
                string line = "";
                for (int column = 1; column <= maxColumn; column++)
                {
                    // セルのインデックスは、1始まり。
                    args = new object[2];
                    args[0] = row;
                    args[1] = column;
                    object cell = cells.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, cells, args);

                    if (column > 1)
                    {
                        line += separator;
                    }
                    object text = cell.GetType().InvokeMember("Text", BindingFlags.GetProperty, null, cell, null);
                    line += text.ToString();
                }

                Console.WriteLine(row + ": [" + line + "]");
                if (lineNoOutputFlag)
                {
                    result += row + separator;
                }
                result += line + newLine;
            }

            return result;
        }
    }
}
