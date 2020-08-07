using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class hiui : MonoBehaviour
    {
        public GameObject ui;
        public Material bili;
        public GameObject interactionui;
        public GameObject firstCatch;
        public MouseLook mouse;
        public middleLayer a;
        public allsave every;
        private FirstPersonController firstperson;

        public static hiui instance
        {
            get; private set;
        }
        void inter()
        {//Debug.Log ("helloworld");
            if (AppFactory.instances.eventTodo("第一次交互") == false)
            {
                interactionui.GetComponent<Image>().material = bili;
            }
            else 
            {
                firstCatch.SetActive(true);
                firstCatch.GetComponent<Animator>().SetTrigger("trigger");
                StartCoroutine("onFirstCatch", 5.5f);

            }


        }
        IEnumerator onFirstCatch(float t)
        {

            yield return new WaitForSeconds(t);
            firstCatch.SetActive(false);
            interactionui.SetActive(true);
        }
        void exit()
        {
            interactionui.GetComponent<Image>().material = null;
            //			Debug.Log ("helloworld");
        }
        void Awake()
        {
            interactionui.SetActive(false);
            firstperson = this.gameObject.GetComponent<FirstPersonController>();
            a.onInteractive += inter;
            instance = this;
            a.exitaction += exit;
            a.OnMousePause += mousepause;
            a.OnMouseRun += mouserun;
            a.OnSetSpeed += setSpeed;
            a.OnChangeCamera += changeCamera;
            firstperson.changeCamera(0,CinemacineComponent.Instance().CinemacineMain);
        }

        // Use this for initialization
        public void objecvisble(GameObject o)
        {
            if (o != null)
            {

                o.SetActive(true);
            }
            else
            {
                o.SetActive(false);
            }
        }

        void Start()
        {
            mousepause();

        }
        void changeCamera(int i) {
            if (i != 0)
            {    mouse = new MouseLook();
                mouse.SetCursorLock(true); }
            firstperson.changeCamera(i,CinemacineComponent.Instance().CinemacineMain);
        }

        void mousepause()
        {
            interactionui.SetActive(false);
            firstperson.enabled = false;
          //  firstperson.changeCamera(0,CinemacineComponent.Instance().CinemacineMain);
            // transform.GetChild(0).transform.rotation.eulerAngles.Set(0,0,0);
            //    .eulerAngles = new Vector3(0, 0, 0);

            mouse = new MouseLook();
            mouse.SetCursorLock(false);
            //     Debug.Log("2222");
        }
        void mouserun()
        {
            //AppFactory.instances.Todo();
            //
         //  firstperson.changeCamera(0,CinemacineComponent.Instance().CinemacineMain);
            firstperson.enabled = true;
            interactionui.SetActive(true);

        }
        // Update is called once per frame
        void Update()
        {

        }

        public void ongamestart()
        {
            ui.SetActive(false);
            AppFactory.instances.changestate(Globelstate.state.start);
            firstperson.enabled = true;
            /* firstperson.m_RunSpeed = 0.1f;
               firstperson.m_JumpSpeed = 0.1f;
               firstperson.m_WalkSpeed = 0.05f;*/
            setSpeed(0.1f, 0.1f, 0.05f);
        }
        void setSpeed(float walkspeed, float runspeed, float jumpspeed)
        {
            firstperson.m_RunSpeed = runspeed;
            firstperson.m_JumpSpeed = jumpspeed;
            firstperson.m_WalkSpeed = walkspeed;
        }
    }
}