
namespace MiniLauncher.Model
{
    class SettingCmd : Cmd
    {
        public override void Start()
        {
            SettingForm form = new SettingForm();
            form.ShowDialog();
        }

    }
}
