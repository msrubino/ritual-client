using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
    public float _currentSpeed;
    public int _direction;

    void Start()
    {
        StartCoroutine( ToggleDirection() );
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float rotateSpeed = _direction * _currentSpeed * Time.deltaTime;
        transform.Rotate( Vector3.forward * rotateSpeed );
    }

    public void SetDirection( int newDirection )
    {
        _direction = newDirection;
    }

    public void SetRandomDirection()
    {
        _direction = ( Random.value < .5f ) ? -1 : 1 ;
    }

    public void SetSpeed( float newSpeed )
    {
        _currentSpeed = newSpeed;
    }

    public IEnumerator ToggleDirection()
    {
        yield return new WaitForSeconds( 5f );
        float currentSpeedTarget = _currentSpeed * -1;

        GoTweenConfig config = new GoTweenConfig().floatProp( "_currentSpeed", currentSpeedTarget );
        Go.to( this, 2.5f, config );
    }
}
