using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common
{
    public class IndentStringBuilder
    {
        private StringBuilder builder = new StringBuilder();
        private bool newLine = true;
        public int IndentCount { get;private set; }
        public int LineCount
        {
            get
            {
                return this.builder.ToString().Where(x => x == '\n').Count();
            }
        }

        public int Increase()
        {
            this.IndentCount++;
            return this.IndentCount;
        }
        public int Increase(string val)
        {
            OnNewLine(this.builder);
            this.builder.Append(val);
            this.IndentCount++;            
            return this.IndentCount;
        }
        public int Decrease()
        {
            this.IndentCount--;
            return this.IndentCount;
        }
        public int Decrease(string val)
        {
            this.IndentCount--;
            OnNewLine(this.builder);
            this.builder.Append(val);            
            return this.IndentCount;
        }

        public IndentStringBuilder()
        {
            IndentCount = 0;
        }

        public IndentStringBuilder(int indent):this()
        {
            this.IndentCount = indent;
        }        

        public void Append(string value)
        {
            OnNewLine(this.builder);
            builder.Append(value);
        }

        public void AppendLine()
        {
            this.builder.AppendLine();
            newLine = true;
        }

        public void AppendLine(string value)
        {
            OnNewLine(this.builder).AppendLine(value);
            newLine = true;
        }

        public void IncreaseIndentLine()
        {
            OnNewLine(this.builder).AppendLine();
            IndentCount++;
            newLine = true;
        }

        public void IncreaseIndentLine(string value)
        {
            OnNewLine(this.builder).AppendLine(value);
            IndentCount++;
            newLine = true;
        }

        public void IncreaseIndentFormatLine(string format, params object[] args)
        {            
            OnNewLine(this.builder).AppendFormat(format, args).AppendLine();
            IndentCount++;
            newLine = true;
        }

        public void DecreaseIndentLine()
        {
            IndentCount--;
            OnNewLine(this.builder).AppendLine();
            newLine = true;
        }

        public void DecreaseIndentLine(string value)
        {
            IndentCount--;
            OnNewLine(this.builder).AppendLine(value);
            newLine = true;
        }

        public void AppendFormat(string format, params object[] args)
        {
            OnNewLine(this.builder).AppendFormat(format, args);
        }

        public void IncreaseIndentFormat(string format, params object[] args)
        {            
            OnNewLine(this.builder).AppendFormat(format, args);
            IndentCount++;
        }

        public void DecreaseIndentFormat(string format, params object[] args)
        {
            IndentCount--;
            OnNewLine(this.builder).AppendFormat(format, args);
        }

        public void DecreaseIndentFormatLine(string format, params object[] args)
        {
            IndentCount--;
            OnNewLine(this.builder).AppendFormat(format, args).AppendLine();
            newLine = true;
        }

        public void AppendFormatLine(string format, params object[] args)
        {
            OnNewLine(this.builder).AppendFormat(format, args).AppendLine();
            newLine = true;
        }

        public override string ToString()
        {
            return this.builder.ToString();
        }

        private StringBuilder OnNewLine(StringBuilder builder)
        {
            if (this.newLine)
                builder.Append('\t', IndentCount);

            this.newLine = false;
            return builder;
        }

        public int Length
        {
            get
            { return this.builder.Length; }
        }

        public void Clear()
        {
            this.builder.Clear();
        }
    }
}
