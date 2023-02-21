using UnityEngine;
using Zenject;
using Architecture.LevelEvents;
using Architecture.Player;

namespace Architecture.Environment
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(AudioSource))]
    public class ScoreZone : MonoBehaviour
    {
        [SerializeField] private AudioClip m_scoreSound;
        private AudioSource m_audioSource;

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerScore>(out var score))
            {
                score.AddScore();
                m_audioSource.PlayOneShot(m_scoreSound);
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
