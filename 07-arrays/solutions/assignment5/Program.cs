var b = new byte[,] {    // a "byte" is just a small integer type
    { 0, 0, 0 },
    { 1, 1, 1 },
    { 0, 1, 0 },
};
PrintBlock(b);

b = RotateLeft(b);
PrintBlock(b);
// block is now:
//  0 1 0
//  0 1 1
//  0 1 0

b = RotateLeft(b);
PrintBlock(b);
// block is now:
//  0 1 0
//  1 1 1
//  0 0 0


byte[,] RotateLeft(byte[,] block)
{
    var size = block.GetLength(0);
    var result = new byte[size, size];

    for (var i = 0; i < size; i++)
    {
        for (var j = 0; j < size; j++)
        {
            result[size - j - 1, i] = block[i, j];
        }
    }

    return result;
}

void PrintBlock(byte[,] block)
{
    var size = block.GetLength(0);

    for (var i = 0; i < size; i++)
    {
        for (var j = 0; j < size; j++)
        {
            Console.Write(block[i, j]);
        }

        Console.Write(Environment.NewLine);
    }

    Console.WriteLine();
}
