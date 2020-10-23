using UnityEngine;

    public class CtrlCamera : MonoBehaviour
    {
        public bool Press;
        private Vector2 mousePressPos;
        private Vector2 mouseDeltaPos;
        private Vector2 currentAngles;
        private Vector2 targetAngles;
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Application.platform== RuntimePlatform.WindowsPlayer||Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    currentAngles = targetAngles = transform.eulerAngles;
                }

                if (Input.GetMouseButton(0))
                {
                    targetAngles.y -= Input.GetAxis("Mouse X") * 20f;
                    // targetAngles.y = Mathf.Clamp(targetAngles.x, -60f, 60f);
                    currentAngles = Vector2.Lerp(currentAngles, targetAngles, 100f * Time.deltaTime);
                    Quaternion rotation = Quaternion.Euler(currentAngles);
                    transform.rotation =rotation ;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    Press = false;
                }
            }
            else if (Application.platform== RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount == 1)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Touch touch = Input.GetTouch(0);
                        //旋转

                        targetAngles.y += touch.deltaPosition.x * 3f;

                        currentAngles = Vector2.Lerp(currentAngles, targetAngles, 2 * Time.deltaTime);
                        //rotate of target
                        Quaternion rotation = Quaternion.Euler(currentAngles);
                        transform.rotation = rotation;
                    }
                }
            }
            
        }


        public void BeginDrag()
        {
           
        }

        public void EndDrag()
        {
            
        }
    }