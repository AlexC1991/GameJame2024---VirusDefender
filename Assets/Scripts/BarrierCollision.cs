using System;
using UnityEngine;

namespace Batty251
{
    public class BarrierCollision : MonoBehaviour
    {
        [SerializeField] private BarrierDataContiner barrierBool;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bug"))
            {
                barrierBool.hitWall = true;
            }
        }

        private void Update()
        {
            Debug.Log(barrierBool.hitWall);
        }
    }
}
