using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    private float _yVelocity;
    private bool _canDoubleJump;
    private CharacterController _controller;
    [SerializeField] private int _coinsNeeded;
    private bool _hasKey;
    private Vector3 _direction;
    private Vector3 _velocity;
    private bool _canWallJump;
    private Vector3 _wallSurfaceNormal;
    [SerializeField] private float _pushPower;

    [SerializeField] private Transform _respawnPosition;
    
    [Header("UI")]
    private int _coinCount;
    private UIManager _uiManager;
    [SerializeField] private int _lives;
    
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
        _uiManager.UpdateLivesDisplay(_lives);

        _hasKey = false;

    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (_controller.isGrounded == true)
        {
            _canWallJump = false;
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _playerSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == false)
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }

            }

            if(Input.GetKeyDown(KeyCode.Space) && _canWallJump == true)
            {
                _yVelocity = _jumpHeight;
                _velocity = _wallSurfaceNormal * _playerSpeed;
            }

            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if(hit.transform.tag == "Moving Box")
        {
            Rigidbody box = hit.collider.attachedRigidbody;

            if(box == null)
            {
                return;
            }

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);
            box.velocity = pushDir * _pushPower;
        }

        if(_controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.red);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }
       
    }

    public void AddCoin()
    {
        _coinCount++;

        _uiManager.UpdateCoinDisplay(_coinCount);
    }

    public void LoseLife()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CollectedKey()
    {
        _hasKey = true;
    }

    public bool HasKey()
    {
        return _hasKey;
    }

    public int CoinCount()
    {
        return _coinCount;
    }

}
