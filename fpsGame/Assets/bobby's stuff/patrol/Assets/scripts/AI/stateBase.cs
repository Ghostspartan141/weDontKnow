using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    public abstract class stateBase : MonoBehaviour
    {
        protected AIAgent _myAgent;
        public abstract State GetState { get; }
        public void InitState(AIAgent agent)
        {
            _myAgent = agent;
        }

        public virtual void OnStateEnter() { }
        public abstract State OnStateUpdate();
        public virtual void OnStateExit() { }
    }
    public enum State
    {
        Idle,
        Chase,
        Patrol
    }
}
    
