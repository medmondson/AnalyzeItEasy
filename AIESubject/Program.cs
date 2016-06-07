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

            //A virtual object - no code hints here
            var fakeObjectVirtual = A.Fake<VirtualMessageSender>();

            //A non-virtual object - highlight, real code will be ran!
            var fakeObjectNonVirtual = A.Fake<NonVirtualMessageSender>();

            Gym gym = new Gym(fakeObjectNonVirtual);
            gym.Excerise();

        }
    }
}
