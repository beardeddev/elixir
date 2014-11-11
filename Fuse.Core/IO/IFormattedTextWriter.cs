using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.Common
{
    public interface IFormattedTextWriter
    {
        void Clear();
        void DecTab();
        void IncTab();
        int Length { get; }
        void Remove(int startIndex, int length);
        int TabLevel { get; set; }
        string ToString();
        void Write(string format, params object[] args);
        void Write(string text);
        void WriteLine();
        void WriteLine(string format, params object[] args);
        void WriteLine(string text);
    }
}
