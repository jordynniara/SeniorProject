
public static class SceneManage
{
    private static string lastScene;

    public static void setLastLevel(string level)
    {
        lastScene = level;
    }

    public static string getLastScene()
    {
        return lastScene;
    }
}