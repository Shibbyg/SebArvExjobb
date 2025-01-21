using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioAnimationPlay : MonoBehaviour
{
    public EventReference FMODEventRef;
    EventInstance FMODEvent;

    public string FMODParameterName;
    public void PlaySound(int parameterValue)
    {
        FMODEvent = RuntimeManager.CreateInstance(FMODEventRef);
        RuntimeManager.AttachInstanceToGameObject(FMODEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODEvent.setParameterByName(FMODParameterName, parameterValue);
        FMODEvent.start();
        FMODEvent.release();
    }
}
