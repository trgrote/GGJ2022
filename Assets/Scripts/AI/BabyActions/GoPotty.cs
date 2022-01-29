using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPotty : IBabyAction
{
    public BabyActionType Type => BabyActionType.GO_POTTY;
}

public class GoPottyUtility : IBabyActionUtility
{
    const float MinThreshold = BabyState.MAX / 2f;   // under this threshold, babay will never poop
    
    public BabyActionUtilityResult GetScore(BabyContext context)
    {
        return new BabyActionUtilityResult
        {
            Score = context.state._potty > MinThreshold ? 
                (context.state._potty - MinThreshold) / (BabyState.MAX - MinThreshold) : 
                0f,
            Action = new GoPotty()
        };
    }
}
