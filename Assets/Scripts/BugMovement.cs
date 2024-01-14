using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Batty251

{
    public class BugMovement : MonoBehaviour
    {
        [SerializeField] private BarrierDataContiner barrierBool;
        [SerializeField] private float movementSpeed;
       private float origianlMovement;
        private bool hitWallpaper;
        private int wallPaperHitCounter;
        private int pathChooser;
        private int lastCount;
        private float currentTimer;
        // private const float stopMovement = 0;
        
        private void Awake()
        {
            origianlMovement = movementSpeed;
        }

        private void Start()
        {
            StartCoroutine(BugBehavior());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Wallpaper"))
            {
                hitWallpaper = true;
            }
        }

        private void Update()
        {
            if (hitWallpaper)
            {
                wallPaperHitCounter += 1;
                lastCount = wallPaperHitCounter;
                hitWallpaper = false;
            }
            float timeCount = 3;
            
            currentTimer += 0.5f * Time.deltaTime;
           
            if (currentTimer >= timeCount)
            {
                StartCoroutine(BugBehavior());
                currentTimer = 0;
            }
            else if (wallPaperHitCounter > lastCount * 2) // Change direction if hits more than 2x lastCount
            {
                StartCoroutine(BugBehavior());
                currentTimer = 0;
            }
            else if (barrierBool.hitWall)
            {
                StartCoroutine(BugBehavior());
                barrierBool.hitWall = false;
                currentTimer = 0;
            }

            // Move in the chosen path
            PathChooser();
        }

        private void MoveLeft()
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            transform.Translate(Vector2.up * (movementSpeed * Time.deltaTime));
        }

        private void MoveRight()
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            transform.Translate(-Vector2.down * (movementSpeed * Time.deltaTime));
        }

        private void MoveUp()
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(-Vector2.down * (movementSpeed * Time.deltaTime));
        }

        private void MoveDown()
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            transform.Translate(-Vector2.down * (movementSpeed * Time.deltaTime));
        }

        private void PathChooser()
        {
            switch (pathChooser)
            {
                case 1:
                    MoveLeft();
                    break;
                case 2:
                    MoveRight();
                    break;
                case 3:
                    MoveDown();
                    break;
                default:
                    MoveUp();
                    break;
            }
        }

        IEnumerator BugBehavior()
        {
            pathChooser = 1;
            yield return new WaitForSeconds(0.5f);
            pathChooser = Random.Range(1, 4);
        }
    }
}
                    
                


  
