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

            //A mix of method modifiers to demonstrate lack of false positives.
            var fakeObjectMixed = A.Fake<MixedMessageSender>();

            //A non-virtual object - highlight, real code will be ran!
            var fakeObjectNonVirtual = A.Fake<NonVirtualMessageSender>();

            Gym gym = new Gym(fakeObjectNonVirtual);
            gym.Excerise();

        }
    }
}
