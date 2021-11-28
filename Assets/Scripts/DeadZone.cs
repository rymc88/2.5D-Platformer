using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.LoseLife();
            }

            CharacterController characterController = other.GetComponent<CharacterController>();

            if(characterController != null)
            {
                characterController.enabled = false;
            }

            other.transform.position = _spawnPosition.transform.position;

            StartCoroutine(CharacterControllerEnabledRoutine(characterController));
        }
    }

    IEnumerator CharacterControllerEnabledRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.01f);
        controller.enabled = true;
    }
}
