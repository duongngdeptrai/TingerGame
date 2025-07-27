using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffects;
    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    void Start()
    {
        PlayBackgroundMusic();
    }
    public void PlayBackgroundMusic()
    {
        backgroundMusic.clip = backGroundClip;
        backgroundMusic.Play();
    }
    public void PlayJumpSound()
    {
        soundEffects.PlayOneShot(jumpClip);
    }
    public void PlayCoinSound()
    {
        soundEffects.PlayOneShot(coinClip);
    }
}
