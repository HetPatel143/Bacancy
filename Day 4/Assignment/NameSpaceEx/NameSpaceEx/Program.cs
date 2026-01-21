using System;
using name1=NameSpace1.NS1;
using name2 = NameSpace2.NS1;
namespace SameName
{
    class Name
    {
        public static void Main(string[] args)
        {
            name1 A1=new name1();
            name2 A2=new name2();

            A1.NSS1();
            A2.NSS1();
        }
    }
    
}