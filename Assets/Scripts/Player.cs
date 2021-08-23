using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    private float _yVelocity;
    private bool _canDoubleJump;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _playerSpeed;

        if(_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
                
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

}
