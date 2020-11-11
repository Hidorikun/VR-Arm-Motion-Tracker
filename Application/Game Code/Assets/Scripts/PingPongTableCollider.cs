using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongTableCollider : MonoBehaviour
{

    void SetChildrenMeshCollider()
    {
        Stack<Transform> stack = new Stack<Transform>();
        Transform t; 

        stack.Push(transform); 

        while (stack.Count != 0)
        {
            t = stack.Pop();
            Debug.Log(t.gameObject.name);
            foreach (Transform childObject in t)
            {
                stack.Push(childObject);
                MeshFilter meshFilter = childObject.gameObject.GetComponent<MeshFilter>();
                
                if (meshFilter != null)
                {
                    Mesh mesh = meshFilter.mesh;

                    if (mesh != null)
                    {
                        MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();
                        meshCollider.sharedMesh = mesh;
                    }
                }
               
            }
        }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        SetChildrenMeshCollider(); 

    }

}
