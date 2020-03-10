namespace IDED_Scripting_P1_202010_base.Logic

{
    public class Human : Unit
    {
        public float Potential { get; set { Potenciador(Potential); } }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;

           switch(_unitClass)
           {
                case EUnitClass.Imp:
                case EUnitClass.Orc:
                case EUnitClass.Dragon:
                    _unitClass = EUnitClass.Villager;
               break;
               default:
               break;
           }
           
        }

        protected virtual bool CambioClase(EUnitClass newClass)
        {
            switch (newClass)
            {
                case EUnitClass.Villager:
                    newClass = null;
                    break;

                case EUnitClass.Squire:
                    newClass = EUnitClass.Soldier;
                    break;

                case EUnitClass.Soldier:
                    newClass = EUnitClass.Squire;
                    break;

                case EUnitClass.Ranger:
                    newClass = EUnitClass.Mage;
                    break;

                case EUnitClass.Mage:
                    newClass = EUnitClass.Ranger;
                    break;
            }
        }

        public float Potenciador(float Potential)
        {
            if (Potential < 0f)
            {
                Potential = 0f;
                return Potential;
            }
            if (Potential > 0.1f)
            {
                Potential = 0.1f;
                return Potential;
            }
        }
        public float Attack(int BaseAtk, float BaseAtkAdd)
        {
            (float)BaseAtk + BaseAtkAdd * Potential = Attack;

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
            (float)BaseDef + BaseDefAdd * Potential = DefenseTotal;

            if (Defense < 0f)
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
            (float)BaseDef + BaseSpdAdd * Potential = SpeedTotal;

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