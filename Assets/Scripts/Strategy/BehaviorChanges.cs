using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BehaviorChanges : MonoBehaviour
{
    [SerializeField] private EnemyKnight _enemyKnight;

    [SerializeField] private Transform _target;

    [SerializeField] private List<Transform> _patrolPoints;

    [SerializeField] SpriteRenderer _spriteRenderer;

    private Vector3 previousPosition;

    PointByPointMover pointByPointMover;

    public LayerMask layerMask;

    public Vector2 DetectorSizeAttack = Vector2.one;

    public Vector2 DetectorSizeMoveToTarget = Vector2.one;

    private void Awake()
    {
        _enemyKnight.SetMover(new NoMove());
    }

    private void Start()
    {
        pointByPointMover = new PointByPointMover(_enemyKnight, _patrolPoints.Select(point => point.position));

        previousPosition = _enemyKnight.transform.position;
    }

    private void Update()
    {
        Vector3 currentPosition = _enemyKnight.transform.position;

        if (_enemyKnight.ColliderCollision(DetectorSizeMoveToTarget) == null)
            _enemyKnight.SetMover(pointByPointMover);

        if (_enemyKnight.ColliderCollision(DetectorSizeMoveToTarget) != null)
            _enemyKnight.SetMover(new MoveToTarget(_target, _enemyKnight));

        if (_enemyKnight.ColliderCollision(DetectorSizeAttack) != null)
        {
            _enemyKnight.SetMover(new NoMove());

        }

        if (currentPosition.x > previousPosition.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;


        previousPosition = currentPosition;
    }
}
