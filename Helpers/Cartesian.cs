namespace Csharp_Task_3.Helpers
{
    public static class Cartesian
    {
        public static List<List<T>> Calculate<T>(List<List<T>> input)
        {
            List<List<T>> result = new List<List<T>>();
            if (input.Count == 0)
            {
                result.Add(new List<T>());
                return result;
            }
            else
            {
                List<T> head = input[0];
                List<List<T>> tail = Calculate(input.GetRange(1, input.Count - 1));
                foreach (T h in head)
                {
                    foreach (List<T> t in tail)
                    {
                        List<T> resultElement = new List<T>();
                        resultElement.Add(h);
                        resultElement.AddRange(t);
                        result.Add(resultElement);
                    }
                }
            }
            return result;
        }
    }
}
