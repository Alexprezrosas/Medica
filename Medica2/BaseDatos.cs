using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medica2
{
    public class BaseDatos
    {
        public static AccessoDB.BaseDatos db;

        public static AccessoDB.BaseDatos GetBaseDatos()
        {
            if (db == null)
                db = new AccessoDB.BaseDatos();
            return db;
        }
    }
}
