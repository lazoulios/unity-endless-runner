using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicSource1;
    [SerializeField] public AudioSource musicSource2;

    public AudioClip background1;
    public AudioClip background2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Random.value < .5)
        {
            musicSource1.Play();
        }
        else
        {
            musicSource2.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopMusic()
    {
        if (musicSource1.isPlaying)
            musicSource1.Stop();
        if (musicSource2.isPlaying)
            musicSource2.Stop();
    }
}
