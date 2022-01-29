using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
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

    void Start()
    {
        // StartCoroutine(Evaluate());
        _agent = GetComponent<NavMeshAgent>();
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

    [SerializeField] BabyState _state;
    [SerializeField] rho.RuntimeGameObjectSet _toys;

    void Update()
    {
        if (_state._currentAction == null)
        {
            // EvaluateForAction();
        }
    }

    [NaughtyAttributes.Button]
    public void EvaluateForAction()
    {
        var context = new BabyContext
        {
            state = _state,
            toys = _toys,
            position = transform.position
        };

        var action = GetNextAction(context);
        _state._currentAction = action;

        StopAllCoroutines();
        StartCoroutine(_actionPeformance = PerformAction(action));
    }

    IEnumerator _actionPeformance = null;
    NavMeshAgent _agent;

    IEnumerator WalkToPosition(Vector3 position)
    {
        _agent.SetDestination(position);

        while (true)
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        break;
                    }
                }
            }

            yield return null;
        }
    }

    IEnumerator PerformAction(IBabyAction babyAction)
    {
        Debug.Log($"Going to {babyAction.Type}");
        if (babyAction is PlayWithToy)
        {
            var playAction = babyAction as PlayWithToy;
            yield return WalkToPosition(playAction._toy.transform.position);
            yield return new WaitForSeconds(5f);    // play time
        }
        yield return null;
    }
}
