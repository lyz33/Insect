using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 异步加载场景
/// </summary>
namespace FocusFrame
{
    public class LoadAsync : Singleton<LoadAsync>
    {
        public bool isLoadComplete; //是否加载成功

        int progress = 0;
        float toProgress = 0;
        private Text text;
        private Image image;

        private int progressLength;

        void Start()
        {
            text = transform.Find("ProgressNum").GetComponent<Text>();
            image = transform.Find("ProgressBarBg/ProgressBar").GetComponent<Image>();
            text.text = progress + "%";
            image.fillAmount = 0;
        }
        private void Update()
        {
            if (progress < toProgress)
            {
                progress++;
            }
            image.fillAmount = progress / 100f;
            text.text = progress.ToString() + "%";
            if (progress == 100)
            {
                LoadOK();
            }
        }
        public void TotalLength(int length)
        {
            progressLength = length;
        }
        public void AddProgress()
        {
            if (progressLength != 0)
                toProgress += (100 / (float)progressLength);
        }

        public void LoadOK()
        {
            isLoadComplete = true;
            this.gameObject.SetActive(false);
        }
    }
}