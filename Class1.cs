using System;
using UnityEngine;
using BepInEx;
using HarmonyLib;
namespace FirstPersonCamera
{
    [BepInPlugin("net.zenon.firstpersoncamera", "First Person Camera", "1.0.0")]
    public class Class1 : BaseUnityPlugin
    {
        public bool HasInit;
        public GameObject camera;
        public void Awake() 
        {
            var harmony = new Harmony("net.zenon.firstpersoncamera");
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
        }

        public void Update() 
        {
            if (GorillaLocomotion.Player.Instance != null && !HasInit) 
            {
                HasInit = true;
                camera = GameObject.Find("Shoulder Camera");
                GameObject.Find("CM vcam1").SetActive(false);
            }

            camera.transform.position = Vector3.Lerp(camera.transform.position, Camera.main.transform.position, 4 * Time.deltaTime);
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Camera.main.transform.rotation, 4 * Time.deltaTime);

        }
    }
}
