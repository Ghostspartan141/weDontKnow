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
            INitStates(1);
        }
       
        protected virtual void Update()
        {
            INitStates(1);
            StateChanger();
            if (_CurState == null)
            {
                return;
            }
            ChangeState(_CurState.OnStateUpdate());
            
        }
        protected void INitStates(int stateChanger)
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
            if (stateChanger == 1)
            {
                ChangeState(State.Patrol);
            }
            else if (stateChanger == 2) 
            {
                ChangeState(State.Idle);
            }
            else if(stateChanger == 3) 
            {
                ChangeState(State.Chase);
            }
          
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
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                INitStates(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                INitStates(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                INitStates(3);
            }
        }
    }
}