using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityStandardAssets.Characters.FirstPerson;

public class LadderComponent : MonoBehaviour
{


    public static LadderComponent instance;
    public Transform downTransform;
    public Transform upTransfrom;

   // public bool isUp=false;
   // public PlayableDirector tempDirector;
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

    public void MoveByLadder() {

        AppFactory.instances.changestate(Globelstate.state.load, true);
        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 6));
        bool isUp= AppFactory.instances.adjustPlayerIsDown();
        if (isUp == false)
        {

            CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().time = 0;

            CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().Play();
            //  CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().sp;
            StartCoroutine(moveLadder(isUp));
        }
        else {

            CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().time = CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().duration;
            StartCoroutine(tRewind(isUp));
        }
 
    }


    public IEnumerator tRewind(bool isUp)
    {
        
        yield return new WaitForSeconds(0.001f * Time.deltaTime);
        PlayableDirector Director = CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>();
        Director.time -= 1.0f * Time.deltaTime;  //1.0f是倒帶速度
        Director.Evaluate();
        if (Director.time < 0f)
        {
            Director.time = 0f;
            Director.Evaluate();
            StartCoroutine(moveLadder(isUp));
        }
        else
        {

            StartCoroutine("tRewind",isUp);
        }
    }

    IEnumerator moveLadder(bool isup) {

        if (isup == false) {
            yield return new WaitForSeconds(5f);
            AppFactory.instances.setPosition(downTransform);
        }

        else {

            AppFactory.instances.setPosition(upTransfrom);
        }
        //hiui.instance.setPlayerPosition(downTransform);

   
        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 0));
       // isUp = !isUp;
        yield return new WaitForSeconds(0.5f);
        AppFactory.instances.changestate(Globelstate.state.start, true);

     
    }



}
