using System.Collections;
using System.Collections.Generic;
using BananaUtils.OnScreenDebugger.Scripts;
using UnityEngine;

public class InteractionSystemScript : MonoBehaviour
{
    [SerializeField] private float _interactionDistance;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private GameObject _playerCam;
    [SerializeField] private GameObject _interactionPopupObject;
    private RaycastHit _hit;
    private RaycastHit _interactableObjects;

    private void InteractionPopup(bool status)
    {
        _interactionPopupObject.SetActive(status);
    }
    
    private void Interact()
    {
        if (Physics.Raycast(_playerCam.transform.position, _playerCam.transform.forward, out _hit, _interactionDistance, _interactableLayer))
        {
            if (_hit.transform.GetComponent<IInteractable>() != null)
                _hit.transform.GetComponent<IInteractable>().Interact();
        }
    }

    private void InteractionPopup()
    {
        if (Physics.Raycast(_playerCam.transform.position, _playerCam.transform.forward, out _interactableObjects, _interactionDistance, _interactableLayer))
        {
            if (_interactableObjects.transform.GetComponent<IInteractable>() != null)
                InteractionPopup(true);
        }
        
        else
            InteractionPopup(false);
    }

    void Update()
    {
        InteractionPopup();
        
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }
}
