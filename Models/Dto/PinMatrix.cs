using Csharp_Task_3.Helpers;


namespace Csharp_Task_3.Models.Dto
{
    public class PinMatrix
    {
        #region VARIABLES
        private static readonly int Rows = 4;
        private static readonly int Columns = 3;

        int CurrentRow = -1;
        int CurrentColumn = -1;

        public string[,] NumberPositions = new string[Rows, Columns];
        #endregion

        #region CONSTRUCTOR
        public PinMatrix()
        {
            NumberPositions[0, 0] = "1";
            NumberPositions[0, 1] = "2";
            NumberPositions[0, 2] = "3";

            NumberPositions[1, 0] = "4";
            NumberPositions[1, 1] = "5";
            NumberPositions[1, 2] = "6";

            NumberPositions[2, 0] = "7";
            NumberPositions[2, 1] = "8";
            NumberPositions[2, 2] = "9";

            NumberPositions[3, 0] = "-1";
            NumberPositions[3, 1] = "0";
            NumberPositions[3, 2] = "-1";
        }
        #endregion

        #region METHODS
        public List<string> pinVariations(string num)
        {
            var result = new List<string>();
            char[] parts = num.ToCharArray();
            List<List<string>> mainlist = new List<List<string>>();
            //create main list
            foreach (char part in parts)
            {
                List<string> res = oneNumberVariations(part.ToString());
                mainlist.Add(res);


            }

           var result1 = Cartesian.Calculate(mainlist);
            
            foreach(List<string> res1 in result1)
            {
                string temp = "";
               foreach(string res2 in res1)
               {
                    temp += res2;
               }
                result.Add(temp);
            }
            
            return result;
        }
      

     
        static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetCombinations(list, length - 1)
                .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        private List<string> oneNumberVariations(string num)
        {
            var result = new List<string>();
            //sample for 8
            //result = new List<string> { "5", "7", "8", "9", "0" };
            //int keyIndex = Array.FindIndex(NumberPositions, w => w.Equals(num));
            findNumberPossitionInMatrix(num);
            result=getOtherVaritionsForNumber();
            result.Add(num.ToString()); 
            return result;
        }
        private void findNumberPossitionInMatrix(string num)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (NumberPositions[i, j] == num)
                    {
                        CurrentRow = i;
                        CurrentColumn = j;
                        break;
                    }
                }
            }
        }
        private List<string> getOtherVaritionsForNumber()
        {
            List<string> result = new List<string>();

            #region Horisontal
            //try left, only for CurrentColumn>0
            if (CurrentColumn > 0)
            {
                string tempInt = NumberPositions[CurrentRow, CurrentColumn - 1];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            //try right, only for CurrentRow<2
            if (CurrentColumn < Columns-1)
            {
                string tempInt = NumberPositions[CurrentRow, CurrentColumn + 1];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            #endregion
            #region Vertical
            //try up, only for CurrentRow>0
            if (CurrentRow > 0)
            {
                string tempInt = NumberPositions[CurrentRow - 1, CurrentColumn];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            //try right, only for CurrentRow<2
            if (CurrentRow < Rows-1)
            {
                string tempInt = NumberPositions[CurrentRow + 1, CurrentColumn];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            #endregion

            return result;
        }


        #endregion

    }
}
