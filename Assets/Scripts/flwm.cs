using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class flwm : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent nf;
    public Transform ply;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        nf.SetDestination(ply.position);
    }
}
