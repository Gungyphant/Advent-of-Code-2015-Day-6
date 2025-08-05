namespace AOC2015Day6
{
    class Program
    {
        static T[] To1DArray<T>(T[,] input)
        {
            // Step 1: get total size of 2D array, and allocate 1D array.
            int size = input.Length;
            T[] result = new T[size];

            // Step 2: copy 2D array elements into a 1D array.
            int write = 0;
            for (int i = 0; i <= input.GetUpperBound(0); i++)
            {
                for (int z = 0; z <= input.GetUpperBound(1); z++)
                {
                    result[write++] = input[i, z];
                }
            }
            // Step 3: return the new array.
            return result;
        }
        static void PrintLights(bool[,] lights)
        {
            string result = "";
            for (int y = 0; y < 1000; y++)
            {
                result += String.Join("", from x in Enumerable.Range(0, 1000) select (lights[x, y] ? "#" : " ")) + "\n";
            }
            Console.WriteLine(result);
        }
        static string PartOne(string data)
        {
            bool[,] lights = new bool[1000, 1000];
            foreach (string line in data.Split('\n'))
            {
                //PrintLights(lights);
                if (line != "")
                {
                    string[] words = line.Split(' ');
                    string startPos;
                    string lastPos;
                    if (line.Contains("turn"))
                    {
                        startPos = words[2];
                        lastPos = words[4];
                    }
                    else if (line.Contains("toggle"))
                    {
                        startPos = words[1];
                        lastPos = words[3];
                    }
                    else
                    {
                        throw new Exception(line);
                    }
                    int startX = Convert.ToInt32(startPos.Split(",")[0]);
                    int startY = Convert.ToInt32(startPos.Split(",")[1]);
                    int lastX = Convert.ToInt32(lastPos.Split(",")[0]);
                    int lastY = Convert.ToInt32(lastPos.Split(",")[1]);
                    for (int x = startX; x <= lastX; x++)
                    {
                        for (int y = startY; y <= lastY; y++)
                        {
                            if (line.Contains("on"))
                            {
                                lights[x, y] = true;
                            }
                            else if (line.Contains("off"))
                            {
                                lights[x, y] = true;
                            }
                            else if (line.Contains("toggle"))
                            {
                                lights[x, y] = !lights[x, y];
                            }
                            else
                            {
                                throw new Exception(line);
                            }
                        }
                    }
                }
            }
            return Convert.ToString(To1DArray(lights).Count(c => c));
        }
        static string PartTwo(string data)
        {
            return "";
        }
        static void Main() // 702707 too high
        {
            string file = File.ReadAllText(@"../../../input.txt");
            Console.WriteLine(PartOne(file));
            Console.WriteLine(PartTwo(file));
        }
    }
}