using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BackupHttp : MonoBehaviour
{
    //public string URL = "http://10.152.0.137:5000";
    //public float speed = 5f;
    //public int arrLen = 5;
    //private float sampleSize = 1f /256f;
    //private float beta = 0.1f;

    //private MadgwickAHRS madgwickAHRS;

    //private float x1;
    //private float y1;
    //private float z1;
    //private float w1;

    //private float x2;
    //private float y2;
    //private float z2;
    //private float w2;

    //private float x3;
    //private float y3;
    //private float z3;
    //private float w3;

    //public GameObject wrist;
    //public GameObject wristOffset;
    //public GameObject ellbow;
    //public GameObject ellbowOffset;
    //public GameObject shoulder;
    //public GameObject shoulderOffset;

    //private float flag; 


    //private Vector3 nextRot;

    //private Vector3[] angleBuffer;
    //private int bufIndex = 0;


    //void SetRotation()
    //{
    //    Vector3 newRot = new Vector3((float)y, (float)z, (float)-x);
    //    if (bufIndex < arrLen - 1)
    //    {
    //        angleBuffer[bufIndex] = newRot;
    //        bufIndex++;
    //    }
    //    else
    //    {
    //        var newArray = new Vector3[angleBuffer.Length];
    //        Array.Copy(angleBuffer, 1, newArray, 0, angleBuffer.Length - 1);
    //        newArray[angleBuffer.Length - 1] = newRot;

    //        angleBuffer = newArray;

    //        float X = 0f, Z = 0f, Y = 0f;

    //        for (int i = 0; i < angleBuffer.Length; i++)
    //        {
    //            X += angleBuffer[i].x;
    //            Z += angleBuffer[i].z;
    //            Y += angleBuffer[i].y;
    //        }

    //        X /= (float)angleBuffer.Length;
    //        Z /= (float)angleBuffer.Length;
    //        Y /= (float)angleBuffer.Length;

    //        nextRot = new Vector3(-X, Y, Z);
    //    }
    //}

    //void Start()
    //{
        //madgwickAHRS = new MadgwickAHRS(sampleSize, beta);
        //angleBuffer = new Vector3[arrLen];
    //}


    //private Quaternion wristRotation = new Quaternion();
    //private Quaternion ellbowRotation = new Quaternion();
    //private Quaternion shoulderRotation = new Quaternion();


    //void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        //wristOffset.transform.localRotation = Quaternion.Inverse(wristRotation);
    //        ellbowOffset.transform.localRotation = Quaternion.Inverse(ellbowRotation);
    //        //shoulderOffset.transform.localRotation = Quaternion.Inverse(shoulderRotation);

    //        Debug.Log("Straightened");
    //    }

    //    StartCoroutine(GetText());
    //    //madgwickAHRS.Update(gx, gy, gz, ax, ay, az);

    //    //q1 = new Quaternion(y1, -x1, z1, -w1); // inversul rotatiei pe care o vreau 

    //    //wristRotation = new Quaternion(x1, -z1, y1, w1);
    //    ellbowRotation = new Quaternion(x2, -z2, y2, w2);
    //    //shoulderRotation = new Quaternion(x3, -z3, y3, w3);

    //    //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    //    //wrist.transform.rotation = getRotation(q1, offset1);
    //    //Debug.Log(q1.x + " " + q1.y + " " + q1.z + " " + q1.w);
    //    //Debug.Log("q1 euler " + Quaternion.ToEulerAngles(q1).ToString());
    //    //Debug.Log("offset1 " + Quaternion.ToEulerAngles(offset1).ToString());

    //    //wrist.transform.rotation.SetEulerAngles(Quaternion.ToEulerAngles(q1) - Quaternion.ToEulerAngles(offset1));



    //    //Vector3 eu = wrist.transform.localEulerAngles;
    //    //eu.z = 0;
    //    //wrist.transform.localEulerAngles = eu;

    //    //wrist.transform.localRotation = wristRotation;
    //    Debug.Log(ellbow.transform.localEulerAngles);

    //    // ellbow.transform.localRotation = ellbowRotation;
    //    //Debug.Log(ellbow.transform.localEulerAngles);
    //    //Debug.Log(ellbow.transform.eulerAngles);

    //    //shoulder.transform.localRotation = shoulderRotation;

    //    //SetRotation();
    //    //nextRot = new Vector3(-x, y, -z);
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(nextRot), Time.deltaTime * speed);
    //}

    //IEnumerator GetText()
    //{
    //    UnityWebRequest www = UnityWebRequest.Get(this.URL);
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log("ERROR");
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        //// Show results as text
    //        //Debug.Log(www.downloadHandler.text.ToString());

    //        string response = www.downloadHandler.text;

    //        //Debug.Log(response);

    //        if (response != "")
    //        {
    //            string[] values = response.Split(' ');

    //            //float.TryParse(values[0], out y);
    //            //float.TryParse(values[1], out z);
    //            //float.TryParse(values[2], out x);

    //            //quaternion
    //            float.TryParse(values[0], out x1);
    //            float.TryParse(values[1], out y1);
    //            float.TryParse(values[2], out z1);
    //            float.TryParse(values[3], out w1);

    //            float.TryParse(values[4], out x2);
    //            float.TryParse(values[5], out y2);
    //            float.TryParse(values[6], out z2);
    //            float.TryParse(values[7], out w2);

    //            float.TryParse(values[8], out x3);
    //            float.TryParse(values[9], out y3);
    //            float.TryParse(values[10], out z3);
    //            float.TryParse(values[11], out w3);

    //            //if (flag > 0)
    //            //{
    //            //    x = 180 - x;
    //            //}
    //            //float.TryParse(values[0], out gx);
    //            //float.TryParse(values[1], out gy);
    //            //float.TryParse(values[2], out gz);
    //            //float.TryParse(values[3], out ax);
    //            //float.TryParse(values[4], out ay);
    //            //float.TryParse(values[5], out az);

    //            //Debug.Log("gx:" + gx + " gy:" + gy + " gz:" + gz + "ax:" + ax + " ay:" + ay + " az:" + az);
    //            //Debug.Log("x:" + x1 + " y:" + y2 + " z: " + z3); 

    //        }
    //        else
    //        {
    //            Debug.Log("no message");
    //        }
    //    }
    //}
}
