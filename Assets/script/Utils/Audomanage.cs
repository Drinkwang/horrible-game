using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Audomanage : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public static Audomanage instance;
    private AudioSource bg;
    public AudioSource huhu;
    public Transform playertransfrom;

    // public Transform playervector;
    //  public Befunction  playafterAudio;

    // Use this for initialization
    private void Awake()
    {
        bg = transform.Find("bg").GetComponent<AudioSource>();
        // sound = transform.Find("sound").GetComponent<AudioSource>();
        if (instance == null)
        { instance = this; }
        reloadclip();

    }

    internal void Stop()
    {

          StopAllCoroutines();


    }

    public void playHuHu(AudioClip clip, Vector3 position, float volume = 1.0f, bool t = true)
    {

        huhu.clip = clip;
        huhu.spatialBlend = 1f;
        huhu.volume = volume;
        if (t == true)
            huhu.Play();
        else
            huhu.Stop();
    }
    public void reloadclip()
    {
        Object[] objects = Resources.LoadAll("sound", typeof(AudioClip));
        foreach (Object o in objects)
        { audioClips.Add(o as AudioClip); }

    }
    public void OnPlay(string p, Transform obj = null)
    {
        if (obj == null)
            obj = playertransfrom;


        foreach (AudioClip i in audioClips)
        {
            if (i.name == p)
            {
                PlayClipAtPoint(i, obj.position);

            }

        }
    }
    public AudioSource OnPlay(float value = 0.5f, AudioClip i = null, Transform obj = null, Befunction callback = null,int res=0,List<int> resG=null,float delay=0)
    {
        if (obj == null)
            obj = playertransfrom;

        AudioSource last;

        if (i != null)
        {
            last = PlayClipAtPoint(i, obj.position, value);
            StartCoroutine(Delayedcallback(i.length+delay, res,resG,callback));
        }
        else
        {
            StartCoroutine(Delayedcallback(5.0f+delay, res, resG, callback));
            last = null;
        }

        return last;

    }
    private IEnumerator Delayedcallback(float time, int res,List<int>resG,Befunction callback)
    {
        yield return new WaitForSeconds(time);
        callback.runa(res,resG);
    }
    public void reloadbg(string a)
    {
        bg.clip = Resources.Load<AudioClip>(a);
        bg.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static AudioSource PlayClipAtPoint(AudioClip clip, Vector3 position, float volume = 1f)
    {
        GameObject gameObject = new GameObject("One shot audio");
        gameObject.transform.position = position;
        AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        audioSource.clip = clip;
        audioSource.spatialBlend = 1f;
        audioSource.volume = volume;
        audioSource.maxDistance = 3000;
        audioSource.Play();
        Object.Destroy(gameObject, clip.length * ((Time.timeScale >= 0.01f) ? Time.timeScale : 0.01f));
        return audioSource;
    }

    public void StopSoundEffect(AudioSource audio)
    {
        if (audio == null)
        {
            return;
        }

        if (audio.enabled)
        {
            audio.enabled = false;
        }
    }


}
