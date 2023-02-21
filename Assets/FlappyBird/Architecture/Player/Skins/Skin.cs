using UnityEngine;

namespace Architecture.Player.Skins
{
    [CreateAssetMenu(fileName = "new_Skin", menuName = "Skins/Skin")]
    public class Skin : ScriptableObject
    {
        public Sprite MainSprite { get => m_mainSprite; }
        public float FlyAnimationDuration { get => m_flyAnimationDuration; }
        public Sprite[] FlyAnimationSprites { get => m_flyAnimationSprites; }

        [SerializeField] private Sprite m_mainSprite;
        [Space(10)]
        [Header("Fly Animation")]
        [SerializeField] private float m_flyAnimationDuration = 20f;
        [SerializeField] private Sprite[] m_flyAnimationSprites;
    }
}