﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
namespace Assets.script.modle.SaveSystem
{
    [Serializable]
    class SaveModel
    {

        public CameraProxy cameraProxy;
        public PackProxy packProxy;
        public PaperValueProxy paperValueProxy;
        public Dictionary<eventCmd, bool> all;
        public Sayingproxy sayingProxy;
        public PlayerPosition playerPosition;
        public int[] paintPoint;
        public bool[] IsLock;
        public OpnionProxy opnion;
    }

    public struct PlayerPosition
    {
        public float x;
        public float y;
        public float z;
        public float rx;
        public float ry;
        public float rz;

    }
}
