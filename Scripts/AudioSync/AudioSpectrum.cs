using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public static float spectrumValue {get; private set;}
    private float[] audioSpectrum;

    // Start is called before the first frame update
    void Start()
    {
        audioSpectrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(audioSpectrum, 0, FFTWindow.Hamming);

        if(audioSpectrum != null && audioSpectrum.Length > 0)
        {
            //Assign Generalized spectrum value to the first element in the array of data
            spectrumValue = audioSpectrum[0] * 100;
        }
    }
}
