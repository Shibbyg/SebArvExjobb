using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using FMOD.Studio;
using FMODUnity;
namespace Gamekit2D
{
    [RequireComponent(typeof(Slider))]
    public class MixerSliderLink : MonoBehaviour
    {
        public string vcaPath;
        private VCA vca;
        
        //public AudioMixer mixer;
        //public string mixerParameter;

        public float maxAttenuation = 0.0f;
        public float minAttenuation = -80.0f;

        protected Slider m_Slider;


        void Awake ()
        {
            m_Slider = GetComponent<Slider>();

            float value;

            vca = RuntimeManager.GetVCA(vcaPath);
            vca.getVolume(out value);
            

            m_Slider.value = value;

            m_Slider.onValueChanged.AddListener(SliderValueChange);
        }


        void SliderValueChange(float value)
        {
            vca.setVolume(value);
        }
    }
}