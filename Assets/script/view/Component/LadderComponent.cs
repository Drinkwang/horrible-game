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

        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 6));

        AppFactory.instances.changestate(Globelstate.state.load, true);
    
        CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().time = CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().duration;
        CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().playableGraph.GetRootPlayable(0).SetSpeed(-1);
            CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().Play();
        //  CinemacineComponent.Instance().cinemacineList[6].GetComponent<PlayableDirector>().sp;
        StartCoroutine(moveLadder());
    }
    IEnumerator moveLadder() {
        yield return new WaitForSeconds(5f);
        AppFactory.instances.setPosition(downTransform);
        //hiui.instance.setPlayerPosition(downTransform);

        yield return new WaitForSeconds(0.5f);
        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 0));

        yield return new WaitForSeconds(2f);
        AppFactory.instances.changestate(Globelstate.state.start, true);


    }


}
