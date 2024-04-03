using UnityEngine;


namespace AI
{
public class PatrolState : stateBase
{
    
    [SerializeField] Transform[] _patrolPoints;
    [SerializeField] private float _speed;
    
    private int _patrolIndex = 0;
    public override State GetState { get { return State.Patrol; } }

    public override State OnStateUpdate()
    {

        Vector3 direction = _patrolPoints[_patrolIndex].position - _myAgent.transform.position;
        direction.Normalize();
        _myAgent.transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(_myAgent.transform.position, _patrolPoints[_patrolIndex].position)< 1f)
        {
            _patrolIndex++;
            if (_patrolIndex >= _patrolPoints.Length)
            {
                _patrolIndex = 0;
            }
        }
        return State.Patrol;
            
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _patrolPoints.Length; i++)
        {
            if (i < _patrolPoints.Length - 1)
            {
                Gizmos.DrawLine(_patrolPoints[i].position, _patrolPoints[i + 1].position);
            }
            else
            {
                Gizmos.DrawLine(_patrolPoints[i].position, _patrolPoints[0].position);
            }
        }
    }
}
}
