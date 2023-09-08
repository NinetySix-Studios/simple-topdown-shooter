using Project.Services;
using UnityEngine;

namespace Project.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Services
        {
            get
            {
                if (_ == null) _ = Game.Services.Get<AudioManager>();
                return _;
            }
        }
        private static AudioManager _;
        
        [field: SerializeField] public AudioClip ClickSFX { get; set; }

        [SerializeField]
        private AudioSource _sfxAudioSource;

        public void PlayOneShot(AudioClip clip)
        {
            _sfxAudioSource.PlayOneShot(clip);
        }
    }
}