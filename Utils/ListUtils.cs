namespace TeachersBingoApi.Utils;

public class ListUtils
{
    public static void ShuffleList<T>(List<T> list)
    {
        Random random = new();
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}