using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateText : MonoBehaviour
{
    private FlyController y;
    public GameObject x;
    public GameObject changeObjects;
    //public var random;
    public TextMesh myText;
    public GameObject equation;
    public TextMesh answerText;
    public int val1;
    public int val2;
    public int answer;
    public bool ifHit;
    private GameObject bat;
    private bool newEquation;
    public int pitch;
    public int strike;
    public int i;
    public bool ifStrike;
    public bool pitchNum;
    public bool ifRight;


    // Start is called before the first frame update
    void Start()
    {
      y = x.GetComponent<FlyController>();

      changeObjects = GameObject.FindWithTag("Change");
      myText = GameObject.Find("Text").GetComponent<TextMesh>();
      equation = GameObject.FindWithTag("Equation");
      answerText = GameObject.Find("Answer").GetComponent<TextMesh>();
      changeObjects.GetComponent<Renderer>().enabled = false;
      equation.GetComponent<Renderer>().enabled = false;
      changeObjects.transform.position = new Vector3(5, 5, -13);
      newEquation = true;
      pitch = 0;
      strike = 0;
      i = 2;
      ifStrike = false;
      pitchNum = true;
      ifRight = false;

      //bat = GameObject.FindWithTag("Bat");
      //myText.text = "Play Ball";
      //random = new Random();

    }
    /*void OnTriggerEnter(Collider target)
    {
      if (target.gameObject.tag.Equals("Bat") == true)
        {
          ifHit = true;

        }
        else{
        ifHit=false;
        }
    }*/

    void setEquation()
    {
      val1 =  Random.Range(1,20);
      val2 =  Random.Range(1,20);
      newEquation = false;
    }


    // Update is called once per frame
    void Update()
    {
      if (y.moveTarget == false)
      {
        ifRight = false;
        if (ifStrike == true)
        {
          strike++;
          ifStrike = false;
        }
        changeObjects.GetComponent<Renderer>().enabled = false;
        if (newEquation == true)
        {
          setEquation();
          i = 2;
          strike = 0;
        }
        else
        {
          if (pitchNum == true)
          {
            i = i - 1;
            pitchNum = false;
          }
        }
        myText.text = "" + val1 + " + "+ val2;
        changeObjects.GetComponent<Renderer>().enabled = true;
        equation.GetComponent<Renderer>().enabled = false;
      }
      else
      {
        pitchNum = true;
        answer = val1+val2;
        pitch = answer - i;
        if(answer == pitch)
        {
          ifRight = true;
        }
        else
        {
          ifRight = false;
        }
        answerText.text = "" + pitch;
        equation.GetComponent<Renderer>().enabled = true;
        if (y.ifHit==true && answer == pitch) {
            myText.text = "HOMERUN";
            changeObjects.transform.position = new Vector3(5, 5, -13);
            newEquation = true;
            ifStrike = false;
        }
        else{
          if(strike >= 3){
              myText.text = "Out";
              changeObjects.transform.position = new Vector3(5, 5, -13);
              newEquation = true;
          }
          else
          {
            if((y.ifHit==true && answer != pitch)){
              myText.text = "Strike";
              changeObjects.transform.position = new Vector3(5, 5, -13);
              ifStrike = true;
            }
            if (y.ifHit!=true && answer == pitch){
              if(y.ifMissed == true)
              {
                myText.text = "Out!";
                newEquation = true;
                changeObjects.transform.position = new Vector3(5, 5, -13);
                ifStrike = true;
              }
            }
          }
        }
      }


    // if(Ball collides on bat and is right)
//    if (Input.GetMouseButtonDown(0) && answer = pitch) {
//     changeObjects.transform.position = new Vector3(5, -100, -13);
//
//   }else{
   // if(Ball collides on bat and is wrong)
  // }
//    if (Input.GetMouseButtonDown(1)) {
//     changeObjects.transform.position = new Vector3(5, -100, -13);
//
//   }

    }
}

//Get a random equation of 2 numbers and add them together.
// Set answer to the answer of the equation
// Set pitch to value that may or may not be the answer
//If value is right then transfrom to say homerun
//If value is wrong then transform "X" text to above homeplate
