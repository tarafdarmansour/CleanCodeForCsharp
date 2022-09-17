namespace HaveNoSideEffects;

public class Good
{
    private Cryptographer _cryptographer;
    private Session _session;
    private UserService _userService;

    public ActionResult Login(RequestLogin requestLogin)
    {
        if (CheckUser(requestLogin.UserName, requestLogin.Password))
        {
            _session.Initialize();
            return new ActionResult("Success", 0);
        }

        return new ActionResult("Fail", 1);
    }

    private bool CheckUser(string userName, string password)
    {
        var user = _userService.FindByName(userName);
        if (user != null)
        {
            var codedPharase = user.GetPhraseEncodedByPassword();
            var pharase = _cryptographer.Decrypt(codedPharase, password);
            if (pharase == "Valid")
                _session.Initialize();
        }

        return false;
    }
}