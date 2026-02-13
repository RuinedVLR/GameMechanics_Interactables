using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCube : MonoBehaviour, IInteractable
{
    Rigidbody _rb;

    [SerializeField] private float _forceAmountOnInteract;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        Debug.Log("Interacted with physics cube!");
        if (_rb == null) return;

        Debug.Log("Applying force to physics cube!");
        _rb.AddForce(Vector3.up * _forceAmountOnInteract);
    }
}
