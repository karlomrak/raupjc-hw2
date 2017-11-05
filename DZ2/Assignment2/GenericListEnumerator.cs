using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment2
{
    
    public class GenericListEnumerator<X>:IEnumerator<X>
    {
        private GenericList<X> list;
        private int position = -1;
 

        public GenericListEnumerator(GenericList<X> inputList)
        {
            list = inputList;
        }

        
        public void Dispose()
        {



        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Count - 1);
        }

        public void Reset()
        {
            position = -1;
        }

        public X Current
        {
            get
            {
                try
                {
                    return list.GetElement(position);
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
            

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
    
}