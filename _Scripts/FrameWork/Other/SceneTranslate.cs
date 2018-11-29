using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FocusFrame {
    public class SceneTranslate : MonoBehaviour
    {
        public float fadeTime = 0;
        public float fadeSeconds = 1;
        public Color fadeColor = Color.black;
        public Color fadeClearColor;
        public Material fadeMaterial;  //Sprite、UI

        public bool fadingIn;
        public bool fadingOut;

        /// <summary>
        /// 开始淡出
        /// </summary>
        public void BeginFadeOut()
        {
            UpdateCamera();
            if (fadingIn && fadeTime > 0)
            {
                fadeTime = 1 / fadeTime; // Reverse fade
            }
            else
            {
                fadeTime = 0;
                SetFadeColor(Color.clear);
            }
            SetFadersEnabled(true);
            fadingIn = false;
            fadingOut = true;
            fadeClearColor = fadeColor;
            fadeClearColor.a = 0;
        }

        /// <summary>
        /// 开始淡入
        /// </summary>
        public void BeginFadeIn()
        {
            UpdateCamera();
            if (fadingOut && fadeTime > 0)
            {
                fadeTime = 1 / fadeTime; // Reverse fade
            }
            else
            {
                fadeTime = 0;
                SetFadeColor(fadeColor);
            }
            SetFadersEnabled(true);
            fadingIn = true;
            fadingOut = false;
            fadeClearColor = fadeColor;
            fadeClearColor.a = 0;
        }

        void Update()
        {
            if (fadingIn)
            {
                UpdateFadeIn();
            }
            else if (fadingOut)
            {
                UpdateFadeOut();
            }
        }

        public IEnumerator TranslateScene()
        {
            yield return new WaitForSeconds(2f);
            BeginFadeIn();
        }
        /// <summary>
        /// 更新淡入
        /// </summary>
        private void UpdateFadeIn()
        {
            fadeTime += Time.unscaledDeltaTime / fadeSeconds;
            SetFadeColor(Color.Lerp(fadeColor, fadeClearColor, fadeTime));

            if (fadeTime > 1)
            {
                EndFadeIn();
            }
        }
        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="value"></param>
        private void SetFadeColor(Color value)
        {
            fadeMaterial.color = value;
        }
        /// <summary>
        /// 更新淡出
        /// </summary>
        private void UpdateFadeOut()
        {
            fadeTime += Time.unscaledDeltaTime / fadeSeconds;
            SetFadeColor(Color.Lerp(fadeClearColor, fadeColor, fadeTime));

            if (fadeTime > 1)
            {
                EndFadeOut();
            }
        }
        /// <summary>
        /// 结束淡入
        /// </summary>
        private void EndFadeIn()
        {
            SetFadeColor(Color.clear);
            SetFadersEnabled(false);
            fadingIn = false;
        }
        /// <summary>
        /// 结束淡出
        /// </summary>
        private void EndFadeOut()
        {
            SetFadeColor(fadeColor);
            fadingOut = false;
        }
        /// <summary>
        /// 查找相机
        /// </summary>
        public void UpdateCamera()
        {
            if (fadeMaterial != null)
            {
                // Find all cameras and add fade material to them (initially disabled)
                foreach (Camera c in Camera.allCameras)
                {
                    if (c.gameObject.GetComponent<CameraFadeControll>() == null)
                    {
                        var fadeControl = c.gameObject.AddComponent<CameraFadeControll>();
                        fadeControl.fadeMaterial = fadeMaterial;
                    }
                }
            }
        }
        /// <summary>
        /// 控制脚本
        /// </summary>
        /// <param name="value"></param>
        private void SetFadersEnabled(bool value)
        {
            foreach (Camera c in Camera.allCameras)
            {
                if (c.gameObject.GetComponent<CameraFadeControll>() != null)
                {
                    c.gameObject.GetComponent<CameraFadeControll>().enabled = value;
                }
            }
        }

    }
}
