namespace HaveNoSideEffects;

public class Bad
{
    private Cryptographer _cryptographer;
    private Session _session;
    private UserService _userService;

    public bool CheckUser(string userName, string password)
    {
        var user = _userService.FindByName(userName);
        if (user != null)
        {
            var codedPharase = user.GetPhraseEncodedByPassword();
            var pharase = _cryptographer.Decrypt(codedPharase, password);
            if (pharase == "Valid")
            {
                _session.Initialize();
                return true;
            }
        }

        return false;
    }
}