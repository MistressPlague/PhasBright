using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PhasBright
{
    public class PhasBrightByPlague : MelonMod
    {
        public static bool FullBright = false;

        public override void OnGUI()
        {
            if (GUI.Toggle(new Rect(10, 10, 150, 25), FullBright, "Fullbright") != FullBright)
            {
                FullBright = !FullBright;

                ToggleFullBright(FullBright);
            }
        }

        public override void OnLevelWasLoaded(int level)
        {
            if (FullBright)
            {
                ToggleFullBright(FullBright);
            }
        }

        public void ToggleFullBright(bool state)
        {
            Player LocalPlayer = Helpers.GetLocalPlayer();

            if (LocalPlayer == null)
            {
                return;
            }

            var boneTransform = LocalPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head);

            if (boneTransform == null)
            {
                return;
            }

            var light = boneTransform.GetComponent<Light>();

            if (state)
            {
                light = boneTransform.gameObject.AddComponent<Light>();

                light.color = Color.white;
                light.type = LightType.Spot;
                light.shadows = LightShadows.None;
                light.range = 99f;
                light.spotAngle = 9999f;
                light.intensity = 0.3f;
            }
            else
            {
                Object.Destroy(light);
            }
        }
    }
}
