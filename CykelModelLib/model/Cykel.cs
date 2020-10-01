using System;
using System.Collections.Generic;
using System.Text;

namespace CykelModelLib.model
{
    public class Cykel
    {
        //Instance field
        private int _id;
        private string _farve;
        private double _pris;
        private int _gear;

        //Tom constructor til  JSON transfer
        public Cykel()
        {
        }

        //Constructor
        public Cykel(int id, string farve, double pris, int gear)
        {
            _id = id;
            _farve = farve;
            _pris = pris;
            _gear = gear;
        }

        //Properties 
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set => _farve = value;
        }

        public double Pris
        {
            get => _pris;
            set => _pris = value;
        }

        public int Gear
        {
            get => _gear;
            set => _gear = value;
        }

        //ToString
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Farve)}: {Farve}, {nameof(Pris)}: {Pris}, {nameof(Gear)}: {Gear}";
        }
    }
}
