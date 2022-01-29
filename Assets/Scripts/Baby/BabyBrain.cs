using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BabyBrain : MonoBehaviour
{
    List<IBabyActionUtility> _utilityFuncs = new List<IBabyActionUtility>();

    void Awake()
    {
        _utilityFuncs.Add(new GoPottyUtility());
        _utilityFuncs.Add(new WanderUtility());
        _utilityFuncs.Add(new PlayWithToyUtility());

        _state._potty = _state._boredom = 0f;
    }

    void OnEnable()
    {
        StartCoroutine(Evaluate());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IBabyAction GetNextAction(BabyContext context)
    {
        var results = _utilityFuncs.Select(utility => utility.GetScore(context)).OrderByDescending(result => result.Score);

        foreach(var result in results)
        {
            // Debug.Log($"{result.Score} => {result.Action.Type}");
        }

        return results.Count() > 0 ? results.First().Action : new Wander();
    }

    [SerializeField] float _evpRate = 1f;
    [SerializeField] BabyState _state;
    [SerializeField] rho.RuntimeGameObjectSet _toys;

    IEnumerator Evaluate()
    {
        var context = new BabyContext
        {
            state = _state,
            toys = _toys
        };

        while (true)
        {
            context.position = transform;
            var result = GetNextAction(context);
            Debug.Log($"Baby needs to {result.Type}!");
            yield return new WaitForSeconds(_evpRate);
        }
    }
}
