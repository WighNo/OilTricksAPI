namespace OilTricksAPI;

public static class CustomMath
{
    public static float PercentageOfNumber(this float sourceValue, float percent)
    {
        return sourceValue * (percent / 100f);
    }
}