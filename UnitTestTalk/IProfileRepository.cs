namespace UnitTestTalk
{
    public interface IProfileRepository
    {
        Profile GetProfile(int id);
        Profile CreateProfile(Profile profile);
        Profile UpdateProfile(Profile profile);
    }
}