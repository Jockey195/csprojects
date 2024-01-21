namespace Part4.Tests
{
    public class LogAnalyzer2_Tests
    {
        [Fact]
        public void AnalyzeLog_ExpectedInput_ShouldWork()
        {
            // Подготовка
            string input = "2023-11-12   09:15:45   ERROR Failed to connect to database";
            string expectedOutput = "Дата: 2023-11-12, Время: 09:15:45, Уровень: ERROR,   Сообщение: Failed to connect to database.";

            // Выполнение
            string result = LogAnalyzer2.AnalyzeLog(input);

            // Проверка
            Assert.Equal(expectedOutput, result);
        }
    }
}