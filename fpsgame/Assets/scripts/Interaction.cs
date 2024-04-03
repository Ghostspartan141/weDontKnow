using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Transform _selection;
    public float distanceFromObject = 5f;

    void Update()
    {
        if (_selection != null)
        {
            Debug.Log("not Looking at interactable");
            if(_selection.GetComponent<Interactable>() != null)
            {
                _selection.GetComponent<Interactable>().HideInteractable();
            }
            
            _selection = null;
        }

        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 
            distanceFromObject, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, 
            out hit, distanceFromObject))
        {
            var selection = hit.transform;

            Debug.Log(selection.gameObject.name);

            if(selection.GetComponent<Interactable>() != null)
            {
                selection.GetComponent<Interactable>().DisplayInteractable();
            }

            Debug.Log(selection.name);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("open attempt");
                if (selection.GetComponent<DoorInteractable>() != null)
                {
                    Debug.Log("open success");
                    selection.GetComponent<DoorInteractable>().DoorInteraction();
                }
            }

            _selection = selection;
        }
    }
}