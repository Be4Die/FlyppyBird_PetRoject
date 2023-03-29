using System.Collections;
using UnityEngine;
using Architecture.Utils;
using Zenject;

namespace Architecture.Environment
{
    public class PipeSpawner : MonoBehaviour
    {
        #region Variabels
        [Header("Spawn Settings")]
        [SerializeField] private Pipe m_prefab;
        [SerializeField] private Transform m_spawnPoint;
        [SerializeField] [Range(0, 5f)] private float m_delay = 2;
        [SerializeField] [Range(-5f, 5f)] private float m_minY = - 1;
        [SerializeField] [Range(-5f, 5f)] private float m_maxY = 1;
        [SerializeField] [Range(0, 20f)] private float m_lifeTime = 4;

        [Header("Object Pool Settings")]
        [SerializeField] private uint m_poolSize = 5;
        [SerializeField] private Transform m_poolPivot;

        private ObjectPool<Pipe> m_pool;
        private bool m_isPause = false;
        [Inject] private DiContainer m_diContainer;
        #endregion


        private void Awake()
        {
            m_pool = new ObjectPool<Pipe>(m_prefab, m_poolSize, m_poolPivot, m_diContainer);
        }
        private void Start() 
        {
            StartCoroutine(Spawning());
        }
        public void Pause()
        {
            m_isPause = true;
            foreach(var pipe in m_pool.GetActiveElements())
            {
                pipe.Pause();
            }
        }

        public void UnPause()
        {
            m_isPause = false;
            foreach(var pipe in m_pool.GetActiveElements())
            {
                pipe.UnPause();
            }
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                if (!m_isPause)
                {
                    var newPos = m_spawnPoint.position + new Vector3(0, Random.Range(m_minY, m_maxY), 0);
                    var pipe = m_pool.GetFreeElement();
                    pipe.transform.position = transform.TransformPoint(newPos);
                    pipe.SetLifeTime(m_lifeTime);

                    yield return new WaitForSeconds(m_delay);
                }
                yield return new WaitForEndOfFrame();
            }
        }

    }

}
