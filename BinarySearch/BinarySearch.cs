namespace BinarySearch;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int lo = 0, hi = input.Length - 1;

        while (lo <= hi)
        {
            var mid = (lo + hi) >>> 1;

            if (input[mid] == value) return mid;

            if (input[mid] < value)
                lo = mid + 1;
            else
                hi = mid - 1;
        }


        return -1;
    }
}
