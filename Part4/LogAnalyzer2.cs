public class LogAnalyzer2
{
    public static string AnalyzeLog(string log)
    {
        // Дата
        int dateStartIndex = 0;
        int dateEndIndex = log.IndexOf(" ");
        string date = log.Substring(dateStartIndex, dateEndIndex);

        // Вычисляем индекс начала следующего значения
        int offset = GetOffset(log, dateEndIndex);

        // Время
        int timeStartIndex = offset;
        int timeEndIndex = log.IndexOf(" ", offset);
        string time = log.Substring(timeStartIndex, timeEndIndex - timeStartIndex);

        offset = GetOffset(log, timeEndIndex);

        // Уровень            
        int levelStartIndex = offset;
        int levelEndIndex = log.IndexOf(" ", offset);
        string level = log.Substring(levelStartIndex, levelEndIndex - levelStartIndex);

        offset = GetOffset(log, levelEndIndex);

        // Сообщение   
        int messageStartIndex = offset;
        string message = log.Substring(messageStartIndex);

        return $"Дата: {date}, Время: {time}, Уровень: {(level + ",").PadRight(8)} Сообщение: {message}.";
    }

    public static void Start()
    {
        string[] logs = {
                         "2023-11-11   08:30:00   INFO Application started successfully",
                         "2023-11-12   08:45:23   WARNING Low memory warning detected",
                         "2023-11-12   09:15:45   ERROR Failed to connect to database",
                         "2023-11-12   09:45:10   INFO User 'admin' logged in",
                         "2023-11-12   10:00:00   ERROR Unexpected exception occurred"
                        };

        foreach (string log in logs)
        {
            string result = AnalyzeLog(log);

            Console.WriteLine(result);
        }
    }

    static int GetOffset(string stroka, int lastValueIndex)
    {
        int offset = lastValueIndex;
        while (stroka.Substring(offset, 1) == " ")
        {
            offset++;
        }

        return offset;
    }
}