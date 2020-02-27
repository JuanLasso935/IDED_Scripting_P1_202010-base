namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;
        }
      

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool result = false;

            if (EUnitClass is EUnitClass.Villager)
            {
                result = false;
            }
            if (EUnitClass is EUnitClass.Squire)
            {
                newClass = EUnitClass.Soldier;
                result = true;
            }
            if (EUnitClass is EUnitClass.Ranger)
            {
                newClass = EUnitClass.Mage;
                result = true;
            }
            if (EUnitClass is EUnitClass.Soldier)
            {
                newClass = EUnitClass.Squire;
                    result = true;
            }
            if (EUnitClass is EUnitClass.Mage)
            {
                newClas = EUnitClass.Ranger;
                result = true;
            }
            return result;
        }
    }
}