using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class WindowToggleHandler : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public void OnWindowToggled(Toggle sender)
    {
        if (sender.isOn)
        {
            ShowWindow(GetActiveWindow(), 2);
        }
        else
        {
            ShowWindow(GetActiveWindow(), 3);
        }
    }
}
