using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreditTextControlelr : MonoBehaviour {

    //Jimi Stine's Zapper
    //By Jimi Stine 
    //Hello World

    public string FullTextBox;
    public float IntervalPerCharMin;
    public float IntervalPerCharMax;
    public float StoreStartTime;
    public bool IsStarted = false;
    string[] ConvertedText; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        if (Input.GetKeyDown(KeyCode.P))
//        {
//            StartCoroutine(DelayPrintNext());
//        }
	}

    public void Start_Typing()
    {
        StartCoroutine(DelayPrintNext());
    }
    
    public void Start_Deleting()
    {
        StartCoroutine(DelayDeleteNext());
    }

    public void StartTextTime()
    {
        StoreStartTime = Time.time;
    }
    public void ConvertStringToCharacters()

    {
        //ConvertedText = new string[FullTextBox.Length];
        //for (int i = 0; i < FullTextBox.Length; i++)
        //{
        //    ConvertedText[i] = System.Convert.ToString(FullTextBox[i]);
        //}

        //foreach(string x in ConvertedText)
        //{
        //    if (x == "]")
        //    {
        //        StartCoroutine(DelayPrintNext(x));
        //        //Debug.Log("\n");
        //        //gameObject.GetComponent<Text>().text += "\n";
        //    }
        //    else
        //    {
        //        StartCoroutine(DelayPrintNext(x));
        //        //Debug.Log(x);
        //        //gameObject.GetComponent<Text>().text += x;
        //    }
        //}
    }
    IEnumerator DelayPrintNext()
    {
        Debug.Log("Start");
        
        ConvertedText = new string[FullTextBox.Length];

        for (int i = 0; i < FullTextBox.Length; i++)
        {
            ConvertedText[i] = System.Convert.ToString(FullTextBox[i]);
        }

        foreach (string x in ConvertedText)
        {
            if (x == "]")
            {
                yield return new WaitForSeconds(Random.Range(IntervalPerCharMin, IntervalPerCharMax));
                //StartCoroutine(DelayPrintNext(x));
                //Debug.Log("\n");
                gameObject.GetComponent<Text>().text += "\n";
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(IntervalPerCharMin, IntervalPerCharMax));
                //StartCoroutine(DelayPrintNext(x));
                //Debug.Log(x);
                gameObject.GetComponent<Text>().text += x;
            }
        }
        Debug.Log("Finish");
    }
    
    IEnumerator DelayDeleteNext()
    {
        Debug.Log("Start");
        
        ConvertedText = new string[FullTextBox.Length];

        for (int i = 0; i < FullTextBox.Length; i++)
        {
            ConvertedText[i] = System.Convert.ToString(FullTextBox[i]);
        }

        foreach (string x in ConvertedText)
        {
            if (x == "]")
            {
                yield return new WaitForSeconds(Random.Range(IntervalPerCharMin, IntervalPerCharMax));
                //StartCoroutine(DelayPrintNext(x));
                //Debug.Log("\n");
                gameObject.GetComponent<Text>().text += "\n";
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(IntervalPerCharMin, IntervalPerCharMax));
                //StartCoroutine(DelayPrintNext(x));
                //Debug.Log(x);
                gameObject.GetComponent<Text>().text.Reverse();
            }
        }
        Debug.Log("Finish");
    }
}
