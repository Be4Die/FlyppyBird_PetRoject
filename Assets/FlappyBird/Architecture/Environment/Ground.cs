using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Architecture.Player;

namespace Architecture.Environment
{
    public class Ground : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerController>(out var controller))
            {
                controller.Freez();
            }
        }
    }
}