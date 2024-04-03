using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        protected Dictionary<State, stateBase> _states = new Dictionary<State, stateBase>();
        protected stateBase _CurState;
        public float waitTime = 5;
        
        protected virtual void Start()
        {
            
        }
       
        protected virtual void Update()
        {
           
            StateChanger();
            if (_CurState == null)
            {
                return;
            }
            ChangeState(_CurState.OnStateUpdate());
            
        }
        protected void INitStates()
        {
            stateBase[] allStates = GetComponents<stateBase>();
            foreach (stateBase state in allStates)
            {
                if (_states.ContainsKey(state.GetState) == false)
                {
                    _states.Add(state.GetState, state);
                    state.InitState(this);
                }
            }          
                ChangeState(State.Idle);
        }
        protected void ChangeState(State newState)
        {
            if(_CurState == null)
            {
                
                _CurState = _states[newState];
                _CurState?.OnStateEnter();
                _CurState?.OnStateExit();
                return;
            }
        }
        public void StateChanger()
        {
                INitStates();
        }
    }
}