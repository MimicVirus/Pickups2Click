using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using Pickups2Click;
using VRC.SDKBase;

[assembly: MelonInfo(typeof(MainLoader), "Pickups2Click", "1.0", "MimicVirus", "")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace Pickups2Click
{
    public class MainLoader : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg(ConsoleColor.Green,"Mod successfully loaded.");
        }
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                var myCam = Camera.main.transform;
                Ray ray = new Ray(myCam.transform.position, myCam.transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray);
                foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
                {
                    if (hits.Length > 0)
                    {
                        RaycastHit raycastHit = hits[0];
                        Networking.LocalPlayer.TakeOwnership(vrc_Pickup.gameObject);
                        vrc_Pickup.transform.position = raycastHit.point;
                    }
                }
            }
        }
    } 
}
