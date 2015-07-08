using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CodeHelper.Core.Parse
{
    public class StackUtil
    {

        Stack stack = new Stack();

        public T PeekCtx<T>()
        {
            if (this.stack.Count == 0)
                return default(T);

            try
            {
                T t = (T)this.stack.Peek();
                if (!(t is T))
                {
                    return default(T);
                }
                return t;
            }
            catch (Exception e)
            {
                return default(T);
            }

        }

        public void Push(Object obj)
        {
            this.stack.Push(obj);
        }

        public void Pop()
        {
            this.stack.Pop();
        }

        public Object Peek()
        {
            return this.stack.Peek();
        }

        public Object PeekPrev()
        {
            int count = this.stack.Count;
            if (count > 1)
            {
                return this.stack.ToArray()[count - 2];
            }
            return null;
        }
    }

}
