using TMPro;
using UnityEngine;

public class RaycastInteractableDetector : MonoBehaviour
{
    [SerializeField] float _raycastDistance;

    [SerializeField] LayerMask _layerMask;

    [SerializeField] Transform _xFormToRaycastFrom;

    private void Update()
    {
        if (_xFormToRaycastFrom == null) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;

        if (Physics.Raycast(
            origin: _xFormToRaycastFrom.position,
            direction: _xFormToRaycastFrom.forward,
            hitInfo: out RaycastHit hit,
            maxDistance: _raycastDistance,
            layerMask: _layerMask
            ))
        {
            GameObject hitGO = hit.collider.gameObject;
            if(hitGO.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                Debug.Log("Pressed E");
                interactable.Interact();
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            from: _xFormToRaycastFrom.position,
            to: _xFormToRaycastFrom.position + _xFormToRaycastFrom.forward * _raycastDistance
            );
    }
}
