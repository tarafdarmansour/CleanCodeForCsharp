namespace SmallAndSmaller;

public class Bad
{
    public void Main()
    {
        int[] array = { 10, 5, 1, 7, 2 };

        Console.WriteLine("Array:");
        foreach (var p in array)
            Console.WriteLine(p + " ");

        Console.WriteLine("Sorted Array:");
        foreach (var p in BubbleSort(array))
            Console.WriteLine(p + " ");

        Console.Read();
    }

    private int[] BubbleSort(int[] arr)
    {
        int temp;
        for (var j = 0; j < arr.Length - 1; j++)
        for (var i = 0; i < arr.Length - 1; i++)
            if (arr[i] > arr[i + 1])
            {
                temp = arr[i + 1];
                arr[i + 1] = arr[i];
                arr[i] = temp;
            }

        return arr;
    }
}