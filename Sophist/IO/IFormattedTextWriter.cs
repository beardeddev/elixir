using System;
namespace Sophist.IO
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
