using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayWithToy : IBabyAction
{
    public BabyActionType Type => BabyActionType.PLAY;

    public GameObject _toy;
}

public class PlayWithToyUtility : IBabyActionUtility
{
    private NavMeshPath path = new NavMeshPath();
    const float minToyDistance = 100f;
    
    public BabyActionUtilityResult GetScore(BabyContext context)
    {
        var nearestToys = context.toys.Select(toy => {
            var distance = Mathf.Infinity;
            if (NavMesh.CalculatePath(context.position, toy.transform.position, NavMesh.AllAreas, path) && path.status == NavMeshPathStatus.PathComplete)
            {
                distance = 0f;
                var previousPosition = context.position;
                foreach(var corner in path.corners)
                {
                    distance += Vector3.Distance(corner, previousPosition);
                    previousPosition = corner;
                }
            }

            return new {
                distance,
                toy
            };
        }).OrderBy(result => result.distance);

        foreach (var result in nearestToys)
        {
            // Debug.Log($"{result.distance} => {result.toy.name}");
        }

        var nearestToy = nearestToys.FirstOrDefault(result => result.distance < minToyDistance);

        return new BabyActionUtilityResult
        {
            Score = nearestToy == null ? 0f : 1f,
            Action = new PlayWithToy{ _toy = nearestToy?.toy}
        };
    }
}
