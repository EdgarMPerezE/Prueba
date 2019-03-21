using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PruebaYeltic.Enumerables;

namespace PruebaYeltic.Models
{
    [MetadataType(typeof(UsuariosMetaData))]
    public partial class Usuarios
    {
        public Sexo Sexo { get; set; }
    }

    public class UsuariosMetaData
    {
        [MaxLength(25)]
        [Required(ErrorMessage = "Nombre de usuario Requerido")]
        public string varNombre { get; set; }
        [MaxLength(25)]
        [Required(ErrorMessage = "Primer apellido de usuario requerido")]
        public string varPrimerApellido { get; set; }
        [MaxLength(25)]
        public string varSegundoApellido { get; set; }
    }
}