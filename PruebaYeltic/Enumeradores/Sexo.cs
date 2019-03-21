using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PruebaYeltic.Enumerables
{
    public enum Sexo
    {
        [Display(Name = "Masculino")]
        Masculino,
        [Display(Name = "Femenino")]
        Femenino
    }
}
    public static class EnumExtensions
    {
        public static string GetDescripcion(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo.CustomAttributes.Count() == 0)
            {
                // NO TIENE ATRIBUTOS PERSONALIZADOS COMO DESCRIPCION
                return value.ToString();
            }
            else
            {
                // OBTENER EL VALOR DEL ATRIBUTO DISPLAY
                var attribute = (DisplayAttribute)fieldInfo.GetCustomAttribute(typeof(DisplayAttribute));
                return attribute.Name;
            }
        }
    }