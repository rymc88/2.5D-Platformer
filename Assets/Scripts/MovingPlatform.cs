using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private int _targetID;
    [SerializeField] private float _speed;


    void Start()
    {
        _targetID = (_targetID + 1) % _waypoints.Length;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_targetID].transform.position, _speed * Time.deltaTime);

        if(transform.position == _waypoints[_targetID].transform.position)
        {
            _targetID = (_targetID + 1) % _waypoints.Length;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
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

    /*if(_waypointID == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[1].position, _speed * Time.deltaTime);

            if(transform.position == _waypoints[1].position)
            {
                _waypointID = 1;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[0].position, _speed * Time.deltaTime);

            if(transform.position == _waypoints[0].position)
            {
                _waypointID = 0;
            }
        }*/
}

