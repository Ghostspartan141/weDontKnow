using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class IdleState : stateBase 
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _AIGameObject;
        [SerializeField, Min(0)] private float _decttionRange = 5f;
        public override State GetState { get { return State.Idle; } }

        public override State OnStateUpdate()
        {
            if (Vector3.Distance(_AIGameObject.transform.position, _target.transform.position) > _decttionRange)
            {
                Debug.Log("out range");
                return State.Idle;
            }
            return State.Chase;
        }

    }
}
