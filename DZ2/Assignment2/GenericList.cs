using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int last;


        public GenericList()
        {
            _internalStorage = new X[4];
            last = -1;
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 1)
            {
                throw new ArgumentException("Argument mora biti veći od 0!");
            }
            else
            {
                _internalStorage = new X[initialSize];
                last = -1;
            }

        }

        public void Add(X item)
        {
            int length = _internalStorage.Length;
            if (length == Count)
            {
                X[] pom = new X[length * 2];
                Array.Copy(_internalStorage, pom, length);
                _internalStorage = pom;

            }
            last++;
            _internalStorage[last] = item;
        }

        public bool RemoveAt(int index)
        {
            //int lastIndex = _internalStorage.Length - 1;
            if (index > Count)
            {
                //throw new IndexOutOfRangeException();
                return false;
            }
            else
            {
                for (int i = index; i < Count; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                last--;
                return true;
            }
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index < Count)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public int Count => last + 1;


        public void Clear()
        {
            int length = _internalStorage.Length;
            _internalStorage = new X[length];
            last = -1;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }

            }
            return false;
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        // IEnumerable <X> implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}