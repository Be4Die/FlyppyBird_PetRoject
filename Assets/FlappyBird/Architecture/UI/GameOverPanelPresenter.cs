using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

namespace Architecture.UI
{
    [System.Serializable]
    public struct MedalSettings
    {
        public int Score { get => m_score; }
        public Sprite Icon { get => m_icon; }
        [SerializeField ]private int m_score;
        [SerializeField] private Sprite m_icon;

        public MedalSettings(int score, Sprite icon)
        {
            m_score = score;
            m_icon = icon;
        }
    }

    /// <summary>
    /// present and controll all elements of gameover panel
    ///</summary>
    public class GameOverPanelPresenter : MonoBehaviour
    {
        #region Variabels
        public Button OkButton { get => m_okButton; }
        public Button ShareButton { get => m_shareButton; }
        public TextMeshProUGUI CurrentScoreText { get => m_currentScoreText; }
        public TextMeshProUGUI BestScoreText { get => m_bestScoreText; }


        [Header("Medal Settings")]
        [SerializeField] private Image m_medalImage;
        [SerializeField][Range(0, 4f)] private float m_medalAnimationScale;
        [SerializeField][Range(0, 4f)] private float m_medalAnimationDuration;
        [SerializeField][Range(0, 4)] private int m_medalAnimationVibrato;
        [SerializeField][Range(0, 4f)] private float m_medalAnimationElasticity;
        [SerializeField] private MedalSettings[] m_medals;

        [Header("Text Fields")]
        [SerializeField] private TextMeshProUGUI m_currentScoreText;
        [SerializeField] private TextMeshProUGUI m_bestScoreText;
        [Header("Buttons")]
        [SerializeField] private Button m_okButton;
        [SerializeField] private Button m_shareButton;
        #endregion

        private void Awake() {
            Array.Sort<MedalSettings>(m_medals, (x,y) => x.Score.CompareTo(y.Score));
            Array.Reverse(m_medals);
        }

        public void Show(int currentScore, int bestScore)
        {
            this.gameObject.SetActive(true);
            m_currentScoreText.text = currentScore.ToString();
            m_bestScoreText.text = bestScore.ToString();

            foreach (var medal in m_medals)
            {
                if (currentScore >= medal.Score)
                {
                    m_medalImage.sprite = medal.Icon;
                    var scale = m_medalImage.transform.localScale;
                    m_medalImage.transform.DOPunchScale(scale*m_medalAnimationScale, m_medalAnimationDuration
                    , m_medalAnimationVibrato, m_medalAnimationElasticity);
                    break;
                }
            }
            if (m_medalImage.sprite == null)
            {
                m_medalImage.color = Color.clear;
            }
        }
    }
}