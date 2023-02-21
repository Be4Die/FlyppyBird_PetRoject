using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Architecture.Utils
{
    public class ObjectPool<T> where T : Component
    {
        #region Variabels
        public uint Size { get => m_size; }

        private T m_prefab;
        private uint m_size;
        private bool m_enjection, m_expend;
        private Transform m_transform;
        private List<T> m_pool;

        private DiContainer m_diContainer;
        #endregion

        public ObjectPool(T prefab, uint size, Transform transform, DiContainer diContainer, bool expend = true)
        {
            //setup fields
            m_prefab = prefab;
            m_transform = transform;
            m_size = size;
            m_diContainer = diContainer;
            m_enjection = true;
            m_expend = expend;

            CreatePool();
        }
        public ObjectPool(T prefab, uint size, Transform transform, bool expend = true)
        {
            //setup fields
            m_prefab = prefab;
            m_transform = transform;
            m_size = size;
            m_expend = expend;
            m_enjection = false;

            CreatePool();
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var component in m_pool)
            {
                if (!component.gameObject.activeInHierarchy)
                {
                    element = component;
                    component.gameObject.SetActive(true);
                    return true;
                }
            }
            
            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (m_expend)
                return CreateObject(true);

            throw new System.IndexOutOfRangeException("No free elements in pool");
        }

        public List<T> GetActiveElements()
        {
            var list = new List<T>();

            foreach (var component in m_pool)
            {
                if (component.gameObject.activeInHierarchy)
                {
                    list.Add(component);
                }
            }

            return list;
        }

        private void CreatePool()
        {
            m_pool = new List<T>();

            for (int i = 0; i < m_size; i++)
            {
                CreateObject();
            }
        }
        
        private T CreateObject(bool active = false)
        {
            T newobj;

            if (m_enjection)
            {
                newobj = m_diContainer.InstantiatePrefabForComponent<T>(m_prefab
                , Vector3.zero, Quaternion.identity, m_transform);
            }
            else 
            {
                newobj = GameObject.Instantiate<T>(m_prefab, m_transform);
            }
            newobj.gameObject.SetActive(active);
            m_pool.Add(newobj);

            return newobj;
        }
        
    }
}