using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _video;
    [SerializeField] GameObject _sphereToSpawn;
    [SerializeField] AudioSource _audioSource;

    public void Interact()
    {
        Debug.Log("Interacted with button!");
        if (_video != null)
        {
            _video.SetActive(true);
        }
        if (_sphereToSpawn != null)
        {
            for (int i = 0; i < 100; i++)
                Instantiate(_sphereToSpawn, transform.position + (Vector3.up + Vector3.forward) * 2, Quaternion.identity);
        }
        if (_audioSource != null)
        {
            _audioSource.Stop();
            _audioSource.Play();
        }
    }
}
