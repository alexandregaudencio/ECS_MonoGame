﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ECS.Components
{
    public static class Layering 
    {
        private static Dictionary<string, int> layers = new Dictionary<string, int>()
        {
            {"render",0 },
            {"UI", 1},
        };

        public static Dictionary<string, int> Layers { get => layers; set => layers = value; }



        //public static void GenerateLayer(Dictionary<string, int> layers)
        //{
        //    layers.Clear();
        //    foreach (KeyValuePair<string, int> layer in layers)
        //    {
        //        layers.Add(layer.Key, layer.Value);
        //    }
        //}

        //public static void Add(string key, int value)
        //{
        //    //layers.Add(key, value);
        //}

        //public static int GetLayerByName(string layerName)
        //{
        //    if(!layers.ContainsKey(layerName)) throw new ArgumentNullException();
        //    return layers[layerName];
        //}


        //public static string GetNameByLayer(int layer)
        //{
        //    foreach (var keyValuePair in layers.Where(keyValuePair => keyValuePair.Value == layer))
        //    {
        //        return keyValuePair.Key;
        //    }

        //    throw new ArgumentOutOfRangeException("Index out of Collection range.");
        //}


        ////public static void InsertLayerAtIndex(string layerName, int Index)
        ////{


        ////}



    }
}
