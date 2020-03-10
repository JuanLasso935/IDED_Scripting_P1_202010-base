namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {


        public int BaseAtk { get; protected set { Limitador(value); }}
        public int BaseDef { get; protected set { Limitador(value); }}
        public int BaseSpd { get; protected set { Limitador(value); }}

        public int MoveRange { get; protected set { LimitadorMove(_moveRange); } }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set { Limitador(value); } }
        public float BaseDefAdd { get; protected set { Limitador(value); } }
        public float BaseSpdAdd { get; protected set { Limitador(value); } }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;
        public int value;

        public static bool [,] AtkMatriz = new [,]
        {
          {
              {false,false,false,false,false,false,false,false},
              {false,true,true,true,true,true,true,true},
              {false,true,true,true,true,true,true,true},
              {true,true,true,true,false,true,true,false},
              {true,true,true,true,false,true,true,true},
              {true,true,true,true,true,true,true,false},
              {true,true,true,true,true,true,true,false},
              {true,true,true,true,true,true,true,true}
            
          }  
        };

        public int LimitadorMove (int _moveRange)
        {
            if (_moveRange > 10)
            {
                _moveRange = 10;
                return _moveRange;
            }

            if (_moveRange < 0)
            {
                _moveRange =0;
                return _moveRange;
            }
        }
        public int Limitador(int value)
        {
            if (value > 255)
            {
                value = 255;
                return value;
            }
            if (value < 0)
            {
                value = 0;
                return value;
            }
        }

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            Random r = new Random ((int)DateTime.Now.Ticks);

            ElegirUnitCLass(_unitClass);
        }

        protected void ElegirUnitCLass(EUnitClass targetClass)
        {
            switch (targetClass)
            {
                case EUnitClass.Villager:
                BaseAtkAdd= 0;
                BaseDefAdd=0;
                BaseSpdAdd=0;
                AtkRange=0;
                break;

                case EUnitClass.Squire:
                BaseAtkAdd=2;
                BaseDefAdd=1;
                BaseSpdAdd=0;
                AtkRange=1;
                break;

                case EUnitClass.Soldier:
                BaseAtkAdd=3;
                BaseDefAdd=2;
                BaseSpdAdd=1;
                AtkRange = 1;
                break;

                case EUnitClass.Ranger:
                BaseAtkAdd=1;
                BaseDefAdd=0;
                BaseSpdAdd=3;
                AtkRange=3;
                break;

                case EUnitClass.Mage:
                BaseAtkAdd=3;
                BaseDefAdd=1;
                BaseSpdAdd=-1;
                AtkRange=3;
                break;

                case EUnitClass.Imp:
                BaseAtkAdd=1;
                BaseDefAdd=0;
                BaseSpdAdd=0;
                AtkRange=1;
                break;

                case EUnitClass.Orc:
                BaseAtkAdd=4;
                BaseDefAdd=2;
                BaseSpdAdd=-2;
                AtkRange=1;
                break;

                case EUnitClass.Dragon:
                BaseAtkAdd=5;
                BaseDefAdd=3;
                BaseSpdAdd=2;
                AtkRange=5;
                break;
            }
        }


        public virtual bool Interact(Unit otherUnit)
        {
            return AtkMatriz  [(int)UnitClass,(int)otherUnit.UnitClass];
        }



        public virtual bool Interact(Prop prop)
        {
            if (EUnitClass is Villager)
            {
                return true;
            }
            else 
            return  false;
        } 
     


        public bool Move(Position targetPosition) 
        {
            int range = MovePosition;
            range -= CurrentPosition.x-targetPosition.x;
            range -= CurrentPosition.y-targetPosition.y;

            if(targetPosition >=0)
            {
                CurrentPosition = targetPosition;
                return true;
            }
            else return false;            
        }


        public float Attack(int BaseAtk, float BaseAtkAdd)
        {
            (float)BaseAtk + BaseAtkAdd = Attack;

            if (Attack < 0f)
            {
                Attack = 0f;
                return Attack;
            } 

            if (Attack > 255f)
            {
                Attack = 255f;
                 return Attack;
            }
            return Attack;
        }

        public float Defense(int BaseDef, float BaseDefAdd)
        {
            (float)BaseDef + BaseDefAdd = DefenseTotal;

            if(Defense < 0f)
            {
                Defense = 0f;
                return Defense;
            }
            if (Defense > 255f)
            {
                Defense = 255f;
                return Defense;
            }
            return Defense;
        }

        public float Speed(int BaseSpd, float BaseSpdAdd)
        {
            (float)BaseDef + BaseSpdAdd = SpeedTotal;

            if (Speed < 0f)
            {
                Speed = 0f;
                return Speed;
            }
            if (Speed > 255f)
            {
                Speed = 255f;
                return Speed;

            }
            return Speed;

        }
    }
}