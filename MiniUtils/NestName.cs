using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniUtils
{
    /// <summary>
    /// ピリオド区切りの名前（フィールド名）を扱うクラス
    /// </summary>
    internal class NestName
    {
        private string mFirstName;
        private string mNextNames;
        private string mUpperNames;
        private string mLastName;

        /// <summary>
        /// ピリオド区切り文字列における始めの名前
        /// </summary>
        public string FirstName
        {
            get { return mFirstName; }
        }

        /// <summary>
        /// ピリオド区切り文字列における2個め以降の名前
        /// </summary>
        public string NextNames
        {
            get { return mNextNames; }
        }

        /// <summary>
        /// ピリオド区切り文字列における最後の名前
        /// </summary>
        public string LastName
        {
            get { return mLastName; }
        }

        /// <summary>
        /// ピリオド区切り文字列における始めから最後の一つ前の名前
        /// </summary>
        public string UpperNames
        {
            get { return mUpperNames; }
        }

        public NestName(string names)
        {
            SetFirstAndNextNames(names);
            SetUpperAndLastNames(names);
        }

        private void SetFirstAndNextNames(string names)
        {
            string[] nameArr = names.Split(new char[] { '.' }, 2);
            mFirstName = nameArr[0];
            if (nameArr.Length >= 2)
            {
                mNextNames = nameArr[1];
            }
        }

        public bool IsNextNames()
        {
            return mNextNames != null;
        }

        public bool IsFreeParent()
        {
            return "*".Equals(mFirstName);
        }

        public bool IsFreeHierarchy()
        {
            return "**".Equals(mFirstName);
        }

        private void SetUpperAndLastNames(string names)
        {
            int index = names.LastIndexOf('.');
            if (index < 0)
            {
                mUpperNames = null;
                mLastName = names;
            }
            else
            {
                mUpperNames = names.Substring(0, index);
                mLastName = names.Substring(index + 1);
            }
        }
    }
}
