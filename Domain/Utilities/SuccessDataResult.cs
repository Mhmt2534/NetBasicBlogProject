using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data,string message) : base(data, true,message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(string message) : base(default, true,message) //default, eğer veri göndeirlmezse null, 0 falan girer.
        {
        }

        public SuccessDataResult() : base(default, true)
        {
        }


    }
}
