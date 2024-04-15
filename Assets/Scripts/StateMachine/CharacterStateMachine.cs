using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStateMachine : IStateSwitcher
{
    CharacterEnemy _enemyKnight;
    List<Transform> _patrolPoints;
    Transform _target;

    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(CharacterEnemy characterEnemy)
    {
        _states = new List<IState>()
        {
            new Patrolling(_enemyKnight, _patrolPoints.Select(point => point.position), this),
            new Manhunt(_target, _enemyKnight, this),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
