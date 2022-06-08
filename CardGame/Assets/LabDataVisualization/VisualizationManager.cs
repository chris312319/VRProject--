using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LabData;
using UnityEngine;
using GameData;

namespace LabVisualization
{
    public class VisualizationManager : MonoSingleton<VisualizationManager>,IGameManager
    {
        private List<VisualControllerBase> _visualControllerList;

        private List<IEquipment> Equipments;

        public int Weight => GobalData.GmaeVisualizationManagerWeight;

        public void StartDataVisualization()
        {
            Debug.Log("Start");
            var temp = FindObjectsOfType<VisualControllerBase>().ToList();
            _visualControllerList = temp.Count > 0 ? temp : null;
            _visualControllerList?.ForEach(p =>
            {
                p.VisualInit();
            });
            Equipments?.ForEach(p =>
            {
                p.EquipmentStart();
            });
            _visualControllerList?.ForEach(p => p.VisualShow());
        }

        public void VisulizationInit()
        {
            Debug.Log("Init");
            Equipments = FindObjectsOfType<MonoBehaviour>().OfType<IEquipment>().ToList();
            Equipments?.ForEach(p =>
            {
                p.EquipmentInit();
            });
        }



        public void DisposeDataVisualization()
        {
            _visualControllerList?.ForEach(p => p.VisualDispose());
            Equipments?.ForEach(p =>
            {
                p.EquipmentStop();
            });
        }

        public void ManagerInit()
        {
           
        }

        public IEnumerator ManagerDispose()
        {
            DisposeDataVisualization();
            Equipments = null;
            _visualControllerList = null;
            yield return null;
        }
    }

}

