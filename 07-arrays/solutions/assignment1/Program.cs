var input = new [] { 6, 1, 4, 5, 2, 8 };
var output = ThresholdSum(input, 4);  // 6 + 5 + 8

Console.WriteLine(output); // 19

int ThresholdSum(int[] values, int threshold)
{
    var sum = 0;
    foreach (var value in values)
    {
        if (value <= threshold)
        {
            continue;
        }

        sum += value;
    }

    return sum;
}
