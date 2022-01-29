// Result containing score and proposed action
public struct BabyActionUtilityResult
{
    public float Score;
    public IBabyAction Action;
}

public interface IBabyActionUtility
{
    public BabyActionUtilityResult GetScore(BabyContext context);
}