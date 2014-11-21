using UnitTestTalk.Workshop.Models;

namespace UnitTestTalk.Workshop
{
    public interface IMembershipRepository
    {
        void Create(Membership membership);

        Membership Get(string username);

        void Update(Membership membership);
    }
}