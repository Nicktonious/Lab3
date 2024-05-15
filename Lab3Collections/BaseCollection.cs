using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Collections
{
    public abstract class BaseCollection<T>
    {
        protected int _count;

        public int Count => _count;

        //public abstract void Add(T item);

        //public abstract T Remove();

        //public abstract T Peek();

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }

}
