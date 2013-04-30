using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniFilePropChanger
{
    class OutLineBuilder
    {
        private StringBuilder sb = new StringBuilder();
        private string separator = ",";

        public void AddColumn(long value)
        {
            AddColumn(Convert.ToString(value));
        }

        public void AddColumn(DateTime value)
        {
            AddColumn(Convert.ToString(value));
        }

        public void AddColumn(string value)
        {
            if (sb.Length > 0)
            {
                sb.Append(separator);
            }
            sb.Append("\"");
            sb.Append(value);
            sb.Append("\"");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
