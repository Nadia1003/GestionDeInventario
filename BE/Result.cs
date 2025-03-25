using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Result<T>
    {
        //privado para evitar nuevas instancias y usar metodos estaticos
        private Result()
        {

        }

        public bool Ok { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static Result<T> Success(T data, string message = null)
        {
            return new Result<T> { Ok = true, Message = message, Data = data };
        }

        public static Result<T> Error(string message, T data)
        {
            return new Result<T> { Ok = false, Message = message, Data = data };
        }
    }
}
