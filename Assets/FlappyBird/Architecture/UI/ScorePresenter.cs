using UnityEngine;
using TMPro;
using Zenject;
using Architecture.Player;

namespace Architecture.UI
{
    public class ScorePresenter : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private TextMeshProUGUI m_text;

        [Inject] private PlayerScore m_score;
        #endregion

        

        private void OnEnable()
        {
            m_score.OnScoreChanged += UpdateText;
        }

        private void OnDisable()
        {
            m_score.OnScoreChanged -= UpdateText;
        }

        private void UpdateText()
        {
            m_text.text = m_score.Score.ToString();
        }
    }
}