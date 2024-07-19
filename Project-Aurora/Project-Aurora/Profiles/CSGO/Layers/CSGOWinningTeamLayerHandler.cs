﻿using System.Drawing;
using System.Windows.Controls;
using AuroraRgb.EffectsEngine;
using AuroraRgb.Profiles.CSGO.GSI;
using AuroraRgb.Profiles.CSGO.GSI.Nodes;
using AuroraRgb.Settings.Layers;
using Newtonsoft.Json;

namespace AuroraRgb.Profiles.CSGO.Layers;

public partial class CSGOWinningTeamLayerHandlerProperties : LayerHandlerProperties2Color<CSGOWinningTeamLayerHandlerProperties>
{
    private Color? _ctColor;

    [JsonProperty("_CTColor")]
    public Color CtColor
    {
        get => Logic?.CtColor ?? _ctColor ?? Color.Empty;
        set => _ctColor  = value;
    }

    private Color? _tColor;

    [JsonProperty("_TColor")]
    public Color TColor => Logic?._TColor ?? _tColor ?? Color.Empty;

    public CSGOWinningTeamLayerHandlerProperties()
    { }

    public CSGOWinningTeamLayerHandlerProperties(bool assignDefault = false) : base(assignDefault) { }

    public override void Default()
    {
        base.Default();

        _ctColor = Color.FromArgb(33, 155, 221);
        _tColor = Color.FromArgb(221, 99, 33);
    }

}

public class CSGOWinningTeamLayerHandler() : LayerHandler<CSGOWinningTeamLayerHandlerProperties>("CSGO - Winning Team Effect")
{
    private readonly SolidBrush _solidBrush = new(Color.Empty);

    protected override UserControl CreateControl()
    {
        return new Control_CSGOWinningTeamLayer(this);
    }

    public override EffectLayer Render(IGameState state)
    {
        if (state is not GameStateCsgo csgostate) return EffectLayer.EmptyLayer;

        // Block animations after end of round
        if (csgostate.Map.Phase == MapPhase.Undefined || csgostate.Round.Phase != RoundPhase.Over)
        {
            return EffectLayer.EmptyLayer;
        }

        _solidBrush.Color = Color.White;

        // Triggers directly after a team wins a round
        if (csgostate.Round.WinTeam != RoundWinTeam.Undefined && csgostate.Previously?.Round.WinTeam == RoundWinTeam.Undefined)
        {
            // Determine round or game winner
            if (csgostate.Map.Phase == MapPhase.GameOver)
            {
                // End of match
                var tScore = csgostate.Map.TeamT.Score;
                var ctScore = csgostate.Map.TeamCT.Score;

                if (tScore > ctScore)
                {
                    _solidBrush.Color = Properties.TColor;
                }
                else if (ctScore > tScore)
                {
                    _solidBrush.Color = Properties.CtColor;
                }
            }
            else
            {
                _solidBrush.Color = csgostate.Round.WinTeam switch
                {
                    // End of round
                    RoundWinTeam.T => Properties.TColor,
                    RoundWinTeam.CT => Properties.CtColor,
                    _ => _solidBrush.Color
                };
            }
        }

        EffectLayer.Fill(_solidBrush);

        return EffectLayer;
    }
}