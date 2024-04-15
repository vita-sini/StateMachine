
using UnityEngine;

public class EnemyKnight : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private IMover _mover;

    public float Speed => _speed;

    public Transform Transform => transform;

    public LayerMask layerMask;

    public Vector2 DetectorSize = Vector2.one;

    //private void Update() => _mover?.Update(Time.deltaTime);

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    public Collider2D ColliderCollision(Vector2 DetectorSize)
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, DetectorSize, 0, layerMask);

        return collider;
    }
}
