using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhunt : IMover, IState
{

    private IStateSwitcher StateSwitcher;
    
    private Transform _target;
    private IMovable _movable;

    private bool _isMoving;

    EnemyKnight _enemyKnight;

    Vector2 DetectorSizeMoveToTarget;

    public Manhunt(Transform target, IMovable movable, IStateSwitcher stateSwitcher)
    {
        _target = target;
        _movable = movable;
        StateSwitcher = stateSwitcher;
    }

    public void Enter() { }

    public void Exit() { }

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Update()
    {
        if (_isMoving == false)
            return;

        Vector3 direction = _target.position - _movable.Transform.position;
        _movable.Transform.Translate(direction.normalized * _movable.Speed * Time.deltaTime);

        if (_enemyKnight.ColliderCollision(DetectorSizeMoveToTarget) == null)
            StateSwitcher.SwitchState<Manhunt>();
    }

    //public void Update() { }
}
