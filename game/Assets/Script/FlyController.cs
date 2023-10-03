using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
//
//
public class FlyController : MonoBehaviour
{
    private GameObject myTargets;
    public bool moveTarget;
    private GameObject myCamera;
    private GameObject end;
    private GameObject bat;
    private GameObject wrong;

    private UpdateText z;
    public GameObject a;

    private Vector3 myFromPosition;
    private Vector3 myToPosition;
    private Quaternion to;

    public Vector3 goal;

    private Quaternion myFromRotation;
    private Quaternion myToRotation;

    public Button button;
    public bool ifClicked;

    public bool ifHit;
    public bool ifMissed;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        myTargets = GameObject.FindWithTag("Target");
        moveTarget = false;
        myCamera = GameObject.FindWithTag("Player");
        end = GameObject.FindWithTag("End");
        wrong = GameObject.FindWithTag("wrong");
        myTargets.GetComponent<Renderer>().enabled = false;
        bat = GameObject.FindWithTag("Bat");
        button = button.GetComponent<Button>();
        ifClicked = false;
        goal.z = myCamera.transform.position.z;
        ifHit = false;
        z = a.GetComponent<UpdateText>();
        ifMissed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveTarget)
        {
          button.onClick.AddListener(TaskOnClick);
          if (ifClicked == true){
            button.gameObject.SetActive(false);
            initiateTarget();
          }
        }
        else
        {
          if(ifHit == false)
          {
            if(myTargets.transform.position.z > goal.z +.05){
              myTargets.transform.position = Vector3.Lerp(myFromPosition, myToPosition, Time.deltaTime * speed);
              myFromPosition = myTargets.transform.position;

              myTargets.transform.rotation = Quaternion.Slerp(myFromRotation, myToRotation, Time.deltaTime * speed);
              myFromRotation = myTargets.transform.rotation;
              if (myTargets.transform.position.z < goal.z + .15)
              {
                ifMissed = true;
              }
            }
            else
            {
              stopTarget();
            }
          }
          else
          {
            if(myTargets.transform.position.z < goal.z - 5.0f){
              myTargets.transform.position = Vector3.Lerp(myFromPosition, myToPosition, Time.deltaTime * speed);
              myFromPosition = myTargets.transform.position;

              myTargets.transform.rotation = Quaternion.Slerp(myFromRotation, myToRotation, Time.deltaTime * speed);
              myFromRotation = myTargets.transform.rotation;
            }
            else
            {
              stopTarget();
            }
          }
        }
    }

    void TaskOnClick()
    {
      ifClicked = true;
    }

    public void OnTriggerEnter(Collider target)
    {
      if (target.gameObject.tag.Equals("Bat") == true)
        {
          ifHit = true;
          Debug.Log(z.ifRight);
          if (z.ifRight == false)
          {
            myToPosition = wrong.transform.position;
            speed = 0.5f;
            goal.z = wrong.transform.position.z;
          }
          else
          {
            myToPosition = end.transform.position;
            speed = 0.5f;
            goal.z = end.transform.position.z;
          }
        }
    }


    void initiateTarget()
    {
      ifMissed = false;
      goal.z = myCamera.transform.position.z;
      ifHit = false;
      myTargets.GetComponent<Renderer>().enabled = true;
      speed = 2f;
      myToPosition = myCamera.transform.position;
      myFromPosition = myToPosition + 10 * myCamera.transform.forward;

      myFromRotation = new Quaternion(0, 0, 1, 0);

      switch (Random.Range(0, 3))
      {
        case (0):
            myToRotation = new Quaternion(0, 0, 0, 1);
            break;
        case (1):
            myToRotation = new Quaternion(0, 1, 0, 0);
            break;
        case (2):
            myToRotation = new Quaternion(0, 0, 0, -1);
            break;
        default:
            myToRotation = new Quaternion(0, 0, 0, 1);
            break;
      }
      moveTarget = true;
    }

    void stopTarget()
    {
      button.gameObject.SetActive(true);
      ifClicked = false;
      ifHit = false;
      myTargets.GetComponent<Renderer>().enabled = false;
      myTargets.transform.position = new Vector3(0, 0, 0);
      moveTarget = false;
    }
}
