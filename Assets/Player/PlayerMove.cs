using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _pos;
    private Animator _animator;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            _animator.SetBool("PlayWalkAnim", true);
        }
        else
        {
            _animator.SetBool("PlayWalkAnim", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _animator.Play("WaveAnimation");
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            _animator.SetBool("PlayWaveAnim", true);
        }
        else
        {
            _animator.SetBool("PlayWaveAnim", false);
        }
        _pos = (Vector2.up * Input.GetAxis("Vertical") * speed + Vector2.right * Input.GetAxis("Horizontal") * speed);
        // _pos = _pos.normalized * _speed;
        _pos += (Vector2)transform.position;
        _rigidbody2D.MovePosition(_pos);
    }
}
