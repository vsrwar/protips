namespace ProTips.Business.Dtos;

public class UserAuthenticated
{
    public DateTime Birth { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}