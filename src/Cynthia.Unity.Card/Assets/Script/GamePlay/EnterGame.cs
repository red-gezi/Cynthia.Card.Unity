﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
	void Start ()
    {
        AdaptiveResolution();
	}
    public void AdaptiveResolution()
    {
        var scale = 1920f / Screen.width;
        var scale2 = Screen.height / 1080f * scale;
        transform.localScale = Vector3.one / scale2;
    }
    private void Update()
    {
        AdaptiveResolution();
    }
}
