using System;

namespace CircularEnumerator
{
    enum Stuff
    {
        Stuff1,
        Stuff2,
        Stuff3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stuff stuff = Stuff.Stuff1;
            var circularStuff = new CircularEnum<Stuff>(stuff);
        }
    }
}
