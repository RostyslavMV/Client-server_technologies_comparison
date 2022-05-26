namespace FordFulkersonBlazorHosted.Server
{
    public class ReadMatrixService
    {
        public static int[,] readMatrix()
        {
            int[,] matrix;
            var stringMatrix = File.ReadAllText(@"D:\Users\Rostyslav\source\repos\FordFulkersonBlazorHosted\Client\wwwroot\matrix.txt");

            string[] matrixRows = stringMatrix.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int size = matrixRows.Length - 1;
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int[] row = matrixRows[i].Split(",").Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            return matrix;
        }
    }
}
