using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardData : MonoBehaviour
{
    public int[,] Reward = new int[16, 2];
    public int[,] RewardF = new int[16, 2];
    public int[] Rewardxp = new int[16];
    void Start()
    {
        //Recompenzas por vencer al jefe
        Reward[0, 0] = 1000;
        Reward[0, 1] = 5;
        Reward[1, 0] = 2000;
        Reward[1, 1] = 10;
        Reward[2, 0] = 4000;
        Reward[2, 1] = 15;
        Reward[3, 0] = 8000;
        Reward[3, 1] = 20;
        Reward[4, 0] = 16000;
        Reward[4, 1] = 30;
        Reward[5, 0] = 32000;
        Reward[5, 1] = 40;
        Reward[6, 0] = 64000;
        Reward[6, 1] = 50;
        Reward[7, 0] = 128000;
        Reward[7, 1] = 60;
        Reward[8, 0] = 256000;
        Reward[8, 1] = 75;
        Reward[9, 0] = 512000;
        Reward[9, 1] = 90;
        Reward[10, 0] = 1024000;
        Reward[10, 1] = 105;
        Reward[11, 0] = 1200000;
        Reward[11, 1] = 120;
        Reward[12, 0] = 1500000;
        Reward[12, 1] = 140;
        Reward[13, 0] = 2000000;
        Reward[13, 1] = 160;
        Reward[14, 0] = 2024000;
        Reward[14, 1] = 180;
        Reward[15, 0] = 2200000;
        Reward[15, 1] = 200;
        //Recompenzas por intentar vencer al jefe
        RewardF[0, 0] = 200;
        RewardF[0, 1] = 0;
        RewardF[1, 0] = 400;
        RewardF[1, 1] = 0;
        RewardF[2, 0] = 800;
        RewardF[2, 1] = 0;
        RewardF[3, 0] = 1600;
        RewardF[3, 1] = 1;
        RewardF[4, 0] = 2000;
        RewardF[4, 1] = 2;
        RewardF[5, 0] = 4000;
        RewardF[5, 1] = 3;
        RewardF[6, 0] = 8000;
        RewardF[6, 1] = 4;
        RewardF[7, 0] = 10666;
        RewardF[7, 1] = 5;
        RewardF[8, 0] = 20000;
        RewardF[8, 1] = 6;
        RewardF[9, 0] = 40000;
        RewardF[9, 1] = 7;
        RewardF[10, 0] = 80000;
        RewardF[10, 1] = 8;
        RewardF[11, 0] = 160000;
        RewardF[11, 1] = 9;
        RewardF[12, 0] = 320000;
        RewardF[12, 1] = 10;
        RewardF[13, 0] = 640000;
        RewardF[13, 1] = 11;
        RewardF[14, 0] = 1280000;
        RewardF[14, 1] = 12;
        RewardF[15, 0] = 1500000;
        RewardF[15, 1] = 13;
        //Recompenzas de experiencia por jefe
        Rewardxp[0] = 100;
        Rewardxp[1] = 200;
        Rewardxp[2] = 300;
        Rewardxp[3] = 400;
        Rewardxp[4] = 1000;
        Rewardxp[5] = 2000;
        Rewardxp[6] = 3000;
        Rewardxp[7] = 4000;
        Rewardxp[8] = 10000;
        Rewardxp[9] = 15000;
        Rewardxp[10] = 20000;
        Rewardxp[11] = 25000;
        Rewardxp[12] = 30000;
        Rewardxp[13] = 40000;
        Rewardxp[14] = 50000;
        Rewardxp[15] = 60000;
    }
}
