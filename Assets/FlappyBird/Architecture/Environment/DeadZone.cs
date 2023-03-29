using UnityEngine;
using Zenject;
using Architecture.LevelEvents;
using Architecture.Player;

namespace Architecture.Environment
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class DeadZone : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private AudioClip m_hitSound;
        [Inject] private LevelEventSystem m_levelEventSystem;

        private AudioSource m_audioSource;
        #endregion

        
        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerController>(out var controller) && !controller.IsDie)
            {
                m_levelEventSystem.GameOver();
                m_audioSource.PlayOneShot(m_hitSound);
            }
        }
    }
}
