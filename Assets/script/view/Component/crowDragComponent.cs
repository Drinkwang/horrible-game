using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class crowDragComponent : MonoBehaviour
{


    public static crowDragComponent instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (instance == null) {

            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void OnCrowAni()
    {
        StartCoroutine("CrowAni", this);
    }

    IEnumerator CrowAni()
    {

        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds(1.8f);

        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 0));
        //StartCoroutine("CrowAni3", this);

        yield return new WaitForSeconds(1.8f);
        gameObject.SetActive(false);
        AppFactory.instances.changestate(Globelstate.state.start, true);
        // corw.GetComponent<PlayableDirector>().played += crowAni2;
    }




}
