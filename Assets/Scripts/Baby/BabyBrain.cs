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

    [NaughtyAttributes.Button]
    public void StartPolling()
    {
        StopAllCoroutines();
        StartCoroutine(PollAndExecuteActions());
    }

    [NaughtyAttributes.Button]
    public void StopPolling()
    {
        StopAllCoroutines();
    }

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

    float _boredomReductionRate = -0.1f;

    IEnumerator ReduceBoredom()
    {
        while (_state._boredom > 0)
        {
            _state._boredom += _boredomReductionRate * Time.deltaTime;
            yield return null;
        }
    }

    float _prePottyTime = 2f;
    [SerializeField] GameObject _poopPrefab;

    IEnumerator GoPotty()
    {
        yield return new WaitForSeconds(_prePottyTime);
        // TODO Spawn poop
        var poop = Instantiate(_poopPrefab, transform.position, transform.rotation);

        // Reduce potty to 0
        _state._potty = 0f;
    }

    IEnumerator PerformAction(IBabyAction babyAction)
    {
        Debug.Log($"Going to {babyAction.Type}");
        if (babyAction is PlayWithToy)
        {
            var playAction = babyAction as PlayWithToy;
            yield return WalkToPosition(playAction._toy.transform.position);
            yield return ReduceBoredom();    // play time
        }
        else if (babyAction is Wander)
        {
            NavMeshHit navMeshHit;
            bool foundPosition = NavMesh.SamplePosition(
                transform.position + Random.insideUnitSphere * 20f,
                out navMeshHit,
                20f,
                NavMesh.AllAreas
            );

            yield return WalkToPosition(navMeshHit.position);
        }
        else if (babyAction is GoPotty)
        {
            NavMeshHit navMeshHit;
            bool foundPosition = NavMesh.SamplePosition(
                transform.position + Random.insideUnitSphere * 20f,
                out navMeshHit,
                20f,
                NavMesh.AllAreas
            );

            yield return WalkToPosition(navMeshHit.position);
            yield return GoPotty();

        }
        yield return null;
    }

    IEnumerator PollAndExecuteActions()
    {
        while (true)
        {
            var action = GetNextAction(new BabyContext
            {
                state = _state,
                toys = _toys,
                position = transform.position
            });
            _state._currentAction = action;

            yield return PerformAction(action);
        }
    }
}
