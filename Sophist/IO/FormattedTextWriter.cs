using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.IO
{
    public class FormattedTextWriter : Sophist.IO.IFormattedTextWriter
    {
        private StringBuilder _output = new StringBuilder();
        private int _tablevel = 0;

        private void WriteTabs()
        {
            for (int index = 0; index < this._tablevel; ++index)
                this._output.Append("\t");
        }

        public int TabLevel
        {
            get
            {
                return this._tablevel;
            }
            set
            {
                this._tablevel = value;
            }
        }

        public void Write(string text)
        {
            this.WriteTabs();
            this._output.Append(text);
        }

        public void Write(string format, params object[] args)
        {
            this.WriteTabs();
            this._output.AppendFormat(format, args);
        }

        public void WriteLine(string format, params object[] args)
        {
            this.Write(format, args);
            this._output.AppendLine();
        }

        public void WriteLine()
        {
            this._output.AppendLine();
        }

        public void WriteLine(string text)
        {
            this.Write(text);
            this._output.AppendLine();
        }

        public void IncTab()
        {
            ++this._tablevel;
        }

        public void DecTab()
        {
            --this._tablevel;
        }

        public void Clear()
        {
            this._output.Clear();
        }

        public override string ToString()
        {
            return this._output.ToString();
        }

        public void Remove(int startIndex, int length)
        {
            this._output.Remove(startIndex, length);
        }

        public int Length
        {
            get
            {
                return this._output.Length;
            }
        }
    }
}
