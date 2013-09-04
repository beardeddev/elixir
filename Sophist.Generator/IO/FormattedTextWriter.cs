using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Generator.IO
{
    public class FormattedTextWriter
    {
        private StringBuilder _output = new StringBuilder();
        private int _tablevel = 0;

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
            for (int index = 0; index < this._tablevel; ++index)
                this._output.Append("\t");
            this._output.Append(text);
        }

        public void WriteLine()
        {
            this._output.Append(Environment.NewLine);
        }

        public void WriteLine(string text)
        {
            this.Write(text);
            this._output.Append(Environment.NewLine);
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
    }
}
