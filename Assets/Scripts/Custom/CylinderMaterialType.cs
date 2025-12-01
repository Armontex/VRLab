using System;
using UnityEngine;

namespace UnityEngine.Custom
{
    public enum CylinderMaterialType
    {
        Wood,     // 7000
        Gold,     // 19300 
        Platinum, // 21500
        Lead,     // 11300
        Copper,   // 8900
        Brass,    // 8500
        Iron,     // 7800
        Tin,      // 7300
        Marble,   // 2700
        Silver    // 10500
    }

    public static class CylinderMaterialTypeExtension
    {
        public static double GetDensity(this CylinderMaterialType type)
        {
            return type switch
            {
                CylinderMaterialType.Wood => 700,
                CylinderMaterialType.Gold => 19300,
                CylinderMaterialType.Platinum => 21500,
                CylinderMaterialType.Lead => 11300,
                CylinderMaterialType.Copper => 8900,
                CylinderMaterialType.Brass => 8500,
                CylinderMaterialType.Iron => 7800,
                CylinderMaterialType.Tin => 7300,
                CylinderMaterialType.Marble => 2700,
                CylinderMaterialType.Silver => 10500,
                _ => throw new NotImplementedException(),
            };
        }
    }
}

