using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    private float _yVelocity;
    private bool _canDoubleJump;
    private CharacterController _controller;
    

    [Header("UI")]
    private int _coinCount;
    private UIManager _uiManager;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiManager == null)
        {
            Debug.LogError("UI Manager Null");
        }

        _coinCount = 0;
        _uiManager.UpdateCoinDisplay(_coinCount);
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

    public void AddCoin()
    {
        _coinCount++;

        _uiManager.UpdateCoinDisplay(_coinCount);
    }

}
