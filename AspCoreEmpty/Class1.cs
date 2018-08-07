using System;
namespace AspCoreEmpty
{
    public class Fun<T>
    {
        protected T x;
    }
    public class MyFun<T>: Fun<T>
    {
         static void F()
        {
           
            MyFun<T> dt = new MyFun<T>();
            MyFun<int> di = new MyFun<int>();
            MyFun<string> ds = new MyFun<string>();
            dt.x = default(T);
            di.x = 76;
            ds.x = "";
        }
    }
    public class Person
    {
        public int ID;
        public string Name;
        public DateTime DateOfBirth;
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }  

        public string Fun(object o)
        {
            return "object";
        }
        public string Fun(int o)
        {
            return "int";
        }
        public string Fun(double o)
        {
            return "double";
        }
        public string Fun()
        {
            return "";
        }
    }
}
