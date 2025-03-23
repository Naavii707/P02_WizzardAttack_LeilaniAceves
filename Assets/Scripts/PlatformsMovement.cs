using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]
    private float _InitialSpeed = 2f;
    [SerializeField]
    private float _speedincrease = 0.1f;
    [SerializeField]
    private UnityEvent<int> _onscoredChangued;
    private bool _canMove = true;
    public bool CanMove { set => _canMove = value; }
    private Vector3 _StartingPosition;
    public float _speed;

    private float pastSpeed;

    private Vector3 _moveDistance;

    public void SpeedUp(float speedMultipler)
    {
        pastSpeed = _speed;
        _speed *= speedMultipler;

    }

    public void SpeedDown()
    {
        _speed = pastSpeed;
    }
    void Start()
    {
        _StartingPosition = transform.position;
        _speed = _InitialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            MovePlatforms();
        }
    }
    private void MovePlatforms()
    {
        Vector3 distanceToMove = Vector3.left * _speed * Time.deltaTime;
        transform.position += distanceToMove;
        _moveDistance += distanceToMove;
        _onscoredChangued?.Invoke(math.abs((int)_moveDistance.x));

    }
    public void IncreaseSpeed()
    {
        _speed += _speedincrease;
    }
    public void StopMovement()
    {
        _canMove = false;
    }
    public void StartMovement()
    {
        _canMove = true;
    }
    public void Restart()
    {
        transform.position = _StartingPosition;
        _speed = _InitialSpeed;
        _moveDistance = Vector3.zero;
        StartMovement();
    }
}

