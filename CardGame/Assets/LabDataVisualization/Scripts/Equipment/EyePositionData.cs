using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSync;

public class EyePositonData : LabDataBase
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public string FocusObject { get; set; }
    public float Pupil_Diameter_Left { get; set; }
    public float Eye_Openness_Left { get; set; }
    public float Pupil_Diameter_Right { get; set; }
    public float Eye_Openness_Right { get; set; }
    public float Pupil_Diameter_Combined { get; set; }
    public float Eye_Openness_Combined { get; set; }
}
