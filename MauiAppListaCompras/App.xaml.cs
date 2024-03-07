using MauiAppListaCompras.Helpers;

namespace MauiAppListaCompras

{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                            ), "banco_sqlite_compras.db3"
                        );
                    _db = new SQLiteDatabaseHelper( path );
                } // Fecha if verificando se _db é null
            
                return _db;
            } //Fecha método get
        } // Fecha Propriedade Db
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
