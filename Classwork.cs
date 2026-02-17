using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp2.Npc;

namespace Classwork
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    public struct Npc
    {
        public enum ClothesColor
        {
            Blue = 1,
            Green = 2,
            Yellow = 3,
        }
        public enum Sex
        {
            Male = 1,
            Female = 2,
        }

        private Sex _sex;
        private int _age;
        private bool _hasHat;
        private ClothesColor[] _clothesColor;
        private bool _hasLongHair;
        private bool _hasSmthInArm;

        public Sex GetSex => _sex;
        public int Age => _age;
        public bool HasHat => _hasHat;
        public ClothesColor[] GetClothesColor => _clothesColor;
        public bool HasLongHair => _hasLongHair;
        public bool HasSmthInArm => _hasSmthInArm;

        public Npc(
            Sex sex,
            int age,
            bool hasHat,
            ClothesColor[] clothesColor,
            bool hasLongHair,
            bool hasSmthInArm
            )
        {
            _sex = sex;
            _age = age;
            _hasHat = hasHat;
            _clothesColor = new ClothesColor[clothesColor.Length];
            for (int i = 0; i < clothesColor.Length; i++)
                _clothesColor[i] = clothesColor[i];

            _hasLongHair = hasLongHair;
            _hasSmthInArm = hasSmthInArm;

        }
    }

    public struct Village
    {
        private string _name;
        private Npc[] _npc;
        public string Name => _name;
        public Npc[] Npc => _npc;

        public Village(string name)
        {
            _name = name;
            _npc = new Npc[0];
        }

        public void InvateNpc
            (
            Sex sex,
            int age,
            bool hasHat,
            ClothesColor[] clothesColor,
            bool hasLongHair,
            bool hasSmthInArm
            )
        {
            Array.Resize(ref _npc, _npc.Length + 1);
            var newNpc = new Npc(sex,age,hasHat,clothesColor,hasLongHair,hasSmthInArm);
        }

        public void InvateNpc()
        {
            Array.Resize(ref _npc, _npc.Length+5);
 

            var newNpc = new Npc[2]
            {
         
                new Npc( (Npc.Sex) 2,17,false,null,false,true),
                new Npc( (Npc.Sex) 1,17,false,null,false,true),
            };


        }
    }
}