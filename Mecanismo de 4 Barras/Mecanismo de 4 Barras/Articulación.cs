using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecanismo_de_4_Barras
{
    class Articulación
    {
       
        #region Variables 

        double Ang;
        double Xc;
        double Yc;
        double X;
        double Y;


        #endregion

        #region Constructor 

        public Articulación()
        {

        }
        /// <summary>
        /// Creación del Constructor
        /// </summary>
        /// <param name="Ang">Ángulo de rotación</param>
        /// <param name="Xc">Punto inicial de las abcisas</param>
        /// <param name="Yc">Punto inicial de las ordenadas</param>
        /// <param name="X">Punto final de las abcisas</param>
        /// <param name="Y">Punto final de las ordenadas</param>
        public Articulación(double Ang, double Xc, double Yc, double X, double Y)
        {
            this.Ang = DegreetoRad(Ang);
            this.Xc = Xc;
            this.Yc = Yc;
            this.X = X;
            this.Y = Y;


        }


        #endregion

        #region Accesos

        /// <summary>
        /// Obtiene y establece el valor del ángulo de rotación
        /// </summary>
        public double _Ang
        {
            get { return Ang; }
            set { Ang = value; }
        }



        #endregion

        #region Funciones

        /// <summary>
        /// Transforma el valor del ángulo de grados a radianes
        /// </summary>
        /// <param name="theta">Ángulo de rotación</param>
        /// <returns></returns>
        public double DegreetoRad(double theta)
        {
            Ang = -theta * Math.PI / 180;
            return Ang;
        }
        /// <summary>
        /// Rota el punto de las abcisas en el ángulo de rotación indicado. 
        /// </summary>
        /// <param name="Art">Nombre genérico para el objeto de la clase creada </param>
        /// <returns>Retorna el punto rotado</returns>
        public double Rotaciónx(Articulación Art)
        {

            double Px = (Xc + (X - Xc) * Math.Cos(_Ang) - (Y - Yc) * Math.Sin(_Ang));

            return Px;
        }
        /// <summary>
        /// Rota el punto de las ordenadas en el ángulo de rotación indicado. 
        /// </summary>
        /// <param name="Art">Nombre genérico para el objeto de la clase creada</param>
        /// <returns>Retorna el punto rotado</returns>
        public double Rotacióny(Articulación Art)
        {
            double Py = (Yc + (X - Xc) * Math.Sin(_Ang) + (Y - Yc) * Math.Cos(_Ang));

            return Py;
        }
   
        #endregion





    }
}


