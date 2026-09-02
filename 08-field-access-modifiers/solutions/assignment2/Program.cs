var change = GetChangeForCustomer(price: 100, pay: 100);
// change = new [] { }
change = GetChangeForCustomer(price: 32, pay: 50);
// change = new [] { 10, 5, 2, 1 }
change = GetChangeForCustomer(price: 501, pay: 1000);
// change = new [] { 200, 200, 50, 20, 20, 5, 2, 2 }
Console.WriteLine();
int[] GetChangeForCustomer(int price, int pay)
{
    var register = new[] { 500, 200, 100, 50, 20, 10, 5, 2, 1 };

    var changeLeft = pay - price;
    var change = new List<int>();
    foreach (var cash in register)
    {
        while (changeLeft - cash >= 0)
        {
            change.Add(cash);
            changeLeft -= cash;
        }
    }

    return change.ToArray();
}
