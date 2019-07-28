using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookDirectionController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = (Vector2)mousePosition - _rigidbody2D.position;
        _lookDirection.Normalize();
        transform.up = _lookDirection;
    }

    public Vector2 GetLookDirection()
    {
        return _lookDirection;
    }
}
