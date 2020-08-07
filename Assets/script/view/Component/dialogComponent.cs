using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class dialogComponent : MonoBehaviour
{
    public static dialogComponent instance;
    private List<SingledialogText> dialogues;
    private Text saying;
    private static int num = 0;
    public AudioSource lastaudio;


    void Awake()
    {
        instance = this;
        saying = this.GetComponent<Text>();
    }
    // Use this for initializaWtion
    void Start()
    {


    }

    public void add(List<SingledialogText> a)
    {
        Audomanage.instance.Stop();
        dialogues = a;

        //	a[a[0]];

    }
    public void clear()
    {

        Audomanage.instance.StopSoundEffect(lastaudio);
        Sayingproxy.instances().clear();

    }
    void Update()
    {
    }


    public void todo(Befunction t = null)
    {
        if (dialogues.Count != 0)
        {
            if (dialogues[0].t != null)
                t = dialogues[0].t;
            else t = new Befunction("who know");
            t.A += tempFunction;
            if (AppFactory.instances.mylanguage == Globelstate.language.china)
            {
                textchange(dialogues[0].ChineseVersion.ToString());
                if (dialogues[0].ChineseAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t);
                else lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].ChineseAC, dialogues[0].talkobj.transform, t);
            }
            else if (AppFactory.instances.mylanguage == Globelstate.language.english)
            {
                textchange(dialogues[0].EnglishVersion.ToString());
                if (dialogues[0].EnglishAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t);
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].EnglishAC, dialogues[0].talkobj.transform, t);
            }
            else if (AppFactory.instances.mylanguage == Globelstate.language.japanense)
            {
                textchange(dialogues[0].JapanVersion.ToString());
                if (dialogues[0].JapanAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t);
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].JapanAC, dialogues[0].talkobj.transform, t);
            }
            dialogues.RemoveAt(0);
        }
        else
        {
            saying.text = "";
            //this.transform.Find("black").gameObject.SetActive(false);
            //       AppFactory.instances.playercontrolpower.enabled = true;
        }


    }

    void textchange(string a)
    {
        saying.text = a;
        num++;
    }
    void tempFunction()
    {
        AppFactory.instances.viewTodo(new Observer(Cmd.dialog));

    }
}



/*	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.pointerId == -1) {
			Debug.Log ("Left Mouse Clicked");

		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{if (one == false) {
			t =	this.GetComponent<Button> ().onClick.GetPersistentTarget (0)as GameObject;
			t.SetActive (true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{t.SetActive (false);
		Debug.Log("Pointer Exit");
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (two == false) {
			Debug.Log ("Pointer Down");
			s.enabled = true;
			issaying = true;

			title.SetActive (false);
			task.SetActive (true);
			this.GetComponent<Text>().enabled=false;
			two = true;}
	}
*/



