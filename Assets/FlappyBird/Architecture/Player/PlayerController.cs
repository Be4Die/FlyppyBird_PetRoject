using Architecture.Input;
using UnityEngine;
using Zenject;

namespace Architecture.Player
{
    /// <summary>
    /// controll PlayerMovement and connect InputService with it,
    /// controll SkinPresenter
    ///</summary>
    public class PlayerController : MonoBehaviour
    {
        #region Variabels
        public bool IsDie { get => m_isDie; }

        [Inject] private InputService m_inputService;

        [SerializeField] private PlayerMovement m_playerMovement;
        [Space(10)]
        [SerializeField] private Skins.SkinPresenter m_skinPresenter;
        private bool m_isDie;
        #endregion

        
        private void Start()
        {
            m_inputService.InputActions.GamePlay.Jump.started += ctx => DoJump();
            m_isDie = false;
        }

        public void Die()
        {
            m_isDie = true;
        }
        public void DoJump()
        {
            if (!m_isDie)
                m_playerMovement.Jump();
        }

        public void Freez()
        {
            m_playerMovement.Freez();
            m_skinPresenter.StopAnimation();
        }
        public void FreezMovement()
        {
            m_playerMovement.Freez();
        }
        public void UnFreezMovement()
        {
            m_playerMovement.UnFreez();
        }
    }
}