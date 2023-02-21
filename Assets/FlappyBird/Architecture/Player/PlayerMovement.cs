using UnityEngine;

namespace Architecture.Player
{
    /// <summary>
    /// Сlass that provides player movements that are based on kinematics.
    /// To use it you need a controller.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private float m_jumpForce;
        [SerializeField] private float m_tiltFactor; 
        [SerializeField] private AudioClip m_flapSound;   
             
        private Vector3 m_direction;
        private bool m_isFreez = false;
        private AudioSource m_audioSource;
        #endregion

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (!m_isFreez)
            {
                ApplyGravity();
                ApplyDirection();
                ApplyTiltEffect();
            }
        }

        public void Freez()
        {
            m_isFreez = true;
        }

        public void UnFreez()
        {
            m_isFreez = false;
        }

        private void ApplyDirection()
        {
            transform.position += m_direction * Time.fixedDeltaTime;
        }

        private void ApplyGravity()
        {
            m_direction.y += Physics.gravity.y * Time.fixedDeltaTime;
        }

        private void ApplyTiltEffect()
        {
            var rotation = transform.eulerAngles;
            rotation.z = m_direction.y * m_tiltFactor;
            transform.eulerAngles = rotation;
        }

        public void Jump()
        {
            if (!m_isFreez)
            {
                m_direction = Vector3.up * m_jumpForce;
                m_audioSource.PlayOneShot(m_flapSound);
            }
        }

    }


}