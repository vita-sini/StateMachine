using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : IMover, IState
{
   

    private const float MinDistanceToTarget = 0.05f;

    private IStateSwitcher StateSwitcher;
    
    private IMovable _movable;

    private Queue<Vector3> _targets;

    private Vector3 _currentTarget;

    private bool _isMoving;

    EnemyKnight _enemyKnight;

    Vector2 DetectorSizeMoveToTarget;

    public Patrolling(IMovable movable, IEnumerable<Vector3> targets, IStateSwitcher stateSwitcher)
    {
        _movable = movable;
        _targets = new Queue<Vector3>(targets);
        StateSwitcher = stateSwitcher;

        _currentTarget = _targets.Dequeue();
    }

    public void Enter()
    {
        Debug.Log(GetType());
    }

    public void Exit() 
    {

    }

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Update()
    {
        if (_isMoving == false)
            return;

        Vector3 direction = _currentTarget - _movable.Transform.position;
        _movable.Transform.Translate(direction.normalized * _movable.Speed * Time.deltaTime);


        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();

        if (_enemyKnight.ColliderCollision(DetectorSizeMoveToTarget) != null)
            StateSwitcher.SwitchState<Manhunt>();
    }

    private void SwitchTarget()
    {
        _targets.Enqueue(_currentTarget);

        _currentTarget = _targets.Dequeue();
    }

    //public void Update() { }
}
