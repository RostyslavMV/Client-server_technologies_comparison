namespace FordFulkersonBlazor.Shared
{
    public class FordFulkersonTimeFlowService
    {

        public static TimeFlowResponse getTimeFlow(int[,] matrix)
        {
            int lastNode = matrix.GetLength(0) - 1;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var maxFlow = FordFulkersonMaxFlowService.fordFulkerson(matrix, 0, lastNode);
            var elapsedMs = watch.ElapsedMilliseconds;
            return new TimeFlowResponse(maxFlow, elapsedMs);
        }
    }
}
