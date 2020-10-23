using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SceneAction : MonoBehaviour
    {
        public UnityEvent OnPress;
        public static bool canPress;

        private void Start()
        {
            canPress = true;
            OnPress.AddListener(() =>  canPress = false);
        }

        RaycastHit hit;

        void Update()
        {
            if (Input.GetMouseButtonDown(0)&&canPress)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, float.MaxValue, LayerMask.GetMask("Click")))
                {
                    var obj = hit.collider.gameObject;
                    if (Application.platform == RuntimePlatform.WindowsPlayer ||
                        Application.platform == RuntimePlatform.WindowsEditor)
                    {
                        if (obj == gameObject && !EventSystem.current.IsPointerOverGameObject())
                        {
                            OnPress?.Invoke();
                        }
                    }
                    else if (Application.platform == RuntimePlatform.IPhonePlayer)
                    {
                        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            if (Input.touchCount!=1||EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                            {
                                return;
                            }
                            OnPress?.Invoke();
                        }
                    }
                }
            }
        }

        public void SetCanClick()
        {
            canPress = true;
        }
    }
