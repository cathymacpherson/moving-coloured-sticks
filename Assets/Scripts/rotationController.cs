using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using UnityEngine.UI;

public class rotationController : MonoBehaviour
{

    GameObject csvFile;
    GameObject rightStickYellow;
    GameObject leftStickYellow;
    GameObject rightStickBlue;
    GameObject leftStickBlue;
    //Slider mySlider;
    List<string> stringList = new List<string>(); //stores the read in lines from the text file
     public int currentLine = 0;
     private string[] data;
     public string[] row;

       
void Start()
{
    
   leftStickYellow = GameObject.Find("/L_Stick_Yellow/L_Rotator");
    rightStickYellow = GameObject.Find("/R_Stick_Yellow/R_Rotator");

        leftStickBlue = GameObject.Find("/L_Stick_Blue/L_Rotator");
        rightStickBlue = GameObject.Find("/R_Stick_Blue/R_Rotator");


        //mySlider = GameObject.Find("Slider").GetComponent<Slider>();
       // mySlider.gameObject.SetActive(false);


        readCSV();
}


    void readCSV()
    {
        TextAsset rotationData = Resources.Load<TextAsset>("high"); //loads in data
        data = rotationData.text.Split('\n'); //splits the data into array by row
    } 

void runMovement()
    {
        currentLine++; //increases the line
       // if (currentLine >= data.Length)
        //    currentLine = 0; //loop the animation if it reaches the end
        row = data[currentLine].Split(','); //loops through data and splits data into array by comma
        
        for (int i = 0; i < data.Length - 1; i++)
        {
           // rightStickYellow.transform.eulerAngles = new Vector3(rightStickYellow.transform.eulerAngles.x, rightStickYellow.transform.eulerAngles.y, float.Parse(row[0])*20);
           // leftStickYellow.transform.eulerAngles = new Vector3(leftStickYellow.transform.eulerAngles.x, leftStickYellow.transform.eulerAngles.y, 0 - float.Parse(row[1])*20);

              rightStickBlue.transform.eulerAngles = new Vector3(rightStickBlue.transform.eulerAngles.x, rightStickBlue.transform.eulerAngles.y, 0 - float.Parse(row[1]) * 20);
              leftStickBlue.transform.eulerAngles = new Vector3(leftStickBlue.transform.eulerAngles.x, leftStickBlue.transform.eulerAngles.y,  float.Parse(row[0]) * 20);

        }
    }



void Update()
{
        
}

   
void FixedUpdate()
{
    runMovement(); 
}
}