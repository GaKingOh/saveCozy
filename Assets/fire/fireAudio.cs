using UnityEngine;

public class fireAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fireSound;

    private void Start()
    {
        audioSource.clip = fireSound;
        audioSource.Play();
    }

    public void OffSound()
    {
        audioSource.Stop();
    }
    public void OnSound()
    {
        audioSource.Play();
    }
}
