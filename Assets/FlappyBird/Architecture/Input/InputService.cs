using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Input
{
    public class InputService : MonoBehaviour
    {
        public InputActions InputActions { get => m_inputActions; }
        private InputActions m_inputActions;

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