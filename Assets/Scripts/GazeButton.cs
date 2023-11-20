using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class GazeButton : GazeObject
{
    // Colour change
    private MeshRenderer meshRenderer = null;
    private Color colour;
    [HideInInspector] public float gradientControl;
    [Tooltip("True = Turns green - False = Turns red")] public bool isGood = false;
    public bool dontChangeOnFull = true;
    [Tooltip("Speed of red gain/decay - Lower is slower")] public float colourChangeMultiplier = 1;
    [Tooltip("True = Reduce red when looking away")] public bool lookAway = true;

    private void Awake()
    {
        InitGazeButton();
    }

    private void FixedUpdate()
    {
        ColourChange();
    }

    private void Update()
    {
        // Apply colour change in update
        meshRenderer.material.color = colour;
    }

    public void ColourChange()
    {
        // Dont change if full
        if (dontChangeOnFull && gradientControl > 0)
        {
            // Changes colour as the user is looking at/away from it
            if (gazeAware.HasGazeFocus && gradientControl > 0)
            {
                // More red as it is looked at
                gradientControl -= Time.deltaTime * colourChangeMultiplier;
            }
            else if (lookAway && gradientControl < 1)
            {
                // Less red as it is looked away
                gradientControl += Time.deltaTime * colourChangeMultiplier;
            }
        }

        // Good or bad?
        if (isGood)
        {
            // Lowers R and B values to go from white to green
            colour = new Color(gradientControl, 1, gradientControl, 1);
        }
        else
        {
            // Lowers G and B values to go from white to red
            colour = new Color(1, gradientControl, gradientControl, 1);
        }
    }

    public void InitGazeButton()
    {
        // Eyetracking
        gazeAware = GetComponent<GazeAware>();

        // Colour change
        meshRenderer = GetComponent<MeshRenderer>();
        gradientControl = 1;
        colour = new Color(1, 1, 1, 1);
    }
}
