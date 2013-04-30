
namespace MiniUtilsTest
{
    public class DummyClass
    {
        private int mPrivateInt;
        private string mPrivateString;

        protected int mProtectedInt;
        protected string mProtectedString;

        public int mPublicInt;
        public string mPublicString;

        private DummyClass mSub;

        public DummyClass()
        {
            mSub = null;
        }

        public DummyClass(DummyClass sub)
        {
            mSub = sub;
        }
    }
}
