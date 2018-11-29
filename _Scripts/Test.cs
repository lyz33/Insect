using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    bool isNext;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        //遍历所有Waves中的 数组
        for (int j=0;j<10;j++)
        {
            print("j"+j);
            for (int i = 0; i < 10; i++)
            {
                //实例化预设物（每一波敌人的预设物，开始位置，无旋转的）旋转前的初始角
                print("i"+i);

                if (i != 9) //检测生成是否完毕
                {
                    //时间间隔
                    yield return null;
                }
            }

            ////当存活数量大于0
            //while (CountEnemyAlive > 0)
            //{
            //    yield return 0; //暂停0帧，不执行下边代码
            //}

            //每一波暂停 WaveRate 秒
            yield return null;
        }
    }


    //IEnumerator Creat()
    //{

    //}



    // Update is called once per frame
    void Update()
    {

    }
}
