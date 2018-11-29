using UnityEngine;

namespace FocusFrame
{
    public class PathFollowing : MonoBehaviour
    {
        public Path path;

        public float speed = 20.0f;               // 速度
        public float mass = 5.0f;                // 质量，影响加速度
        public bool isLooping = false;          // 是否循环

        private float curSpeed;
        private int curPathIndex;
        private float pathLength;
        private Vector3 targetPoint;
        public bool isStartMove = false;        // 是否开始演路径行走            
        public bool isToFinishPoint = false;    // 是否到达终点
        public bool isPause = false;            // 是否暂停下来
        public bool isLookAtPlayer;             // 是否一直看着玩家
        Vector3 velocity;

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// 设置路径path
        /// </summary>
        /// <param name="p"></param>
        public void SetPath(Path p)
        {
            path = p;
            pathLength = path.Length;
            isStartMove = false;
            curPathIndex = 0;
            //transform.position = path.pointArray[curPathIndex].position;
          //  transform.rotation = path.pointArray[curPathIndex].rotation;
            velocity = path.pointArray[curPathIndex].position - transform.position;
        }

        /// <summary>
        /// 开始沿着路径走
        /// </summary>
        public void StartFollowPathMove()
        {
            isStartMove = true;
            isToFinishPoint = false;
            curPathIndex = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (isStartMove&&!isPause)
            {
                curSpeed = speed * Time.deltaTime;
                targetPoint = path.GetPoint(curPathIndex);

                if (Vector3.Distance(transform.position, targetPoint) < path.Radius)
                {
                    if (curPathIndex < pathLength - 1)
                    {
                        curPathIndex++;
                        targetPoint = path.GetPoint(curPathIndex);
                    }
                    else
                    {
                        if (isLooping)
                        {
                            curPathIndex = 0;
                        }
                        else
                        {
                            isToFinishPoint = true;
                            isStartMove = false;
                        }
                    }
                }
                if (curPathIndex >= pathLength) return;

                if (curPathIndex >= pathLength - 1 && !isLooping)
                    velocity += Steer(targetPoint, true);
                else
                    velocity += Steer(targetPoint);

                transform.position += velocity * Time.deltaTime;
                if (!isLookAtPlayer)
                {
                    transform.rotation = Quaternion.LookRotation(velocity * Time.deltaTime);
                }
            }
        }

        public Vector3 Steer(Vector3 target, bool bFinalPoint = false)
        {
            Vector3 desiredVelocity = (target - transform.position);
            float dist = desiredVelocity.magnitude;

            desiredVelocity.Normalize();

            //if (bFinalPoint && dist < 10.0f)
            //    desiredVelocity *= (curSpeed * (dist / 10.0f));
            //else
            desiredVelocity *= curSpeed;

            Vector3 steeringForce = desiredVelocity - velocity;
            Vector3 acceleration = steeringForce / mass;

            return acceleration;
        }
    }
}
