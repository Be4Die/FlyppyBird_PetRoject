using UnityEngine;

namespace Architecture.Input
{
    public sealed class InputService : MonoBehaviour
    {
        #region Variabels
        public InputActions InputActions { get => m_inputActions; }
        private InputActions m_inputActions;
        #endregion


        private void Awake()
        {
            m_inputActions = new InputActions();
        }

        private void OnEnable()
        {
            m_inputActions.Enable();
        }
        private void OnDisable()
        {
            m_inputActions.Disable();
        }
    }
}