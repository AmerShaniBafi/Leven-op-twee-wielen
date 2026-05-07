namespace O2W.Models.User;

public class Login
{
    public string email { get; set; }
    public string wachtword { get; set; }

    public Login(string email, string wachtword)
    {
        this.email = email;
        this.wachtword = wachtword;
    }
}