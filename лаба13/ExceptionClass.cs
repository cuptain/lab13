using System;

namespace лаба13
{
    public class ExceptionClass : ApplicationException
    {
        public ExceptionClass()
        {

        }

        public ExceptionClass(string str) : base(str)
        {

        }

        public override string ToString()
        {
            return Message;
        }
    }
}
