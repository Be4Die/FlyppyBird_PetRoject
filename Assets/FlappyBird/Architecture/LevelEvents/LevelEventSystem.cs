using UnityEngine;
using Zenject;
using Architecture.Animations.Core;
using Architecture.Player;
using Architecture.Environment;

namespace Architecture.LevelEvents
{
    /// <summary>
    ///System that's call level events.
    ///</summary>
    [RequireComponent(typeof(AudioSource))]
    public sealed class LevelEventSystem: MonoBehaviour
    {
        #region Variabels
        [SerializeField] private UI.GameOverPanelPresenter m_gameOverPanelPresenter;
        [SerializeField] private AudioClip m_deadSound;

        [Inject] private AnimationsService m_animationsService;
        [Inject] private PlayerController m_playerController;
        [Inject] private PipeSpawner m_pipeSpawner;
        [Inject] private PlayerScore m_playerScore;

        private AudioSource m_audioSource;
        #endregion

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
        }

        public void GameOver()
        {
            m_playerController.Die();
            var curscore = (int)m_playerScore.Score;
            m_animationsService.StopAll();
            m_playerScore.TrySetBestScore(curscore);
            m_gameOverPanelPresenter.Show(curscore, m_playerScore.GetBestScore());
            m_pipeSpawner.Pause();

            m_audioSource.PlayOneShot(m_deadSound);
        }

        public void Pause()
        {
            m_playerController.Freez();
            m_pipeSpawner.Pause();
            m_animationsService.StopAll();
        }
    }
}