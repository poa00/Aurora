﻿using System.Collections.Generic;
using AuroraRgb.Modules.Logitech.Enums;
using Common.Devices;
using Microsoft.Collections.Extensions;
using RGB.NET.Devices.Logitech;

namespace AuroraRgb.Modules.Logitech;

internal static class LedMapping
{
    internal static readonly Dictionary<LogitechLedId, DeviceKeys> LogitechLedIds = new()
    {
        { LogitechLedId.ESC,					DeviceKeys.ESC },
        { LogitechLedId.F1,						DeviceKeys.F1 },
        { LogitechLedId.F2,						DeviceKeys.F2 },
        { LogitechLedId.F3,						DeviceKeys.F3 },
        { LogitechLedId.F4,						DeviceKeys.F4 },
        { LogitechLedId.F5,						DeviceKeys.F5 },
        { LogitechLedId.F6,						DeviceKeys.F6 },
        { LogitechLedId.F7,						DeviceKeys.F7 },
        { LogitechLedId.F8,						DeviceKeys.F8 },
        { LogitechLedId.F9,						DeviceKeys.F9 },
        { LogitechLedId.F10,					DeviceKeys.F10 },
        { LogitechLedId.F11,					DeviceKeys.F11 },
        { LogitechLedId.TILDE,					DeviceKeys.TILDE },
        { LogitechLedId.ONE,					DeviceKeys.ONE },
        { LogitechLedId.TWO,					DeviceKeys.TWO },
        { LogitechLedId.THREE,					DeviceKeys.THREE },
        { LogitechLedId.FOUR,					DeviceKeys.FOUR },
        { LogitechLedId.FIVE,					DeviceKeys.FIVE },
        { LogitechLedId.SIX,					DeviceKeys.SIX },
        { LogitechLedId.SEVEN,					DeviceKeys.SEVEN },
        { LogitechLedId.EIGHT,					DeviceKeys.EIGHT },
        { LogitechLedId.NINE,					DeviceKeys.NINE },
        { LogitechLedId.ZERO,					DeviceKeys.ZERO },
        { LogitechLedId.MINUS,					DeviceKeys.MINUS },
        { LogitechLedId.TAB,					DeviceKeys.TAB },
        { LogitechLedId.Q,						DeviceKeys.Q },
        { LogitechLedId.W,						DeviceKeys.W },
        { LogitechLedId.E,						DeviceKeys.E },
        { LogitechLedId.R,						DeviceKeys.R },
        { LogitechLedId.T,						DeviceKeys.T },
        { LogitechLedId.Y,						DeviceKeys.Y },
        { LogitechLedId.U,						DeviceKeys.U },
        { LogitechLedId.I,						DeviceKeys.I },
        { LogitechLedId.O,						DeviceKeys.O },
        { LogitechLedId.P,						DeviceKeys.P },
        { LogitechLedId.OPEN_BRACKET,			DeviceKeys.OPEN_BRACKET },
        { LogitechLedId.CAPS_LOCK,				DeviceKeys.CAPS_LOCK },
        { LogitechLedId.A,						DeviceKeys.A },
        { LogitechLedId.S,						DeviceKeys.S },
        { LogitechLedId.D,						DeviceKeys.D },
        { LogitechLedId.F,						DeviceKeys.F },
        { LogitechLedId.G,						DeviceKeys.G },
        { LogitechLedId.H,						DeviceKeys.H },
        { LogitechLedId.J,						DeviceKeys.J },
        { LogitechLedId.K,						DeviceKeys.K },
        { LogitechLedId.L,						DeviceKeys.L },
        { LogitechLedId.SEMICOLON,				DeviceKeys.SEMICOLON },
        { LogitechLedId.APOSTROPHE,				DeviceKeys.APOSTROPHE },
        { LogitechLedId.LEFT_SHIFT,				DeviceKeys.LEFT_SHIFT },
        { LogitechLedId.Z,						DeviceKeys.Z },
        { LogitechLedId.X,						DeviceKeys.X },
        { LogitechLedId.C,						DeviceKeys.C },
        { LogitechLedId.V,						DeviceKeys.V },
        { LogitechLedId.B,						DeviceKeys.B },
        { LogitechLedId.N,						DeviceKeys.N },
        { LogitechLedId.M,						DeviceKeys.M },
        { LogitechLedId.COMMA,					DeviceKeys.COMMA },
        { LogitechLedId.PERIOD,					DeviceKeys.PERIOD },
        { LogitechLedId.FORWARD_SLASH,			DeviceKeys.FORWARD_SLASH },
        { LogitechLedId.LEFT_CONTROL,			DeviceKeys.LEFT_CONTROL },
        { LogitechLedId.LEFT_WINDOWS,			DeviceKeys.LEFT_WINDOWS },
        { LogitechLedId.LEFT_ALT,				DeviceKeys.LEFT_ALT },
        { LogitechLedId.SPACE,					DeviceKeys.SPACE },
        { LogitechLedId.RIGHT_ALT,				DeviceKeys.RIGHT_ALT },
        { LogitechLedId.RIGHT_WINDOWS,			DeviceKeys.RIGHT_WINDOWS },
        { LogitechLedId.APPLICATION_SELECT,		DeviceKeys.APPLICATION_SELECT },
        { LogitechLedId.F12,					DeviceKeys.F12 },
        { LogitechLedId.PRINT_SCREEN,			DeviceKeys.PRINT_SCREEN },
        { LogitechLedId.SCROLL_LOCK,			DeviceKeys.SCROLL_LOCK },
        { LogitechLedId.PAUSE_BREAK,			DeviceKeys.PAUSE_BREAK },
        { LogitechLedId.INSERT,					DeviceKeys.INSERT },
        { LogitechLedId.HOME,					DeviceKeys.HOME },
        { LogitechLedId.PAGE_UP,				DeviceKeys.PAGE_UP },
        { LogitechLedId.CLOSE_BRACKET,			DeviceKeys.CLOSE_BRACKET },
        { LogitechLedId.BACKSLASH,				DeviceKeys.BACKSLASH_UK },
        { LogitechLedId.ISO_TILDE,				DeviceKeys.OEMTilde },
        { LogitechLedId.ENTER,					DeviceKeys.ENTER },
        { LogitechLedId.EQUALS,					DeviceKeys.EQUALS },
        { LogitechLedId.BACKSPACE,				DeviceKeys.BACKSPACE },
        { LogitechLedId.KEYBOARD_DELETE,		DeviceKeys.DELETE },
        { LogitechLedId.END,					DeviceKeys.END },
        { LogitechLedId.PAGE_DOWN,				DeviceKeys.PAGE_DOWN },
        { LogitechLedId.RIGHT_SHIFT,			DeviceKeys.RIGHT_SHIFT },
        { LogitechLedId.RIGHT_CONTROL,			DeviceKeys.RIGHT_CONTROL },
        { LogitechLedId.ARROW_UP,				DeviceKeys.ARROW_UP },
        { LogitechLedId.ARROW_LEFT,				DeviceKeys.ARROW_LEFT },
        { LogitechLedId.ARROW_DOWN,				DeviceKeys.ARROW_DOWN },
        { LogitechLedId.ARROW_RIGHT,			DeviceKeys.ARROW_RIGHT },
        { LogitechLedId.NUM_LOCK,				DeviceKeys.NUM_LOCK },
        { LogitechLedId.NUM_SLASH,				DeviceKeys.NUM_SLASH },
        { LogitechLedId.NUM_ASTERISK,			DeviceKeys.NUM_ASTERISK },
        { LogitechLedId.NUM_MINUS,				DeviceKeys.NUM_MINUS },
        { LogitechLedId.NUM_PLUS,				DeviceKeys.NUM_PLUS },
        { LogitechLedId.NUM_ENTER,				DeviceKeys.NUM_ENTER },
        { LogitechLedId.NUM_SEVEN,				DeviceKeys.NUM_SEVEN },
        { LogitechLedId.NUM_EIGHT,				DeviceKeys.NUM_EIGHT },
        { LogitechLedId.NUM_NINE,				DeviceKeys.NUM_NINE },
        { LogitechLedId.NUM_FOUR,				DeviceKeys.NUM_FOUR },
        { LogitechLedId.NUM_FIVE,				DeviceKeys.NUM_FIVE },
        { LogitechLedId.NUM_SIX,				DeviceKeys.NUM_SIX },
        { LogitechLedId.NUM_ONE,				DeviceKeys.NUM_ONE },
        { LogitechLedId.NUM_TWO,				DeviceKeys.NUM_TWO },
        { LogitechLedId.NUM_THREE,				DeviceKeys.NUM_THREE },
        { LogitechLedId.NUM_ZERO,				DeviceKeys.NUM_ZERO },
        { LogitechLedId.NUM_PERIOD,				DeviceKeys.NUM_PERIOD },
        { LogitechLedId.G_1,					DeviceKeys.G1 },
        { LogitechLedId.G_2,					DeviceKeys.G2 },
        { LogitechLedId.G_3,					DeviceKeys.G3 },
        { LogitechLedId.G_4,					DeviceKeys.G4 },
        { LogitechLedId.G_5,					DeviceKeys.G5 },
        { LogitechLedId.G_6,					DeviceKeys.G6 },
        { LogitechLedId.G_7,					DeviceKeys.G7 },
        { LogitechLedId.G_8,					DeviceKeys.G8 },
        { LogitechLedId.G_9,					DeviceKeys.G9 },
        { LogitechLedId.G_LOGO,					DeviceKeys.LOGO },
        { LogitechLedId.G_BADGE,				DeviceKeys.LOGOMIDDLE },
    };

    internal static readonly Dictionary<DirectInputScanCode, DeviceKeys> DirectInputScanCodes = new()
    {
        [DirectInputScanCode.DIK_ESCAPE] =			DeviceKeys.ESC,
        [DirectInputScanCode.DIK_1] =				DeviceKeys.ONE,
        [DirectInputScanCode.DIK_2] =				DeviceKeys.TWO,
        [DirectInputScanCode.DIK_3] =				DeviceKeys.THREE,
        [DirectInputScanCode.DIK_4] =				DeviceKeys.FOUR,
        [DirectInputScanCode.DIK_5] =				DeviceKeys.FIVE,
        [DirectInputScanCode.DIK_6] =				DeviceKeys.SIX,
        [DirectInputScanCode.DIK_7] =				DeviceKeys.SEVEN,
        [DirectInputScanCode.DIK_8] =				DeviceKeys.EIGHT,
        [DirectInputScanCode.DIK_9] =				DeviceKeys.NINE,
        [DirectInputScanCode.DIK_0] =				DeviceKeys.ZERO,
        [DirectInputScanCode.DIK_MINUS] =			DeviceKeys.MINUS,
        [DirectInputScanCode.DIK_EQUALS] =			DeviceKeys.EQUALS,
        [DirectInputScanCode.DIK_BACK] =			DeviceKeys.BACKSPACE,
        [DirectInputScanCode.DIK_TAB] =				DeviceKeys.TAB,
        [DirectInputScanCode.DIK_Q] =				DeviceKeys.Q,
        [DirectInputScanCode.DIK_W] =				DeviceKeys.W,
        [DirectInputScanCode.DIK_E] =				DeviceKeys.E,
        [DirectInputScanCode.DIK_R] =				DeviceKeys.R,
        [DirectInputScanCode.DIK_T] =				DeviceKeys.T,
        [DirectInputScanCode.DIK_Y] =				DeviceKeys.Y,
        [DirectInputScanCode.DIK_U] =				DeviceKeys.U,
        [DirectInputScanCode.DIK_I] =				DeviceKeys.I,
        [DirectInputScanCode.DIK_O] =				DeviceKeys.O,
        [DirectInputScanCode.DIK_P] =				DeviceKeys.P,
        [DirectInputScanCode.DIK_LBRACKET] =		DeviceKeys.OPEN_BRACKET,
        [DirectInputScanCode.DIK_RBRACKET] =		DeviceKeys.CLOSE_BRACKET,
        [DirectInputScanCode.DIK_RETURN] =			DeviceKeys.ENTER,
        [DirectInputScanCode.DIK_LContol] =			DeviceKeys.LEFT_CONTROL,
        [DirectInputScanCode.DIK_A] =				DeviceKeys.A,
        [DirectInputScanCode.DIK_S] =				DeviceKeys.S,
        [DirectInputScanCode.DIK_D] =				DeviceKeys.D,
        [DirectInputScanCode.DIK_F] =				DeviceKeys.F,
        [DirectInputScanCode.DIK_G] =				DeviceKeys.G,
        [DirectInputScanCode.DIK_H] =				DeviceKeys.H,
        [DirectInputScanCode.DIK_J] =				DeviceKeys.J,
        [DirectInputScanCode.DIK_K] =				DeviceKeys.K,
        [DirectInputScanCode.DIK_L] =				DeviceKeys.L,
        [DirectInputScanCode.DIK_SEMICOLON] =		DeviceKeys.SEMICOLON,
        [DirectInputScanCode.DIK_APOSTROPHE] =		DeviceKeys.APOSTROPHE,
        [DirectInputScanCode.DIK_GRAVE] =			DeviceKeys.TILDE,
        [DirectInputScanCode.DIK_LSHIFT] =			DeviceKeys.LEFT_SHIFT,
        [DirectInputScanCode.DIK_BACKSLASH] =		DeviceKeys.BACKSLASH,
        [DirectInputScanCode.DIK_Z] =				DeviceKeys.Z,
        [DirectInputScanCode.DIK_X] =				DeviceKeys.X,
        [DirectInputScanCode.DIK_C] =				DeviceKeys.C,
        [DirectInputScanCode.DIK_V] =				DeviceKeys.V,
        [DirectInputScanCode.DIK_B] =				DeviceKeys.B,
        [DirectInputScanCode.DIK_N] =				DeviceKeys.N,
        [DirectInputScanCode.DIK_M] =				DeviceKeys.M,
        [DirectInputScanCode.DIK_COMMA] =			DeviceKeys.COMMA,
        [DirectInputScanCode.DIK_PERIOD] =			DeviceKeys.PERIOD,
        [DirectInputScanCode.DIK_SLASH] =			DeviceKeys.FORWARD_SLASH,
        [DirectInputScanCode.DIK_RSHIFT] =			DeviceKeys.RIGHT_SHIFT,
        [DirectInputScanCode.DIK_MULTIPLY] =		DeviceKeys.NUM_ASTERISK,
        [DirectInputScanCode.DIK_LMENU] =			DeviceKeys.LEFT_ALT,
        [DirectInputScanCode.DIK_SPACE] =			DeviceKeys.SPACE,
        [DirectInputScanCode.DIK_CAPITAL] =			DeviceKeys.CAPS_LOCK,
        [DirectInputScanCode.DIK_F1] =				DeviceKeys.F1,
        [DirectInputScanCode.DIK_F2] =				DeviceKeys.F2,
        [DirectInputScanCode.DIK_F3] =				DeviceKeys.F3,
        [DirectInputScanCode.DIK_F4] =				DeviceKeys.F4,
        [DirectInputScanCode.DIK_F5] =				DeviceKeys.F5,
        [DirectInputScanCode.DIK_F6] =				DeviceKeys.F6,
        [DirectInputScanCode.DIK_F7] =				DeviceKeys.F7,
        [DirectInputScanCode.DIK_F8] =				DeviceKeys.F8,
        [DirectInputScanCode.DIK_F9] =				DeviceKeys.F9,
        [DirectInputScanCode.DIK_F10] =				DeviceKeys.F10,
        [DirectInputScanCode.DIK_NUMLOCK] =			DeviceKeys.NUM_LOCK,
        [DirectInputScanCode.DIK_SCROLL] =			DeviceKeys.SCROLL_LOCK,
        [DirectInputScanCode.DIK_NUMPAD7] =			DeviceKeys.NUM_SEVEN,
        [DirectInputScanCode.DIK_NUMPAD8] =			DeviceKeys.NUM_EIGHT,
        [DirectInputScanCode.DIK_NUMPAD9] =			DeviceKeys.NUM_NINE,
        [DirectInputScanCode.DIK_SUBTRACT] =		DeviceKeys.NUM_MINUS,
        [DirectInputScanCode.DIK_NUMPAD4] =			DeviceKeys.NUM_FOUR,
        [DirectInputScanCode.DIK_NUMPAD5] =			DeviceKeys.NUM_FIVE,
        [DirectInputScanCode.DIK_NUMPAD6] =			DeviceKeys.NUM_SIX,
        [DirectInputScanCode.DIK_ADD] =				DeviceKeys.NUM_PLUS,
        [DirectInputScanCode.DIK_NUMPAD1] =			DeviceKeys.NUM_ONE,
        [DirectInputScanCode.DIK_NUMPAD2] =			DeviceKeys.NUM_TWO,
        [DirectInputScanCode.DIK_NUMPAD3] =			DeviceKeys.NUM_THREE,
        [DirectInputScanCode.DIK_NUMPAD0] =			DeviceKeys.NUM_ZERO,
        [DirectInputScanCode.DIK_DECIMAL] =			DeviceKeys.NUM_PERIOD,
        [DirectInputScanCode.DIK_F11] =				DeviceKeys.F11,
        [DirectInputScanCode.DIK_F12] =				DeviceKeys.F12,
        [DirectInputScanCode.DIK_NUMPADENTER] =		DeviceKeys.NUM_ENTER,
        [DirectInputScanCode.DIK_RCONTROL] =		DeviceKeys.RIGHT_CONTROL,
        [DirectInputScanCode.DIK_DIVIDE] =			DeviceKeys.NUM_SLASH,
        [DirectInputScanCode.DIK_RMENU] =			DeviceKeys.RIGHT_ALT,
        [DirectInputScanCode.DIK_PAUSE] =			DeviceKeys.PAUSE_BREAK,
        [DirectInputScanCode.DIK_HOME] =			DeviceKeys.HOME,
        [DirectInputScanCode.DIK_UP] =				DeviceKeys.ARROW_UP,
        [DirectInputScanCode.DIK_PRIOR] =			DeviceKeys.PAGE_UP,
        [DirectInputScanCode.DIK_LEFT] =			DeviceKeys.ARROW_LEFT,
        [DirectInputScanCode.DIK_RIGHT] =			DeviceKeys.ARROW_RIGHT,
        [DirectInputScanCode.DIK_END] =				DeviceKeys.END,
        [DirectInputScanCode.DIK_DOWN] =			DeviceKeys.ARROW_DOWN,
        [DirectInputScanCode.DIK_NEXT] =			DeviceKeys.PAGE_DOWN,
        [DirectInputScanCode.DIK_INSERT] =			DeviceKeys.INSERT,
        [DirectInputScanCode.DIK_DELETE] =			DeviceKeys.DELETE,
        [DirectInputScanCode.DIK_LWIN] =			DeviceKeys.LEFT_WINDOWS,
        [DirectInputScanCode.DIK_RWIN] =			DeviceKeys.RIGHT_WINDOWS,
        [DirectInputScanCode.DIK_APPS] =			DeviceKeys.APPLICATION_SELECT,
    };

    internal static readonly Dictionary<int, DeviceKeys> BitmapMap = new()
    {
        [0] =			DeviceKeys.ESC,
        [1] =			DeviceKeys.F1,
        [2] =			DeviceKeys.F2,
        [3] =			DeviceKeys.F3,
        [4] =			DeviceKeys.F4,
        [5] =			DeviceKeys.F5,
        [6] =			DeviceKeys.F6,
        [7] =			DeviceKeys.F7,
        [8] =			DeviceKeys.F8,
        [9] =			DeviceKeys.F9,
        [10] =			DeviceKeys.F10,
        [11] =			DeviceKeys.F11,
        [12] =			DeviceKeys.F12,
        [13] =			DeviceKeys.PRINT_SCREEN,
        [14] =			DeviceKeys.SCROLL_LOCK,
        [15] =			DeviceKeys.PAUSE_BREAK,

        [21] =			DeviceKeys.TILDE,
        [22] =			DeviceKeys.ONE,
        [23] =			DeviceKeys.TWO,
        [24] =			DeviceKeys.THREE,
        [25] =			DeviceKeys.FOUR,
        [26] =			DeviceKeys.FIVE,
        [27] =			DeviceKeys.SIX,
        [28] =			DeviceKeys.SEVEN,
        [29] =			DeviceKeys.EIGHT,
        [30] =			DeviceKeys.NINE,
        [31] =			DeviceKeys.ZERO,
        [32] =			DeviceKeys.MINUS,
        [33] =			DeviceKeys.EQUALS,
        [34] =			DeviceKeys.BACKSPACE,
        [35] =			DeviceKeys.INSERT,
        [36] =			DeviceKeys.HOME,
        [37] =			DeviceKeys.PAGE_UP,
        [38] =			DeviceKeys.NUM_LOCK,
        [39] =			DeviceKeys.NUM_SLASH,
        [40] =			DeviceKeys.NUM_ASTERISK,
        [41] =			DeviceKeys.NUM_MINUS,
        [42] =			DeviceKeys.TAB,
        [43] =			DeviceKeys.Q,
        [44] =			DeviceKeys.W,
        [45] =			DeviceKeys.E,
        [46] =			DeviceKeys.R,
        [47] =			DeviceKeys.T,
        [48] =			DeviceKeys.Y,
        [49] =			DeviceKeys.U,
        [50] =			DeviceKeys.I,
        [51] =			DeviceKeys.O,
        [52] =			DeviceKeys.P,
        [53] =			DeviceKeys.OPEN_BRACKET,
        [54] =			DeviceKeys.CLOSE_BRACKET,
        [55] =			DeviceKeys.FORWARD_SLASH,
        [56] =			DeviceKeys.DELETE,
        [57] =			DeviceKeys.END,
        [58] =			DeviceKeys.PAGE_DOWN,
        [59] =			DeviceKeys.NUM_SEVEN,
        [60] =			DeviceKeys.NUM_EIGHT,
        [61] =			DeviceKeys.NUM_NINE,
        [62] =			DeviceKeys.NUM_PLUS,
        [63] =			DeviceKeys.CAPS_LOCK,
        [64] =			DeviceKeys.A,
        [65] =			DeviceKeys.S,
        [66] =			DeviceKeys.D,
        [67] =			DeviceKeys.F,
        [68] =			DeviceKeys.G,
        [69] =			DeviceKeys.H,
        [70] =			DeviceKeys.J,
        [71] =			DeviceKeys.K,
        [72] =			DeviceKeys.L,
        [73] =			DeviceKeys.SEMICOLON,
        [74] =			DeviceKeys.APOSTROPHE,
        [75] =			DeviceKeys.HASHTAG,
        [76] =			DeviceKeys.ENTER,

        [80] =			DeviceKeys.NUM_FOUR,
        [81] =			DeviceKeys.NUM_FIVE,
        [82] =			DeviceKeys.NUM_SIX,
        [84] =			DeviceKeys.LEFT_SHIFT,
        [85] =			DeviceKeys.BACKSLASH_UK,
        [86] =			DeviceKeys.Z,
        [87] =			DeviceKeys.X,
        [88] =			DeviceKeys.C,
        [89] =			DeviceKeys.V,
        [90] =			DeviceKeys.B,
        [91] =			DeviceKeys.N,
        [92] =			DeviceKeys.M,
        [93] =			DeviceKeys.COMMA,
        [94] =			DeviceKeys.PERIOD,
        [95] =			DeviceKeys.FORWARD_SLASH,

        [97] =			DeviceKeys.RIGHT_SHIFT,
        [99] =			DeviceKeys.ARROW_UP,
        [101] =			DeviceKeys.NUM_ONE,
        [102] =			DeviceKeys.NUM_TWO,
        [103] =			DeviceKeys.NUM_THREE,
        [104] =			DeviceKeys.NUM_ENTER,
        [105] =			DeviceKeys.LEFT_CONTROL,
        [106] =			DeviceKeys.LEFT_WINDOWS,
        [107] =			DeviceKeys.LEFT_ALT,
        [110] =			DeviceKeys.SPACE,
        [116] =			DeviceKeys.RIGHT_ALT,
        [117] =			DeviceKeys.RIGHT_WINDOWS,
        [118] =			DeviceKeys.APPLICATION_SELECT,
        [119] =			DeviceKeys.RIGHT_CONTROL,
        [120] =			DeviceKeys.ARROW_LEFT,
        [121] =			DeviceKeys.ARROW_DOWN,
        [122] =			DeviceKeys.ARROW_RIGHT,
        [123] =			DeviceKeys.NUM_ZERO,
        [124] =			DeviceKeys.NUM_PERIOD,
    };

    internal static readonly Dictionary<HidCode, DeviceKeys> HidCodes = new()
    {
        [HidCode.KEY_ESC] =			DeviceKeys.ESC,
        [HidCode.KEY_F1] =			DeviceKeys.F1,
        [HidCode.KEY_F2] =			DeviceKeys.F2,
        [HidCode.KEY_F3] =			DeviceKeys.F3,
        [HidCode.KEY_F4] =			DeviceKeys.F4,
        [HidCode.KEY_F5] =			DeviceKeys.F5,
        [HidCode.KEY_F6] =			DeviceKeys.F6,
        [HidCode.KEY_F7] =			DeviceKeys.F7,
        [HidCode.KEY_F8] =			DeviceKeys.F8,
        [HidCode.KEY_F10] =			DeviceKeys.F10,
        [HidCode.KEY_F11] =			DeviceKeys.F11,
        [HidCode.KEY_F12] =			DeviceKeys.F12,
        [HidCode.KEY_SYSRQ] =		DeviceKeys.PRINT_SCREEN,
        [HidCode.KEY_SCROLLLOCK] =	DeviceKeys.SCROLL_LOCK,
        [HidCode.KEY_PAUSE] =		DeviceKeys.PAUSE_BREAK,
        [HidCode.KEY_GRAVE] =		DeviceKeys.TILDE,
        [HidCode.KEY_1] =			DeviceKeys.ONE,
        [HidCode.KEY_2] =			DeviceKeys.TWO,
        [HidCode.KEY_3] =			DeviceKeys.THREE,
        [HidCode.KEY_4] =			DeviceKeys.FOUR,
        [HidCode.KEY_5] =			DeviceKeys.FIVE,
        [HidCode.KEY_6] =			DeviceKeys.SIX,
        [HidCode.KEY_7] =			DeviceKeys.SEVEN,
        [HidCode.KEY_8] =			DeviceKeys.EIGHT,
        [HidCode.KEY_9] =			DeviceKeys.NINE,
        [HidCode.KEY_0] =			DeviceKeys.ZERO,
        [HidCode.KEY_MINUS] =		DeviceKeys.MINUS,
        [HidCode.KEY_EQUAL] =		DeviceKeys.EQUALS,
        [HidCode.KEY_BACKSPACE] =	DeviceKeys.BACKSPACE,
        [HidCode.KEY_INSERT] =		DeviceKeys.INSERT,
        [HidCode.KEY_HOME] =		DeviceKeys.HOME,
        [HidCode.KEY_PAGEUP] =		DeviceKeys.PAGE_UP,
        [HidCode.KEY_NUMLOCK] =		DeviceKeys.NUM_LOCK,
        [HidCode.KEY_KPSLASH] =		DeviceKeys.NUM_SLASH,
        [HidCode.KEY_KPASTERISK] =	DeviceKeys.NUM_ASTERISK,
        [HidCode.KEY_KPMINUS] =		DeviceKeys.NUM_MINUS,
        [HidCode.KEY_TAB] =			DeviceKeys.TAB,
        [HidCode.KEY_Q] =			DeviceKeys.Q,
        [HidCode.KEY_W] =			DeviceKeys.W,
        [HidCode.KEY_E] =			DeviceKeys.E,
        [HidCode.KEY_R] =			DeviceKeys.R,
        [HidCode.KEY_T] =			DeviceKeys.T,
        [HidCode.KEY_Y] =			DeviceKeys.Y,
        [HidCode.KEY_U] =			DeviceKeys.U,
        [HidCode.KEY_I] =			DeviceKeys.I,
        [HidCode.KEY_O] =			DeviceKeys.O,
        [HidCode.KEY_P] =			DeviceKeys.P,
        [HidCode.KEY_LEFTBRACE] =	DeviceKeys.OPEN_BRACKET,
        [HidCode.KEY_RIGHTBRACE] =	DeviceKeys.CLOSE_BRACKET,
        [HidCode.KEY_BACKSLASH] =	DeviceKeys.BACKSLASH_UK,
        [HidCode.KEY_DELETE] =		DeviceKeys.DELETE,
        [HidCode.KEY_END] =			DeviceKeys.END,
        [HidCode.KEY_PAGEDOWN] =	DeviceKeys.PAGE_DOWN,
        [HidCode.KEY_KP7] =			DeviceKeys.NUM_SEVEN,
        [HidCode.KEY_KP8] =			DeviceKeys.NUM_EIGHT,
        [HidCode.KEY_KP9] =			DeviceKeys.NUM_NINE,
        [HidCode.KEY_KPPLUS] =		DeviceKeys.NUM_PLUS,
        [HidCode.KEY_CAPSLOCK] =	DeviceKeys.CAPS_LOCK,
        [HidCode.KEY_A] =			DeviceKeys.A,
        [HidCode.KEY_S] =			DeviceKeys.S,
        [HidCode.KEY_D] =			DeviceKeys.D,
        [HidCode.KEY_F] =			DeviceKeys.F,
        [HidCode.KEY_G] =			DeviceKeys.G,
        [HidCode.KEY_H] =			DeviceKeys.H,
        [HidCode.KEY_J] =			DeviceKeys.J,
        [HidCode.KEY_K] =			DeviceKeys.K,
        [HidCode.KEY_L] =			DeviceKeys.L,
        [HidCode.KEY_SEMICOLON] =	DeviceKeys.SEMICOLON,
        [HidCode.KEY_APOSTROPHE] =	DeviceKeys.APOSTROPHE,
        [HidCode.KEY_ENTER] =		DeviceKeys.ENTER,
        [HidCode.KEY_KP4] =			DeviceKeys.NUM_FOUR,
        [HidCode.KEY_KP5] =			DeviceKeys.NUM_FIVE,
        [HidCode.KEY_KP6] =			DeviceKeys.NUM_SIX,
        [HidCode.KEY_LEFTSHIFT] =	DeviceKeys.LEFT_SHIFT,
        [HidCode.KEY_Z] =			DeviceKeys.Z,
        [HidCode.KEY_X] =			DeviceKeys.X,
        [HidCode.KEY_C] =			DeviceKeys.C,
        [HidCode.KEY_V] =			DeviceKeys.V,
        [HidCode.KEY_B] =			DeviceKeys.B,
        [HidCode.KEY_N] =			DeviceKeys.N,
        [HidCode.KEY_M] =			DeviceKeys.M,
        [HidCode.KEY_COMMA] =		DeviceKeys.COMMA,
        [HidCode.KEY_DOT] =			DeviceKeys.PERIOD,
        [HidCode.KEY_SLASH] =		DeviceKeys.FORWARD_SLASH,
        [HidCode.KEY_RIGHTSHIFT] =	DeviceKeys.RIGHT_SHIFT,
        [HidCode.KEY_UP] =			DeviceKeys.ARROW_UP,
        [HidCode.KEY_KP1] =			DeviceKeys.NUM_ONE,
        [HidCode.KEY_KP2] =			DeviceKeys.NUM_TWO,
        [HidCode.KEY_KP3] =			DeviceKeys.NUM_THREE,
        [HidCode.KEY_KPENTER] =		DeviceKeys.NUM_ENTER,
        [HidCode.KEY_LEFTCTRL] =	DeviceKeys.LEFT_CONTROL,
        [HidCode.KEY_LEFTMETA] =	DeviceKeys.LEFT_WINDOWS,
        [HidCode.KEY_LEFTALT] =		DeviceKeys.LEFT_ALT,
        [HidCode.KEY_SPACE] =		DeviceKeys.SPACE,
        [HidCode.KEY_RIGHTALT] =	DeviceKeys.RIGHT_ALT,
        [HidCode.KEY_RIGHTMETA] =	DeviceKeys.RIGHT_WINDOWS,
        [HidCode.KEY_RIGHTCTRL] =	DeviceKeys.RIGHT_CONTROL,
        [HidCode.KEY_LEFT] =		DeviceKeys.ARROW_LEFT,
        [HidCode.KEY_DOWN] =		DeviceKeys.ARROW_DOWN,
        [HidCode.KEY_RIGHT] =		DeviceKeys.ARROW_RIGHT,
        [HidCode.KEY_KPDOT] =		DeviceKeys.NUM_ZERO,
        [HidCode.KEY_KP0] =			DeviceKeys.NUM_PERIOD,
    };
    
    internal static readonly MultiValueDictionary<int, DeviceKeys> MouseZoneKeys = new()
    {
        { 0, DeviceKeys.Peripheral },
        { 0, DeviceKeys.Peripheral_Logo },
        { 0, DeviceKeys.Peripheral_FrontLight },
        { 0, DeviceKeys.Peripheral_ScrollWheel },
        { 0, DeviceKeys.PERIPHERAL_DPI },
        { 0, DeviceKeys.PERIPHERAL_LIGHT1 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT2 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT3 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT4 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT5 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT6 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT7 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT8 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT9 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT10 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT11 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT12 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT13 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT14 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT15 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT16 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT17 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT18 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT19 },
        { 0, DeviceKeys.PERIPHERAL_LIGHT20 },
        
        { 1, DeviceKeys.Peripheral_Logo },
        { 1, DeviceKeys.PERIPHERAL_LIGHT2 },
        { 2, DeviceKeys.Peripheral_ScrollWheel },
        { 2, DeviceKeys.PERIPHERAL_LIGHT3 },
    };

    internal static readonly MultiValueDictionary<int, DeviceKeys> MousepadZoneKeys = new()
    {
        { 0, DeviceKeys.MOUSEPADLIGHT1 },
        { 0, DeviceKeys.MOUSEPADLIGHT2 },
        { 0, DeviceKeys.MOUSEPADLIGHT3 },
        { 0, DeviceKeys.MOUSEPADLIGHT4 },
        { 0, DeviceKeys.MOUSEPADLIGHT5 },
        { 0, DeviceKeys.MOUSEPADLIGHT6 },
        { 0, DeviceKeys.MOUSEPADLIGHT7 },
        { 0, DeviceKeys.MOUSEPADLIGHT8 },
        { 0, DeviceKeys.MOUSEPADLIGHT9 },
        { 0, DeviceKeys.MOUSEPADLIGHT10 },
        { 0, DeviceKeys.MOUSEPADLIGHT11 },
        { 0, DeviceKeys.MOUSEPADLIGHT12 },
        { 0, DeviceKeys.MOUSEPADLIGHT13 },
        { 0, DeviceKeys.MOUSEPADLIGHT14 },
        { 0, DeviceKeys.MOUSEPADLIGHT15 },
        { 0, DeviceKeys.MOUSEPADLIGHT16 },
        { 0, DeviceKeys.MOUSEPADLIGHT17 },
        { 0, DeviceKeys.MOUSEPADLIGHT18 },
        { 0, DeviceKeys.MOUSEPADLIGHT19 },
        { 0, DeviceKeys.MOUSEPADLIGHT20 },
    };

    internal static readonly MultiValueDictionary<int, DeviceKeys> HeadsetZoneKeys = new()
    {
        { 0, DeviceKeys.HEADSET1 },
        { 1, DeviceKeys.HEADSET2 },
        { 0, DeviceKeys.HEADSET3 },
        { 1, DeviceKeys.HEADSET4 },
        { 1, DeviceKeys.HEADSET5 },
    };
    
    internal static readonly MultiValueDictionary<int, DeviceKeys> SpeakerZoneKeys = new()
    {
        { 0, DeviceKeys.CL1 },
        { 0, DeviceKeys.CL2 },
        { 1, DeviceKeys.CL3 },
        { 2, DeviceKeys.CL4 },
        { 3, DeviceKeys.CL5 },
    };

    internal static readonly MultiValueDictionary<int, DeviceKeys> KeyboardZoneKeys = new()
    {
        //{ 0, DeviceKeys.ADDITIONALLIGHT1 },
        //{ 1, DeviceKeys.ADDITIONALLIGHT2 },
        //{ 2, DeviceKeys.ADDITIONALLIGHT3 },
        //{ 3, DeviceKeys.ADDITIONALLIGHT4 },
        //{ 4, DeviceKeys.ADDITIONALLIGHT5 },
    };
}