namespace SmallAndSmaller;

public class Good
{
    public void Main()
    {
        int[] array = { 10, 5, 1, 7, 2 };

        PrintArray(array, "Array:");
        PrintArray(BubbleSort(array), "Sorted Array:");
        Console.Read();
    }

    private int[] BubbleSort(int[] arr)
    {
        for (var j = 0; j < arr.Length - 1; j++)
        for (var i = 0; i < arr.Length - 1; i++)
            if (arr[i] > arr[i + 1])
                arr = SwapArrayIndex(arr, i, i + 1);

        return arr;
    }

    private void PrintArray(int[] array, string title)
    {
        Console.WriteLine($"{title}");
        foreach (var p in array)
            Console.WriteLine($"{p} ");
    }

    private int[] SwapArrayIndex(int[] arr, int beginIndex, int endIndex)
    {
        (arr[endIndex], arr[beginIndex]) = (arr[beginIndex], arr[endIndex]);
        return arr;
    }
}