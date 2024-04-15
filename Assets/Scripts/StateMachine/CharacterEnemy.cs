using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemy : MonoBehaviour, IMovable
{
    [SerializeField] public CharacterEnemy _enemyKnight;
    [SerializeField] public  List<Transform> _patrolPoints;
    [SerializeField] public  Transform _target;
    [SerializeField] private float _speed;

    private CharacterStateMachine _stateMachine;

    public Vector2 DetectorSizeMoveToTarget = Vector2.one;

    public Transform Transform => transform;

    public float Speed => _speed;

    private void Awake()
    {
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        Debug.Log(Time.deltaTime);
        _stateMachine.Update();
    }
}
