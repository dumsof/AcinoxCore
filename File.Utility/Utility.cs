namespace File.Utility
{
    using System;

    public static class Utility
    {
        public static string PathAplication
        {
            get
            {
                return string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath) ?
                 AppDomain.CurrentDomain.BaseDirectory : AppDomain.CurrentDomain.RelativeSearchPath;
            }
        }

        public static string PathFileGenerated
        {
            get
            {
                return $"{PathAplication}\\ArchivosGenerados";
            }
        }

        public static string PathFileProcessed
        {
            get
            {
                return $"{PathAplication}\\ArchivoProcesado";
            }
        }
    }
}