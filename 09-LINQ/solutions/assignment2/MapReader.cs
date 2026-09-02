namespace Assignment2
{
    public class MapReader
    {
        private const char Land = '#';
        private const char Water = '.';

        private readonly string[] _rawMap;

        public MapReader(string[] rawMap)
        {
            _rawMap = rawMap;
        }

        public int CountShorelines()
        {
            var gazetteeredMap = ConvertToArray(_rawMap);
            var count = 0;

            var height = gazetteeredMap.GetLength(0);
            var width = gazetteeredMap.GetLength(1);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (gazetteeredMap[y, x] != Land)
                    {
                        continue;
                    }

                    if (y > 0 && gazetteeredMap[y - 1, x] == Water)
                    {
                        count++;
                    }

                    if (y < height - 1 && gazetteeredMap[y + 1, x] == Water)
                    {
                        count++;
                    }

                    if (x > 0 && gazetteeredMap[y, x - 1] == Water)
                    {
                        count++;
                    }

                    if (x < width - 1 && gazetteeredMap[y, x + 1] == Water)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private char[,] ConvertToArray(string[] map)
        {
            var height = map.Length;
            var width = map[0].Length;

            var gazetteeredMap = new char[height, width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    gazetteeredMap[y, x] = map[y][x];
                }
            }

            return gazetteeredMap;
        }
    }
}
