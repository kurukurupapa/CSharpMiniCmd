using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MiniUtils
{
    /// <summary>
    /// 階層化されたオブジェクトのあるフィールドを表すクラス
    /// </summary>
    internal class NestObject
    {
        private const int NEST_MAX = 10;

        private object mTarget;
        private FieldInfo mFieldInfo;
        private object mFieldParent;
        private int mNest;

        public FieldInfo FieldInfo
        {
            get { return mFieldInfo; }
        }

        public object FieldParent
        {
            get { return mFieldParent; }
        }

        public NestObject(object target)
        {
            mTarget = target;
        }

        public void SetField(string field)
        {
            mFieldInfo = null;
            mFieldParent = null;
            SetFieldByNestedField(field, mTarget);
            Console.WriteLine("SetField field=" + field + ", mFieldInfo=" + mFieldInfo + ", mFieldParent=" + mFieldParent);
        }

        private void SetFieldByNestedField(string hierarchy, object target)
        {
            Console.WriteLine("Called SetFieldByNestedField, hierarchy=" + hierarchy + ", target.GetType().Name=" + target.GetType().Name);

            NestName names = new NestName(hierarchy);
            if (names.IsNextNames() == false)
            {
                // 上位層なしのフィールド名の場合
                SetFieldOrThrow(names.FirstName, target);
            }
            else
            {
                if (names.IsFreeParent())
                {
                    // 任意のひとつの階層が指定された場合

                    SetFieldByFreeParent(names.NextNames, target);
                }
                else if (names.IsFreeHierarchy())
                {
                    // 任意の複数の上位階層が指定された場合

                    string tmpNames = names.NextNames;
                    for (int i = 0; i < NEST_MAX; i++)
                    {
                        // 一時的な名前でSetFieldByNestedField()を呼び出してみる。
                        // フィールドが見つからない場合、ひとつ階層を掘り下げた名前にしてみる。
                        if (TryFieldByNestedField(tmpNames, target))
                        {
                            return;
                        }
                        else
                        {
                            tmpNames = "*." + tmpNames;
                        }
                    }
                    throw new ApplicationException("フィールドが見つかりませんでした。hierarchy=" + hierarchy);
                }
                else
                {
                    // 特定の階層が指定された場合

                    object obj = GetObjectOrThrow(names.FirstName, target);
                    SetFieldByNestedField(names.NextNames, obj);
                }
            }
        }

        private bool TryFieldByNestedField(string hierarchy, object target)
        {
            try
            {
                SetFieldByNestedField(hierarchy, target);
            }
            catch
            {
                return false;
            }
            return true;
        }


        private void SetFieldOrThrow(string field, object target)
        {
            Console.WriteLine("Called SetFieldOrThrow, field=" + field + ", target.GetType().Name=" + target.GetType().Name);

            mFieldInfo = target.GetType().GetField(field,
                BindingFlags.GetField | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            mFieldParent = target;

            if (mFieldInfo == null)
            {
                throw new ApplicationException("フィールドが見つかりませんでした。field=" + field);
            }
        }

        private void SetFieldByFreeParent(string nextNames, object target)
        {
            Console.WriteLine("Called SetFieldByFreeParent, nextNames=" + nextNames + ", target.GetType().Name=" + target.GetType().Name);

            FieldInfo[] fieldInfoArr = target.GetType().GetFields(
                BindingFlags.GetField | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo fieldInfo in fieldInfoArr)
            {
                Console.WriteLine("fieldInfo.Name=" + fieldInfo.Name);

                // 一時的な名前でSetFieldByNestedField()を呼び出していみる。
                object obj = fieldInfo.GetValue(target);
                if (TryFieldByNestedField(nextNames, obj))
                {
                    return;
                }
            }

            throw new ApplicationException("フィールドが見つかりませんでした。nextNames=" + nextNames);
        }

        /// <summary>
        /// 指定されたオブジェクトを取得する。
        /// </summary>
        /// <param name="hierarchy">フィールド名（ピリオド区切りで階層を指定可能）</param>
        /// <returns>オブジェクト</returns>
        public object GetObject(string hierarchy)
        {
            mNest = 0;
            return GetObjectByNestedField(hierarchy, mTarget);
        }

        private object GetObjectOrThrow(string field, object target)
        {
            FieldInfo fieldInfo = target.GetType().GetField(field,
                BindingFlags.GetField | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return fieldInfo.GetValue(target);
        }

        private object GetObjectByNestedField(string hierarchy, object target)
        {
            Console.WriteLine("Called GetObjectByNestedField, hierarchy=" + hierarchy + ", target.GetType().Name=" + target.GetType().Name);

            if (mNest >= NEST_MAX)
            {
                return null;
            }
            mNest++;

            NestName names = new NestName(hierarchy);
            if (names.IsNextNames() == false)
            {
                return GetObjectOrThrow(names.FirstName, target);
            }
            else
            {
                if (names.IsFreeParent())
                {
                    return GetNextObjectByFreeParent(names.NextNames, target);
                }
                else if (names.IsFreeHierarchy())
                {
                    return GetNextObjectByFreeHierarchy(names.NextNames, target);
                }
                else
                {
                    object obj = GetObjectOrThrow(names.FirstName, target);
                    return GetObjectByNestedField(names.NextNames, obj);
                }
            }
        }

        private object GetNextObjectByFreeParent(string nextNames, object target)
        {
            FieldInfo[] fieldInfoArr = target.GetType().GetFields(
                BindingFlags.GetField | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo fieldInfo in fieldInfoArr)
            {
                Console.WriteLine("fieldInfo.Name=" + fieldInfo.Name);
                try
                {
                    object obj = GetObjectByNestedField(nextNames, fieldInfo);
                    if (obj != null)
                    {
                        return obj;
                    }
                }
                catch { }
            }

            return null;
        }

        private object GetNextObjectByFreeHierarchy(string nextNames, object target)
        {
            Console.WriteLine("Called GetNextObjectByFreeHierarchy, nextNames=" + nextNames);

            FieldInfo[] fieldInfoArr = target.GetType().GetFields(
                BindingFlags.GetField | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            // 当該階層に指定フィールドが存在するか調べる
            foreach (FieldInfo fieldInfo in fieldInfoArr)
            {
                Console.WriteLine("fieldInfo.Name=" + fieldInfo.Name);
                if (fieldInfo.Name.Equals(nextNames))
                {
                    return fieldInfo.GetValue(target);
                }
            }

            // 下の階層に指定フィールドが存在するか調べる
            foreach (FieldInfo fieldInfo in fieldInfoArr)
            {
                Console.WriteLine("fieldInfo.Name=" + fieldInfo.Name);
                try
                {
                    object obj = GetObjectByNestedField(nextNames, fieldInfo);
                    if (obj != null)
                    {
                        return obj;
                    }
                }
                catch { }
            }

            return null;
        }
    }
}
