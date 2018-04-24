using System;
using UnityEngine;

namespace AbstractFactoryExample
{
    public class AbstractFactoryExample : MonoBehaviour
    {
        NPCFactory enemyFactory = NPCFactoryProducer.getFactory("EnemyFactory");
        NPCFactory friendlyFactory = NPCFactoryProducer.getFactory("FriendlyFactory");
        Enemy enemy1;
        Enemy enemy2;
        Friendly friendly1;
        Friendly friendly2;

        void Awake()
        {
            enemy1 = enemyFactory.getEnemy(EnemyTypes.flying);
            enemy2 = enemyFactory.getEnemy(EnemyTypes.walking);

            friendly1 = friendlyFactory.getFriendly(FriendlyTypes.flying);
            friendly2 = friendlyFactory.getFriendly(FriendlyTypes.walking);
        }

        void Start()
        {
            enemy1.Move();
            enemy2.Attack();

            friendly1.Move();
            friendly2.Attack();
        }
    }

    public class NPCFactoryProducer
    {
        public static NPCFactory getFactory(string choice)
        {
            switch (choice)
            {
                case ("EnemyFactory"):
                    return new EnemyFactory();
                case ("FriendlyFactory"):
                    return new FriendlyFactory();
                default:
                    return null;
            }
        }

    }
    public abstract class NPCFactory
    {
        public abstract Enemy getEnemy(EnemyTypes type);
        public abstract Friendly getFriendly(FriendlyTypes type);
    }

    public class EnemyFactory : NPCFactory
    {
        override public Enemy getEnemy(EnemyTypes type)
        {
            switch (type)
            {
                case EnemyTypes.flying:
                    return new FlyingEnemy();
                case EnemyTypes.walking:
                    return new WalkingEnemy();
                default:
                    return null;
            }
        }
        override public Friendly getFriendly(FriendlyTypes type)
        {
            return null;
        }
    }

    public class FriendlyFactory : NPCFactory
    {
        override public Enemy getEnemy(EnemyTypes type)
        {
            return null;
        }

        override public Friendly getFriendly(FriendlyTypes type)
        {
            switch (type)
            {
                case FriendlyTypes.flying:
                    return new FlyingFriendly();
                case FriendlyTypes.walking:
                    return new WalkingFriendly();
                default:
                    return null;
            }
        }
    }

    public class FlyingEnemy : Enemy
    {
        public FlyingEnemy()
        {
            health = 10;
            attPow = 1;
        }

        public override void Move()
        {
            Debug.Log("Flying Enemy moved");
        }

        public override void Attack()
        {
            Debug.Log("Flying Enemy attack");
        }
    }

    public class WalkingEnemy : Enemy
    {
        public WalkingEnemy()
        {
            health = 10;
            attPow = 1;
        }

        public override void Move()
        {
            Debug.Log("Walking Enemy moved");
        }

        public override void Attack()
        {
            Debug.Log("Walking Enemy attack");
        }
    }

    public class FlyingFriendly : Friendly
    {
        public FlyingFriendly()
        {
            health = 10;
            attPow = 1;
        }

        public override void Move()
        {
            Debug.Log("Flying Friendly moved");
        }

        public override void Attack()
        {
            Debug.Log("Flying Friendly attack");
        }
    }

    public class WalkingFriendly : Friendly
    {
        public WalkingFriendly()
        {
            health = 10;
            attPow = 1;
        }

        public override void Move()
        {
            Debug.Log("Walking Friendly moved");
        }

        public override void Attack()
        {
            Debug.Log("Walking Friendly attack");
        }
    }

    public abstract class Enemy
    {
        public int health;
        public int attPow;

        public abstract void Move();
        public abstract void Attack();
    }

    public abstract class Friendly
    {
        public int health;
        public int attPow;

        public abstract void Move();
        public abstract void Attack();
    }

    public enum EnemyTypes
    {
        flying = 0,
        walking
    }

    public enum FriendlyTypes
    {
        flying = 0,
        walking
    }
}