using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProtopyteExample
{
    public class ProtopyteExample : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Bandit bandit1 = new Bandit("0", "Bandit");
            Knight knight1 = new Knight("1", "Knight");

            Bandit bandit2 = (Bandit)bandit1.Clone();
            Knight knight2 = (Knight)knight1.Clone();

            bandit2.Attack();
            knight2.Attack();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class Bandit : Enemy
    {
        public Bandit(string id, string name) : base(id, name)
        {
        }

        public override void Attack()
        {
            Debug.Log("Bandit has attack!");
        }

        public override Enemy Clone()
        {
            return (Enemy)this.MemberwiseClone();
        }
    }

    public class Knight : Enemy
    {
        public Knight(string id, string name) : base(id, name)
        {
        }

        public override void Attack()
        {
            Debug.Log("Knight has attack!");
        }

        public override Enemy Clone()
        {
            return (Enemy)this.MemberwiseClone();
        }
    }

    public abstract class Enemy
    {
        private string _id;
        private string _name;

        public Enemy(string id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public abstract Enemy Clone();
        public abstract void Attack();
    }
}