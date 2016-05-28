using AIESubject.Fakeables;
using FakeItEasy;

namespace AIESubject
{
    class Program
    {
        static void Main(string[] args)
        {
            //A basic Interface - no code hints here
            var fakeInterface = A.Fake<IMessageSender>();

            //A non-virtual object - no code hints here
            var fakeObjectNonVirtual = A.Fake<NonVirtualMessageSender>();

            //A virtual object - I expect a code hint
            var fakeObjectVirtual = A.Fake<VirtualMessageSender>();

        }
    }
}
