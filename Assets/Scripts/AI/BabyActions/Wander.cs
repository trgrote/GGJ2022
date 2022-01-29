using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : IBabyAction
{
    public BabyActionType Type => BabyActionType.WANDER;
}

public class WanderUtility : IBabyActionUtility
{
    public BabyActionUtilityResult GetScore(BabyContext context)
    {
        return new BabyActionUtilityResult
        {
            Score = 0.5f,
            Action = new Wander()
        };
    }
}
