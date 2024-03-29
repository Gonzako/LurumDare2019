﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public delegate void KeyboardLayoutChanged(int oldCultureInfo, int newCultureInfo);

class KeyboardLayoutWatcher : IDisposable
{
    private readonly Timer _timer;
    private int _currentLayout = 1033;

    public KeyboardLayoutChanged KeyboardLayoutChanged;

    public KeyboardLayoutWatcher()
    {
        _timer = new Timer(new TimerCallback(CheckKeyboardLayout), null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")] static extern IntPtr GetForegroundWindow();
    [System.Runtime.InteropServices.DllImport("user32.dll")] static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);
    [System.Runtime.InteropServices.DllImport("user32.dll")] static extern IntPtr GetKeyboardLayout(uint thread);
    public int GetCurrentKeyboardLayout()
    {
        try
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            uint foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);
            int keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;

            if (keyboardLayout == 0)
            {
                // something has gone wrong - just assume English
                keyboardLayout = 1033;
            }
            return keyboardLayout;
        }
        catch (Exception ex)
        {
            // if something goes wrong - just assume English
            return 1033;
        }
    }

    private void CheckKeyboardLayout(object sender)
    {
        var layout = GetCurrentKeyboardLayout();
        if (_currentLayout != layout && KeyboardLayoutChanged != null)
        {
            KeyboardLayoutChanged(_currentLayout, layout);
            _currentLayout = layout;
        }

    }

    private void ReleaseUnmanagedResources()
    {
        _timer.Dispose();
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~KeyboardLayoutWatcher()
    {
        ReleaseUnmanagedResources();
    }
}
