using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class nvbk : MonoBehaviour
{
    [SerializeField] NavMeshSurface[] nv;

    // Start is called before the first frame update
    void Start()
    {   
        for (int i = 0; i< nv.Length;i++)
            {
            nv[i].BuildNavMesh();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
