using System;

namespace HandlerRepository
{
    public interface IHandler<in T> where T : DataBase
    {
        void DoSomething(T data);
    }

    public class HandlerForA : IHandler<DataA>
    {
        public void DoSomething(DataA data)
        {
            Console.WriteLine("HandlerForA");
        }
    }

    public class HandlerForB : IHandler<DataB>
    {
        public void DoSomething(DataB data)
        {
            Console.WriteLine("HandlerForB");
        }
    }
    public class HandlerForC : IHandler<DataC>
    {
        public void DoSomething(DataC data)
        {
            Console.WriteLine("HandlerForC");
        }
    }

}