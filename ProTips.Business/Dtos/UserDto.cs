namespace ProTips.Business.Dtos;

public class UserDto
{
    public DateTime Birth { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmationPassword { get; set; }
    public int CurrencyId { get; set; }
}