using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sem_2__Lab_2
{
    public class NotComparable : Attribute { }
    public class Unreadable : Attribute { }

    public class Compare
    {
        public List<object> testBase = new List<object>
        {
            new TestBase()
            {
                number = 1,
                Name = "a",
            }
        };
        public void Compar(List<object> testControl)
        {
            bool equality = true;
            if (testControl.Count == testBase.Count) 
            {
                for (int i = 0; i < testControl.Count; i++)
                {
                    Type Control = testControl[i].GetType();
                    Type Base = testBase[i].GetType();
                    
                    if (Attribute.IsDefined(Control, typeof(NotComparable)) || Attribute.IsDefined(Control, typeof(Unreadable)))
                    {
                        Console.WriteLine($"Найден нечитаемый тип {Control.Name}! \nВ позиции: {i}");
                        equality = false;
                    }
                    else if (Control != Base)
                    {
                        Console.WriteLine($"Найдено расхождение в типах! \nВ позиции: {i} \nПолучено {Control.Name} \nОжидалось {Base.Name}");
                        equality = false;
                    }
                    else
                    {
                            foreach (PropertyInfo ControlProperty in Control.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                        {
                            
                            if (Attribute.IsDefined(ControlProperty, typeof(NotComparable)) || Attribute.IsDefined(ControlProperty, typeof(Unreadable)))
                            {
                                Console.WriteLine($"Найден нечитаемое поле {ControlProperty.Name}! \nВ позиции: {i} В типе: {Control.Name}");
                                equality = false;
                            }
                            else 
                            {
                                foreach (PropertyInfo BaseProperty in Control.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                                {
                                    if (ControlProperty.Name == BaseProperty.Name)
                                    {
                                        object ControlValue = ControlProperty.GetValue(testControl[i]);
                                        object BaseValue = BaseProperty.GetValue(testBase[i]);
                                        if (!Equals(ControlValue, BaseValue))
                                        {
                                            Console.WriteLine($"Расхождение значений! \nВ позиции: {i} В поле: {BaseProperty.Name} \nПолучено : {ControlValue} \nОжидалось : {BaseValue}");
                                            equality = false;
                                        }
                                    }
                                }   
                            }
                        }
                    }
                }               
            }
            else
            {
                Console.WriteLine("Длина списков не равна");
                equality = false;
            }
            if (equality == true) 
            {
                Console.WriteLine("Списки равны");
            }
        } 
    }
}
