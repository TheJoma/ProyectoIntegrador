using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceModelos
{
    public class Usuario
    {
        public int codUsu { get; set; }
        public string nomUsu { get; set; }
        public string apePatUsu { get; set; }
        public string apeMatUsu { get; set; }
        public string dniUsu { get; set; }
        public string celUsu { get; set; }
        public string nickUsu { get; set; }
        public string pwdUsu { get; set; }
        public string fechaRegistroUsu { get; set; }
        public int codTipoUsu { get; set; }
        public string desTipoUsu { get; set; }
        public string mailUsu { get; set; }




        public void validar()
        {
            if (string.IsNullOrEmpty(nomUsu))
                throw new Exception("Debe colocar nombre de usuario");
            if (string.IsNullOrEmpty(apePatUsu))
                throw new Exception("Debe colocar apellido paterno del usuario");
            if (string.IsNullOrEmpty(apeMatUsu))
                throw new Exception("Debe colocar apellido materno del usuario");
            if (string.IsNullOrEmpty(dniUsu))
                throw new Exception("Debe colocar dni del usuario ");
            if (dniUsu.Length != 8)
                throw new Exception("Debe contener 8 caracteres el DNI del usuario");
            if (string.IsNullOrEmpty(celUsu))
                throw new Exception("Debe colocar el celular o telefono del usuario ");
            if (celUsu.Length != 9 || celUsu.Length != 7)
                throw new Exception("Debe colocar un celular o telefono valido");
            if (string.IsNullOrEmpty(nickUsu))
                throw new Exception("Debe colocar el nick del usuario ");
            if (string.IsNullOrEmpty(pwdUsu))
                throw new Exception("Debe colocar la contraseña del usuario  ");
            if (string.IsNullOrEmpty(codTipoUsu.ToString()))
                throw new Exception("Debe seleccionar un tipo de usuario");
            if (string.IsNullOrEmpty(mailUsu))
                throw new Exception("Debe colocar el correo del usuario");

            

        }
    }
}

