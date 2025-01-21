using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodDestructables : MonoBehaviour
{
    public void DestroyWall()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlayDestroy(gameObject);
    }
}