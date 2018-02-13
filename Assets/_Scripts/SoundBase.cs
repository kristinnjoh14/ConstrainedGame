using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundBase : MonoBehaviour
{
    public static SoundBase Instance;
    public AudioClip ingSplat;
    public AudioClip[] swooshes;
    public AudioClip trash;
    public AudioClip nom;
    public AudioClip eww;

    public AudioSource audioSource;

    public float pitch;

    List<AudioClip> clipsPlaying = new List<AudioClip>();

    //SoundBase.Instance.GetComponent<AudioSource>().PlayOneShot(clip);
    //SoundBase.Instance.PlaySound(SoundBase.Instance.timeOut);

    // Use this for initialization
    void Awake()
    {
        if (transform.parent == null)
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
        }
        audioSource = GetComponent<AudioSource>();
        pitch = audioSource.pitch;
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlaySoundsRandom(AudioClip[] clip)
    {
        SoundBase.Instance.PlaySound(clip[Random.Range(0, clip.Length)]);
    }

    public void PlayLimitSound(AudioClip clip)
    {
        if (clipsPlaying.IndexOf(clip) < 0)
        {
            clipsPlaying.Add(clip);
            PlaySound(clip);
            StartCoroutine(WaitForCompleteSound(clip));
        }
    }

    public void PlayLastSound(AudioClip clip)
    {
        if (clipsPlaying.IndexOf(clip) < 0)
        {
            clipsPlaying.Add(clip);
            PlaySound(clip);
            StartCoroutine(WaitForCompleteSound(clip));
            audioSource.Stop();
        }
    }

    IEnumerator WaitForCompleteSound(AudioClip clip)
    {
        yield return new WaitForSeconds(0.2f);
        clipsPlaying.Remove(clipsPlaying.Find(x => clip));
    }



    // Update is called once per frame
    void Update()
    {

    }
}
