using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public AudioClip[] explosionSounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (explosionSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, explosionSounds.Length);

            audioSource.clip = explosionSounds[randomIndex];
            audioSource.Play();
        }
    }
}
