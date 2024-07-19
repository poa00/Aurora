﻿using System.Drawing;
using AuroraRgb.Settings.Overrides;
using Common.Utils;
using Newtonsoft.Json;

namespace AuroraRgb.Settings.Layers;

public partial class LayerHandlerProperties2Color<TProperty>(bool assignDefault = false) : LayerHandlerProperties<TProperty>(assignDefault)
    where TProperty : LayerHandlerProperties2Color<TProperty>
{
    private Color? _secondaryColor;

    [JsonProperty("_SecondaryColor")]
    [LogicOverridable("Secondary Color")]
    public Color SecondaryColor
    {
        get => Logic?.SecondaryColor ?? _secondaryColor ?? Color.Empty;
        set => _secondaryColor = value;
    }

    public override void Default()
    {
        base.Default();
        SecondaryColor = CommonColorUtils.GenerateRandomColor();
    }
}