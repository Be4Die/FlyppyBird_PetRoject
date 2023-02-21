using UnityEngine;
using Zenject;
using Architecture.Utils;
using Architecture.Player;
using Architecture.Environment;

namespace Architecture.LevelEvents
{
    /// <summary>
    ///System that's call level events.
    ///Perhaps this solution contradicts SOLID, but it does not contradict YAGNI, 
    ///in a small game like this, such a solution will be convenient to use. 
    ///But still using StateMachine pattern will be better from the point of view of scalability.
    ///</summary>
    [RequireComponent(typeof(AudioSource))]
    public class LevelEventSystem: MonoBehaviour
    {
        #region Variabels
        [SerializeField] private UI.GameOverPanelPresenter m_gameOverPanelPresenter;
        [SerializeField] private AudioClip m_deadSound;

        [Inject] private ScrollEffectList m_scrollEffectList;
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
            m_scrollEffectList.StopAll();
            m_playerScore.TrySetBestScore(curscore);
            m_gameOverPanelPresenter.Show(curscore, m_playerScore.GetBestScore());
            m_pipeSpawner.Pause();

            m_audioSource.PlayOneShot(m_deadSound);
        }

        public void Pause()
        {
            m_playerController.Freez();
            m_pipeSpawner.Pause();
            m_scrollEffectList.StopAll();
        }

        public void RestartLevel()
        {

        }
    }
}