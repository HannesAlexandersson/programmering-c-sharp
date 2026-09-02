var number = FindDuplicateNumber([2, 14, 95, 8, 20, 14, 7, 3]);

Console.WriteLine(number);  // 14

int FindDuplicateNumber(int[] values)
{
    for (var i = 0; i < values.Length; i++)
    {
        var currentValue = values[i];
        for (var j = i + 1; j < values.Length; j++)
        {
            var compareValue = values[j];
            if (currentValue != compareValue)
            {
                continue;
            }

            return currentValue;
        }
    }

    return -1;
}
