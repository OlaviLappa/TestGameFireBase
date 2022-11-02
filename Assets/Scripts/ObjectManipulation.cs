using System.Collections;
using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    private Vector3 _launchPos;
    private Vector3 _direction;
    private Vector3 _lastPosition;
    private Vector3 aVector, bVector;

    private bool _aimingMode;
    private bool _isFliengStart = false;

    private float _speed = 9f;

    private void Start()
    {
        _aimingMode = false;
        _launchPos = this.gameObject.transform.position;
    }

    private void OnMouseDrag() => _aimingMode = true;

    private void Update()
    {
        if (_aimingMode)
        {
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - _launchPos;

            float maxMagnitude = this.GetComponent<SphereCollider>().radius * 4;

            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            _lastPosition = _launchPos + mouseDelta;
            this.gameObject.transform.position = new Vector3(_lastPosition.x, _lastPosition.y, -11.21f);

            if (Input.GetMouseButtonUp(0))
            {
                LevelConfiguration.OnCreateNewUserBall.Invoke();

                _aimingMode = false;
                _isFliengStart = true;
                _lastPosition = transform.position;

                aVector = _lastPosition;
                bVector = _launchPos;

                _direction = bVector - aVector;
            }
        }

        if (_isFliengStart)
            transform.position += _speed * Time.deltaTime * _direction;
    }

    public void ChangeDirectionX() => _direction = new Vector3(-_direction.x, _direction.y, _direction.z);
    public void ChangeDirectionY() => _direction = new Vector3(_direction.x, -_direction.y, _direction.z);
}
