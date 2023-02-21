using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Player
{
    public class PlayerScore : MonoBehaviour
    {
        #region Variabels
        public delegate void ScoreChangedDelegate();
        public event ScoreChangedDelegate OnScoreChanged;

        public uint Score { get => m_score; }
        [SerializeField] private uint m_score;

        private const string M_BESTSCORE = "BestScore";
        #endregion

        private void Awake()
        {
            SetScore(0);
        }

        public void AddScore(uint amount = 1)
        {
            m_score += amount;
            OnScoreChanged?.Invoke();
        }

        public void SetScore(uint value)
        {
            m_score = value;
            OnScoreChanged?.Invoke();
        }

        public int GetBestScore()
        {
            return PlayerPrefs.GetInt(M_BESTSCORE);
        }

        public bool TrySetBestScore(int value)
        {
            if (value > GetBestScore())
            {
                PlayerPrefs.SetInt(M_BESTSCORE, value);
                return true;
            }
            return false;
        }
    }
}