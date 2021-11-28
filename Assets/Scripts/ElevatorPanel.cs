using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _elevatorButton;
    [SerializeField] private int _requiredCoins;
    
    private Elevator _elevator;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if(_elevator == null)
        {
            Debug.LogError("Elevator is Null");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();

                if(player.CoinCount() == _requiredCoins && player.HasKey()== true)
                { 
                    _elevator.CallElevator();
                }

            }
        }
    }
}

