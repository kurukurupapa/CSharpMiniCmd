using NUnit.Framework;
using MiniBackup;
using MiniUtils;
using System;
using System.Windows.Forms;

namespace MiniBackTest
{
    public class MainFormTest
    {
        private MainForm mForm;
        private ReflectionHelper<MainForm> mHelper;

        [SetUp]
        public void SetUp()
        {
            mForm = new MainForm();
            mForm.Show();
            mHelper = new ReflectionHelper<MainForm>(mForm);

            Console.WriteLine("Application.StartupPath=" + Application.StartupPath);
        }

        [TearDown]
        public void TearDown()
        {
            mForm.Close();
        }

        [Test, RequiresSTAAttribute]
        public void TestDummy()
        {
            Assert.NotNull(mForm);
        }

        [Test, RequiresSTAAttribute]
        public void TestMainForm_BtnCancel_Click_001()
        {
            mHelper.InvokeMethod("btnCancel_Click", new object[] { null, null});
        }

        [Test, RequiresSTAAttribute]
        public void TestMainForm_BtnOk_Click_001()
        {
            mHelper.InvokeMethod("btnOk_Click", new object[] { null, null });
        }

    }
}
