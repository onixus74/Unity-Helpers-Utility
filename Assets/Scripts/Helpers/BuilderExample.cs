using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderExample
{
    public class BuilderExample : MonoBehaviour
    {
        LevelDirector director;


        // Use this for initialization
        void Start()
        {
			director = new LevelDirector();

            LevelBuilder simpleLevelBuilder = new IceLevelBuilder();
            LevelBuilder complexLevelBuilder = new FireLevelBuilder();

            director.ConstructSimpleLevel(simpleLevelBuilder);
            director.ConstructComplexLevel(complexLevelBuilder);
			
			Level simpleIceLevel = simpleLevelBuilder.GetLevel();
			Level complexFireLevel = complexLevelBuilder.GetLevel();

			simpleIceLevel.PrintLevel();
			complexFireLevel.PrintLevel();
        }
    }

    public class LevelDirector
    {
        public void ConstructSimpleLevel(LevelBuilder builder)
        {
            builder.BuildFloor();
            builder.BuildNPC();
        }

        public void ConstructComplexLevel(LevelBuilder builder)
        {
            builder.BuildFloor();
            for (int i = 0; i < 10; i++)
            {
                builder.BuildNPC();
            }
        }
    }

    public abstract class LevelBuilder
    {
        public abstract void BuildFloor();
        public abstract void BuildNPC();
        public abstract Level GetLevel();
    }

    public class IceLevelBuilder : LevelBuilder
    {
        private Level _iceLevel = new Level();

        public override void BuildFloor()
        {
            _iceLevel.Floor = "Ice Floor";
        }

        public override void BuildNPC()
        {
            _iceLevel.AddNPC("Ice NPC");
        }

        public override Level GetLevel()
        {
            return _iceLevel;
        }
    }

    public class FireLevelBuilder : LevelBuilder
    {
        private Level _fireLevel = new Level();

        public override void BuildFloor()
        {
            _fireLevel.Floor = "Fire Floor";
        }

        public override void BuildNPC()
        {
            _fireLevel.AddNPC("Fire NPC");
        }

        public override Level GetLevel()
        {
            return _fireLevel;
        }
    }

    public class Level
    {
        private string _floor;
        private List<string> _npcs = new List<string>();

        public string Floor
        {
            get { return _floor; }
            set { _floor = value; }
        }

        public void AddNPC(string npc)
        {
            _npcs.Add(npc);
        }

        public void PrintLevel()
        {

            Debug.Log("Level contains the following:");
            Debug.Log("Floor: " + Floor);
            for (int i = 0; i < _npcs.Count; i++)
            {
                Debug.Log("NPC: " + _npcs[i]);
            }
        }
    }
}
