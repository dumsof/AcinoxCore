namespace File.Message
{
    public enum MessageType : int
    {
        /// <summary>
        /// Inicio el proceso de
        /// </summary>
        InicioProcessGeneradFile = 1,

        NoExitsInformation = 2,
        CountFileGenerad = 3,
        ValidationXSDSuccess = 4,
        FinishedProcess = 5
    }
}