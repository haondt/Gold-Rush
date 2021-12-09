using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldrush
{
    internal class TestFile
    {
        string instance;
        string _instance;
        /// <summary>
        /// Comment
        /// </summary>
        public TestFile()
        {
            #region TEST
#if FLAG
            string s = "foo";
#endif
            #endregion
            // comment
            var instance = new Implementation<string>() as IInterface<string>;
            var instance2 = new Implementation<UnrelatedType>() as IInterface<UnrelatedType>;
            var number = 123.456d;
            var instance3 = instance as Implementation<string>;
            var p = instance3.Property;
            var f = instance3.field;
            instance.Method();
            new UnrelatedType().ExtensionMethod(); // Comment
            this.instance = this._instance;

            Action<string> lambda = (string arg) => { arg.ToString(); };
            Func<string, string> lambda2 = s => s;

            var usedVariable = "string value";
            if (usedVariable == null)
            {
                return;
            }

            using(IDisposable disposable = new UsingConstructor())
            {
                disposable.Dispose();
            }
        }

        [Obsolete("my attr")]
        public void Method()
        {

        }
    }
}

public struct MyStruct
{
    string value { get; set; }
}

public enum MyEnum
{
    Value1,
    Value2
}

public class UsingConstructor : IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public class Implementation<T> : IInterface<T> where T : class
{
    public string Property {get; set;}
    public string field;

    public void Method()
    {
        throw new NotImplementedException();
    }

    public void MethodWithArgs(string arg1, int arg2)
    {
        arg1.ToArray();

    }
}

public class UnrelatedType
{

}

public interface IInterface<T> where T : class
{
   void Method();

}

public static class ExtensionClass
{
    public static void ExtensionMethod(this UnrelatedType unrelatedType)
    {

    }
}
