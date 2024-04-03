using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class ChaseState :stateBase
    {
        [SerializeField] private GameObject _target;
        [SerializeField,Min(0f)] private float _speed = 1f;
        [SerializeField,Min(0f)] private float _decetionRange = 5f;
        public override State GetState { get { return State.Chase; } }
        public override State OnStateUpdate()
        {
            Vector3 direction = _target.transform.position - _myAgent.transform.position;
            direction.Normalize();

            _myAgent.transform.position += direction * _speed * Time.deltaTime;

            if (Vector3.Distance(_myAgent.transform.position, _target.transform.position) < _decetionRange)
            {
                Debug.Log("in range");
                return State.Chase;
            }
            else
            {
                return State.Idle;
            }
        }
    }
}