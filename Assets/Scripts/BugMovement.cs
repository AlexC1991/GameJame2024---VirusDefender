using System.Collections;
using UnityEngine;
namespace Batty251
{
    public class BugMovement : MonoBehaviour
    {
        [SerializeField] private BarrierDataContiner barrierBool;
        [SerializeField] private BugCollisionDetection bugBool;
        [SerializeField] private WallCollisionDataContainer wallDetection;
        public float movementSpeed = 0.5f;
        private float originalMovement;
        private int _wallPaperHitCounter;
        private int _pathChooser;
        private int _lastCount;
        private float _currentTimer;
        private bool hitOtherBug;
        private int _lastPathChooser;
        private Vector2 GetDirectionVector;
        private float raycastDistance = 1;
        private RaycastHit2D hit;

         private void Awake()
         {
             originalMovement = movementSpeed;
         }

         private void Start()
        {
            _pathChooser = Random.Range(1, 4);
            StartCoroutine(BugBehavior());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("BarrierWall"))
            {
                bugBool.hitBug = true;
                hitOtherBug = true;
                Debug.Log("Detected Wall");
            }
        }

        private void Update()
        {
            if (wallDetection.hitWall)
            {
                _wallPaperHitCounter += 1;
                _lastCount = _wallPaperHitCounter;
                wallDetection.hitWall = false;
            }
            float timeCount = 5;
            
            _currentTimer += 0.5f * Time.deltaTime;
           
            if (_currentTimer >= timeCount)
            {
                StartCoroutine(BugBehavior());
                _currentTimer = 0;
            } 
            
            if (_wallPaperHitCounter > _lastCount * 2) // Change direction if hits more than 2x lastCount
            {
                StartCoroutine(BugBehavior());
                _currentTimer = 0;
            }
            
            if ((barrierBool.hitWall))
            {
                StartCoroutine(BugBehavior());
                _currentTimer = 0;
                barrierBool.hitWall = false;
            }
            
            if (hitOtherBug)
            {
                StartCoroutine(BugBehavior());
                _currentTimer = 0;
                bugBool.hitBug = false;
                hitOtherBug = false;
            }
            
            PathChooser();
            
            if (hit.collider != null && hit.collider.gameObject.name != this.gameObject.name)
            {
                StartCoroutine(StartTheBugAvoidenceSystem());
            }
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
            switch (_pathChooser)
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
        
        private bool DetectObstacle()
        {
            hit = Physics2D.Raycast(transform.position, GetDirectionVector, raycastDistance);
            return hit.collider != null;
            
        }

        IEnumerator StartTheBugAvoidenceSystem()
        {
            StartCoroutine(BugBehavior());
            yield break;
        }

        IEnumerator BugBehavior()
        {
            yield return new WaitForSeconds(0.5f);

            if (DetectObstacle())
            {
                // Choose a new path if an obstacle is detected
                _pathChooser = Random.Range(1, 5);
                _lastPathChooser = _pathChooser;
            }
            
            // Ensure the new path is different from the previous one
            int newPathChooser;
            do
            {
                newPathChooser = Random.Range(1, 5);
            } while (newPathChooser == _lastPathChooser);

            _pathChooser = newPathChooser;
            _lastPathChooser = _pathChooser;
        }
    }
}
                    
