using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DistanceTransfer : MonoBehaviour
{
    public string eventTag;
    public string paraName;
    public float defaultValue;

    private StudioEventEmitter emitter;
    private float distanceToPlayer;
    private Transform playerTransform;
    private bool CountDistance = false;


    private void Start()
    { 
        emitter = GameObject.FindGameObjectWithTag(eventTag).GetComponent<StudioEventEmitter>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (CountDistance)
        {
            distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        
            emitter.SetParameter(paraName, distanceToPlayer);
        }
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
         CountDistance = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      //  if (col.CompareTag("Player"))
        {
            CountDistance = false;
            distanceToPlayer = defaultValue;
        }
    }
}
