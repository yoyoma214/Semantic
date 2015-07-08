using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common
{
    public class NStringBuilder
    {
        StringBuilder _StringBuilder0 = null;
        IndexManage _IndexMange0 = new IndexManage();
        public StringBuilder StringBuilder0
        {
            get { return _StringBuilder0; }
            //set { _StringBuilder0 = value; }
        }

        public NStringBuilder(StringBuilder sb)
        {
            _StringBuilder0 = sb;
        }
        public NStringBuilder(String s)
            : this(new StringBuilder(s))
        {

        }
        public void Insert(int startIndex, String newString)
        {
            int index = _IndexMange0.GetNewIndex(startIndex);
            this.StringBuilder0.Insert(index, newString);
            _IndexMange0.Insert(startIndex, newString.Length);
        }

        public void Update(int startIndex, int endIndex, String newString)
        {
            int index = _IndexMange0.GetNewIndex(startIndex);
            this.StringBuilder0.Remove(index, endIndex - startIndex + 1);
            this.StringBuilder0.Insert(index, newString);
            _IndexMange0.Update(startIndex, endIndex, newString.Length);

        }
        public int GetNewIndex(int index)
        {
            return this._IndexMange0.GetNewIndex(index);
        }
        public string GetString(int startIndex, int endIndex)
        {
            String ret = null;
            int index = _IndexMange0.GetNewIndex(startIndex);
            int stop = _IndexMange0.GetNewIndex(endIndex);
            ret = this.StringBuilder0.ToString().Substring(index, stop - index + 1);
            return ret;
        }
        public class Index
        {
            public int OldIndex;
            public int Offset;
        }

        public class IndexCompare : IComparer<Index>
        {
            #region IComparer<Index> 成员

            public int Compare(Index x, Index y)
            {
                if (x.OldIndex > y.OldIndex)
                    return 1;
                if (x.OldIndex == y.OldIndex)
                    return 0;
                if (x.OldIndex < y.OldIndex)
                    return -1;
                throw new Exception("Compare");
            }

            #endregion
        }
        internal class IndexManage
        {
            List<Index> _ListIndex = new List<Index>();
            public int GetNewIndex(int index)
            {
                int newIndex = index;
                //Index i = this.GetIndex(index);
                //if (i == null)
                //    i = this.GetPrevIndex(index);
                //if (i != null)
                //{
                foreach (Index i2 in _ListIndex)
                {
                    if (i2.OldIndex > index)
                    {
                        break;
                    }

                    newIndex += i2.Offset;
                }
                //}
                return newIndex;
            }

            public Index GetPrevIndex(int index)
            {
                //Index i = null;
                Index prev = null;
                foreach (Index i2 in _ListIndex)
                {
                    if (i2.OldIndex > index)
                    {
                        //i = i2;
                        break;
                    }
                    prev = i2;
                }
                return prev;
            }

            public Index GetIndex(int index)
            {

                foreach (Index i2 in _ListIndex)
                {
                    if (i2.OldIndex == index)
                    {
                        return i2;
                    }

                }
                return null;
            }

            public void Insert(int startIndex, int length)
            {
                Index index = this.GetIndex(startIndex);
                if (index == null)
                {
                    index = new Index();
                    index.OldIndex = startIndex;
                    index.Offset = length;
                    _ListIndex.Add(index);
                }
                else
                {
                    index.Offset += length;
                }
                _ListIndex.Sort(new IndexCompare());
            }

            public void Update(int startIndex, int endIndex, int length)
            {
                Index index = this.GetIndex(startIndex);
                if (index == null)
                {
                    index = new Index();
                    index.OldIndex = endIndex;
                    index.Offset = length - (endIndex - startIndex + 1);
                    _ListIndex.Add(index);
                }
                else
                {
                    index.Offset += length - (endIndex - startIndex + 1);
                }
                _ListIndex.Sort(new IndexCompare());

            }


        }               
    }
}
