using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    MusicManager Instance;

    [SerializeField] List<AudioClip> music;

    private AudioSource musicSource;
    private float musicDuration = 65f;
    private int currentTrackIndex = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();

        if (music.Count > 0)
        {
            StartCoroutine(PlayPlaylist());
        }
    }

    private IEnumerator PlayPlaylist()
    {
        while (true)
        {
            AudioClip currentClip = music[currentTrackIndex];
            musicSource.clip = currentClip;
            musicSource.loop = true;
            musicSource.Play();

            yield return new WaitForSeconds(musicDuration);

            musicSource.Stop();
            currentTrackIndex = (currentTrackIndex + 1) % music.Count;
        }
    }


}
