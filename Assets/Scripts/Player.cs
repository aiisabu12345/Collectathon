using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LayerMask mask;

    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
    }

    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward * 5f,Color.red);
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.transform.position,
                                Camera.main.transform.forward,
                                out RaycastHit hit,
                                5f,
                                mask))
            {
                IInteractable comp = hit.collider.gameObject.GetComponent<IInteractable>();
                comp.Interact();
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.ActiveInventoryPanel();
        }
    }
}
