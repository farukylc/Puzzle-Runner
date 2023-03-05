using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserStats
{
    
    public string userName;
    public int level;
    public float forwardSpeed;
    public int currentThrowDigit;
    public int throwValueUpdateValue;
    public float throwRate;
    public int throwRateUpdateValue;
    public float range;
    public int throwRangeUpdateValue;
    public int score;
    public int totalScore;
    public bool isFootOpen;
    public bool isHeadOpen;

    public UserStats()
    {

    }
    public UserStats(string userName, int level, float forwardSpeed, int currentThrowDigit,
        int throwValueUpdateValue, float throwRate,int throwRateUpdateValue, float range, int throwRangeUpdateValue, int score, int totalScore,
        bool isFootOpen,bool isHeadOpen)
    {
        this.userName = userName;
        this.level = level;
        this.forwardSpeed = forwardSpeed;
        this.currentThrowDigit = currentThrowDigit;
        this.throwValueUpdateValue = throwValueUpdateValue;
        this.throwRate = throwRate;
        this.throwRateUpdateValue = throwRateUpdateValue;
        this.range = range;
        this.throwRangeUpdateValue = throwRangeUpdateValue;
        this.score = score;
        this.totalScore = totalScore;
        this.isFootOpen = isFootOpen;
        this.isHeadOpen = isHeadOpen;
    }
}

