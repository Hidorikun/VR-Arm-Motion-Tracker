using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HandTracking : MonoBehaviour
{
    public string URL = "http://10.152.0.137:5000";
   

    private float x1;
    private float y1;
    private float z1;
    private float w1;

    private float x2;
    private float y2;
    private float z2;
    private float w2;

    private float x3;
    private float y3;
    private float z3;
    private float w3;

    public GameObject wrist;
    public GameObject wristOffset;
    public GameObject ellbow;
    public GameObject ellbowOffset;
    public GameObject shoulder;
    public GameObject shoulderOffset;
    public GameObject upperarmEnd;
    public GameObject forearmEnd;

    public GameObject firstPaddle; 
    public GameObject secondPaddle;

    public float force; 

    public string input;
    public string localInput;

    private int count = 0; 

    void Start()
    {
        DOTween.Init();
    }


    private Quaternion wristRotation = new Quaternion();
    private Quaternion ellbowRotation = new Quaternion();
    private Quaternion shoulderRotation = new Quaternion();
    
    Vector3 RadToDegree(Vector3 rotation)
    {
        return new Vector3(rotation.x * Mathf.Rad2Deg, rotation.y * Mathf.Rad2Deg, rotation.z * Mathf.Rad2Deg);
    }


    public void Straighten()
    {
        wristOffset.transform.localRotation = Quaternion.Inverse(wristRotation);
        ellbowOffset.transform.localRotation = Quaternion.Inverse(ellbowRotation);
        shoulderOffset.transform.localRotation = Quaternion.Inverse(shoulderRotation);

        Debug.Log("Straightened");
    }

    void SplitRotations(string rotatins)
    {
        string[] values = rotatins.Split(' ');

        float.TryParse(values[0], out x1);
        float.TryParse(values[1], out y1);
        float.TryParse(values[2], out z1);
        float.TryParse(values[3], out w1);

        float.TryParse(values[4], out x2);
        float.TryParse(values[5], out y2);
        float.TryParse(values[6], out z2);
        float.TryParse(values[7], out w2);

        float.TryParse(values[8], out x3);
        float.TryParse(values[9], out y3);
        float.TryParse(values[10], out z3);
        float.TryParse(values[11], out w3);

    }

    public void Rotate()
    {
        wristRotation = new Quaternion(x1, -z1, y1, w1);
        ellbowRotation = new Quaternion(x2, -z2, y2, w2);
        shoulderRotation = new Quaternion(x3, -z3, y3, w3);

        if (wristRotation != wrist.transform.localRotation)
        {
            count += 1;
            Debug.Log("COUNT INCREASED");
        }
        //wrist.transform.DORotate(wristRotation.ToEuler(), 0.0f);

        float speed = 0.01f * Time.deltaTime;

        //wrist.transform.DORotate(wristRotation.eulerAngles, speed);
        //ellbow.transform.DORotate(ellbowRotation.eulerAngles, speed);
        //shoulder.transform.DORotate(shoulderRotation.eulerAngles, speed);


        //wristOffset.transform.DOMove(forearmEnd.transform.position, speed);
        //ellbowOffset.transform.DOMove(upperarmEnd.transform.position, speed); 

        wrist.transform.localRotation = wristRotation;
        ellbow.transform.localRotation = ellbowRotation;
        shoulder.transform.localRotation = shoulderRotation;

        wristOffset.transform.position = forearmEnd.transform.position;
        ellbowOffset.transform.position = upperarmEnd.transform.position;
    }
    
    void ComputeForce()
    {
        Vector3 posDiff = firstPaddle.transform.position - secondPaddle.transform.position;
        Vector3 rotDiff = firstPaddle.transform.rotation.eulerAngles - secondPaddle.transform.rotation.eulerAngles;

        Debug.Log(posDiff + " " + rotDiff);

        force = Mathf.Abs(rotDiff.x) + Mathf.Abs(rotDiff.y) + Mathf.Abs(rotDiff.y); 
       

    }

    public int GetCount()
    {
        return count; 
    }

    public void ResetCount()
    {
        count = 0; 
    }

    void Update()
    {
       
        //StartCoroutine(GetText());


        //wristRotation = new Quaternion(y1, -x1, z1, -w1); // inversul rotatiei pe care o vreau 
        //Rotate();

        lock (input)
        {
            localInput = input; 
        }

        if (localInput != "")
        {

            secondPaddle.transform.position = firstPaddle.transform.position;
            secondPaddle.transform.rotation = firstPaddle.transform.rotation; 

            SplitRotations(localInput);
            Rotate();

            ComputeForce(); 
        }
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(this.URL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("ERROR");
            Debug.Log(www.error);
        }
        else
        {        
            //Debug.Log(www.downloadHandler.text.ToString());

            string response = www.downloadHandler.text;

            //Debug.Log(response);

            if (response != "")
            {
                SplitRotations(response);
            }
            else {
              Debug.Log("no message");
            }
        }
    }
}
