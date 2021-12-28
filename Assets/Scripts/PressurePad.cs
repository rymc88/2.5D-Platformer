using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Moving Box")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if(distance < 1.0f)
            {
                Rigidbody box = other.GetComponent<Rigidbody>();

                if(box != null)
                {
                    box.isKinematic = true;
                }

                Renderer renderer = this.GetComponent<Renderer>();
                if(renderer != null)
                {
                    renderer.material.color = Color.green;
                }

                Renderer boxRenderer = other.GetComponent<Renderer>();
                if(boxRenderer != null)
                {
                    boxRenderer.material.color = Color.green;
                }

                Destroy(this);
            }
        }
    }
}
