using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    //Determine which spectrum data will trigger a beat
    public float bias;
    //Determines the minimum interval between each beat
    public float timeStep;
    //Determines how much the visulation complete
    public float timeToBeat;
    //Determines how fast the object comes to rest after a beat
    public float restSmoothTime;

    //Determine if the value went above or below the bias in the current frame 
    private float previousAudioValue;
    private float audioValue;
    //Keeps track of the timeStep interval
    private float timer;
    //Keeps track of whether or not the sync object in beat state
    protected bool isBeat;
    void Start()
    {
        
    }
    void Update()
    {
        OnUpdate();
    }
    public virtual void OnUpdate()
    {
        previousAudioValue = audioValue;
        audioValue = AudioSpectrum.spectrumValue;

        if(previousAudioValue > bias && audioValue <= bias)
        {
            if(timer > timeStep)
            {
                OnBeat();
            }
        }
        if(previousAudioValue <= bias && audioValue > bias)
        {
            if(timer > timeStep)
            {
                OnBeat();
            }
        }
        timer += Time.deltaTime;
    }
    public virtual void OnBeat()
    {
        timer = 0;
        isBeat = true;
    }
}
