﻿using System;
using System.Collections;
using System.Collections.Generic;
using UniFrame.Common;
using UnityEngine;


public class GamePool: Singleton<GamePool>
{


        public void Init() { }

        public void Reset() { }


        /*==================================================================================*/


        private Dictionary<String, ObjectPool> _objectPools;
     //   private int clearUseNum = 5;
        public GamePool()
        {
            _objectPools = new Dictionary<string, ObjectPool>();
        }


        public bool IsContainPool(string poolName)
        {
            return _objectPools.ContainsKey(poolName);
        }


        public void CreatePool(string poolName, GameObject obj, int initialPoolSize, int maxPoolSize, bool canClear,int clearUseNum)
        {
            var pool = new ObjectPool(poolName, obj, initialPoolSize, maxPoolSize, canClear,clearUseNum);
            _objectPools.Add(poolName, pool);
        }


        public GameObject GetObject(string poolName)
        {
            if (!IsContainPool(poolName)) return null;

            return _objectPools[poolName].GetObject();
        }


        public void Destroy(string poolName, GameObject obj)
        {
            if (!IsContainPool(poolName))
            {
            UnityEngine.Object.Destroy(obj);
            }

            _objectPools[poolName].BackToUnUsedObjList(obj);
        }
    }



    public class ObjectPool
    {
        private List<GameObject> _usedObjList = new List<GameObject>();
        private List<GameObject> _unUsedObjList = new List<GameObject>();

        private string _poolName;
        private GameObject _pooledObj;

        private int _initialPoolSize;
        private int _maxPoolSize;
        private int _CleanNum;
        private GameObject _poolObjsParent;

        public int TotalCount { get { return totalCount(); } }



        public void getUnUseObjListLength() { 
    
    
    
        }
        public ObjectPool(string poolName, GameObject obj, int initialPoolSize, int maxPoolSize, bool canClear,int cleanNum)
        {
            _poolName = poolName;
            _pooledObj = obj;

            _poolObjsParent = new GameObject(string.Format("{0}_{1}", _poolName, "pool"));

            GameObject.DontDestroyOnLoad(_poolObjsParent);

            for (int i = 0; i < initialPoolSize; i++)
            {
                var ObjTemp = GameObject.Instantiate(_pooledObj,Vector3.zero, Quaternion.identity) as GameObject;
                // ObjTemp.SetObjectPool(this);
                ObjTemp.transform.parent = _poolObjsParent.transform;

                _unUsedObjList.Add(ObjTemp);

                //GameObject.DontDestroyOnLoad(ObjTemp);
            }

            _maxPoolSize = maxPoolSize;
            _initialPoolSize = initialPoolSize;
            _CleanNum = cleanNum;
            if (canClear)
            {
              // EventMgr.Self.ObjPoolEvents.AddClearPoolEventListener(clearPool);
            }
        }


        public GameObject GetObject()
        {
            for (int i = _unUsedObjList.Count - 1; i >= 0; i--)
            {
                var obj = _unUsedObjList[i];

                if (_unUsedObjList[i] == null)
                {
                    _unUsedObjList.Remove(obj);

                    continue;
                }

                _usedObjList.Add(obj);
                _unUsedObjList.Remove(obj);
            obj.SetActive(true);
            return obj;
            }

            if (totalCount() < _maxPoolSize)
            {
                var obj = GameObject.Instantiate(_pooledObj, Vector3.zero, Quaternion.identity);
                //obj.SetObjectPool(this);
                obj.transform.parent = _poolObjsParent.transform;

                _usedObjList.Add(obj);
            obj.SetActive(true);
                return obj;
            }

        // D.Error("pool _maxPoolSize");
        for (int i = 0; i < _CleanNum; i++) {
            GameObject Use = _usedObjList[0];

            Use.SetActive(false);
            BackToUnUsedObjList(Use);

        }

        _usedObjList[0].SetActive(true);
        return _usedObjList[0];
        }


        public void BackToUnUsedObjList(GameObject obj)
        {
            if (obj == null) return;

            if (totalCount() <= _maxPoolSize && _usedObjList.Contains(obj))
            {
                obj.transform.parent = _poolObjsParent.transform;

                _unUsedObjList.Add(obj);
                _usedObjList.Remove(obj);
            }
            else
            {
                GameObject.Destroy(obj);
            }
        }


        private void clearPool()
        {
            int objectsToRemoveCount = totalCount() - _initialPoolSize;
            if (objectsToRemoveCount <= 0)
            {
                return;
            }

            for (int i = _unUsedObjList.Count - 1; i >= 0; i--)
            {
                var obj = _unUsedObjList[i];
                _unUsedObjList.Remove(obj);

                GameObject.Destroy(obj);
            }
        }


        public void RemoveEventListener()
        {
          //  EventMgr.Self.ObjPoolEvents.AddClearPoolEventListener(clearPool);
        }


        private int totalCount()
        {
            return _usedObjList.Count + _unUsedObjList.Count;
        }
    }


public static class PoolName {

    public static string bulletPool = "bulletPool";

}
