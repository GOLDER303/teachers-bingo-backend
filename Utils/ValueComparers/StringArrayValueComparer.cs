using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TeachersBingoApi.Utils.ValueComparers;

public class StringArrayValueComparer : ValueComparer<string[,]>
{
    public StringArrayValueComparer() : base(
        (arr1, arr2) => ArraysAreEqual(arr1, arr2),
        arr => ArraysHashCode(arr),
        arr => (string[,])arr.Clone() ?? new string[3, 3])
    { }

    private static bool ArraysAreEqual(string[,]? arr1, string[,]? arr2)
    {
        if (arr1 == null || arr2 == null || arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                if (arr1[i, j] != arr2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static int ArraysHashCode(string[,] arr)
    {
        unchecked
        {
            int hash = 17;
            foreach (var element in arr)
            {
                hash = hash * 23 + (element?.GetHashCode() ?? 0);
            }
            return hash;
        }
    }
}
