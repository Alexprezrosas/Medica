using AccessoDB;

namespace Medica2
{
    public class CargarSiloeBD
    {
        private static BaseDatos db;

        public static BaseDatos getDB()
        {
            if (db == null)
                db = new BaseDatos();
            return db;
        }




    }
}
