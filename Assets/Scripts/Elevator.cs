using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private bool _movingDown = false;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private MeshRenderer _elevatorButton;

    private void Start()
    {
        if(_elevatorButton == null)
        {
            Debug.LogError("Elevator Button is Null");
        }
    }

    public void CallElevator()
    {
        _movingDown = true;
    }

    private void FixedUpdate()
    {
  
        if (_movingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _end.transform.position, _speed * Time.deltaTime);
            _elevatorButton.material.color = Color.green;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _start.transform.position, _speed * Time.deltaTime);
            _elevatorButton.material.color = Color.red;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _movingDown = false;
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
