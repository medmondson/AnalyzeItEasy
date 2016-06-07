using AIESubject.Fakeables;

namespace AIESubject
{
    class Gym
    {
        private readonly IMessageSender _exceriseSubject;

        public Gym(IMessageSender exceriseSubject)
        {
            _exceriseSubject = exceriseSubject;
        }

        public void Excerise()
        {
            _exceriseSubject.Send(null, null);
        }
    }
}
