using System.Reflection;
using System;

namespace MiniUtils
{
    /// <summary>
    /// リフレクションを少し簡単にするクラス
    /// </summary>
    public class ReflectionHelper<TargetClass>
    {
        private TargetClass mTarget;
        private NestObject mNestObject;

        /// <summary>
        /// リフレクション対象のオブジェクト
        /// </summary>
        public TargetClass Target
        {
            get { return mTarget; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="target">リフレクション対象のオブジェクト</param>
        public ReflectionHelper(TargetClass target)
        {
            mTarget = target;
            mNestObject = new NestObject(target);
        }

        /// <summary>
        /// 指定されたメソッドを実行します。
        /// メソッドは、staticメソッドでも、インスタンスメソッドでも、公開/非公開でも実行可能です。
        /// </summary>
        /// <param name="method">対象メソッドの名前</param>
        /// <param name="args">対象メソッドに渡す引数</param>
        /// <returns>対象メソッドの戻り値</returns>
        public object InvokeMethod(string method, object[] args)
        {
            return mTarget.GetType().InvokeMember(
                method,
                BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, mTarget, args);
        }

        /// <summary>
        /// 指定されたフィールドの値を取得する。
        /// </summary>
        /// <param name="field">フィールド名（ピリオド区切りで階層を指定可能）</param>
        /// <returns>フィールドの値</returns>
        public object GetFieldValue(string field)
        {
            NestObject nestObject = new NestObject(mTarget);
            nestObject.SetField(field);
            return nestObject.FieldInfo.GetValue(nestObject.FieldParent);
        }

        /// <summary>
        /// 指定されたフィールドに値を設定する。
        /// </summary>
        /// <param name="field">フィールド名（ピリオド区切りで階層を指定可能）</param>
        /// <param name="value">設定値</param>
        public void SetField(string field, object value)
        {
            NestObject nestObject = new NestObject(mTarget);
            nestObject.SetField(field);
            nestObject.FieldInfo.SetValue(nestObject.FieldParent, value);
        }

    }
}
