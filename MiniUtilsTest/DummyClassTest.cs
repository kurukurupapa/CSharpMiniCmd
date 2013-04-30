using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MiniUtils;

namespace MiniUtilsTest
{
    public class DummyClassTest
    {
        [Test]
        public void TestConstructor()
        {
            ReflectionHelper<DummyClass> helper = new ReflectionHelper<DummyClass>(new DummyClass());
        }

        [Test]
        public void TestGetField()
        {
            ReflectionHelper<DummyClass> helper = helper = new ReflectionHelper<DummyClass>(
                new DummyClass(new DummyClass(new DummyClass())));

            Assert.AreEqual(0, (int)helper.GetFieldValue("mPrivateInt"));
            Assert.AreEqual(null, (string)helper.GetFieldValue("mPrivateString"));

            Assert.AreEqual(0, (int)helper.GetFieldValue("mProtectedInt"));
            Assert.AreEqual(null, (string)helper.GetFieldValue("mProtectedString"));

            Assert.AreEqual(0, (int)helper.GetFieldValue("mPublicInt"));
            Assert.AreEqual(null, (string)helper.GetFieldValue("mPublicString"));

            Assert.AreEqual(null, (string)helper.GetFieldValue("mSub.mPrivateString"));
            Assert.AreEqual(null, (string)helper.GetFieldValue("mSub.mSub.mPrivateString"));

            Assert.AreEqual(null, (string)helper.GetFieldValue("*.mPrivateString"));
            Assert.AreEqual(null, (string)helper.GetFieldValue("*.*.mPrivateString"));

            Assert.AreEqual(null, (string)helper.GetFieldValue("**.mPrivateString"));
            Assert.AreEqual(null, (string)helper.GetFieldValue("**.mSub.**.mPrivateString"));
        }

        [Test]
        public void TestSetField()
        {
            ReflectionHelper<DummyClass> helper = helper = new ReflectionHelper<DummyClass>(
                new DummyClass(new DummyClass(new DummyClass())));

            helper.SetField("mPrivateInt", 123);
            helper.SetField("mPrivateString", "abc");
            Assert.AreEqual(123, (int)helper.GetFieldValue("mPrivateInt"));
            Assert.AreEqual("abc", (string)helper.GetFieldValue("mPrivateString"));

            helper.SetField("mProtectedInt", 123);
            helper.SetField("mProtectedString", "abc");
            Assert.AreEqual(123, (int)helper.GetFieldValue("mProtectedInt"));
            Assert.AreEqual("abc", (string)helper.GetFieldValue("mProtectedString"));

            helper.SetField("mPublicInt", 123);
            helper.SetField("mPublicString", "abc");
            Assert.AreEqual(123, (int)helper.GetFieldValue("mPublicInt"));
            Assert.AreEqual("abc", (string)helper.GetFieldValue("mPublicString"));

            helper.SetField("mSub.mPrivateString", "aaa1");
            helper.SetField("mSub.mSub.mPrivateString", "aaa2");
            Assert.AreEqual("aaa1", (string)helper.GetFieldValue("mSub.mPrivateString"));
            Assert.AreEqual("aaa2", (string)helper.GetFieldValue("mSub.mSub.mPrivateString"));

            helper.SetField("*.mPrivateString", "bbb1");
            helper.SetField("*.*.mPrivateString", "bbb2");
            Assert.AreEqual("bbb1", (string)helper.GetFieldValue("mSub.mPrivateString"));
            Assert.AreEqual("bbb2", (string)helper.GetFieldValue("mSub.mSub.mPrivateString"));

            helper.SetField("**.mPrivateString", "ccc1");
            helper.SetField("**.mSub.**.mPrivateString", "ccc2");
            Assert.AreEqual("ccc1", (string)helper.GetFieldValue("mPrivateString"));
            Assert.AreEqual("ccc2", (string)helper.GetFieldValue("mSub.mPrivateString"));
        }
    }
}
