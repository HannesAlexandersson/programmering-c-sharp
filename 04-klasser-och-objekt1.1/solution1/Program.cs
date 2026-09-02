using Assignment1;

var validator = new PasswordValidator();

if (validator.IsValidPassword("p4ssw0rd"))
{
    Console.WriteLine("the password 'p4ssw0rd' is a valid password");
}
