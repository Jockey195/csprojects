namespace Part4.Tests
{
    public class LogAnalyzer2_Tests
    {
        [Fact]
        public void AnalyzeLog_ExpectedInput_ShouldWork()
        {
            // ����������
            string input = "2023-11-12   09:15:45   ERROR Failed to connect to database";
            string expectedOutput = "����: 2023-11-12, �����: 09:15:45, �������: ERROR,   ���������: Failed to connect to database.";

            // ����������
            string result = LogAnalyzer2.AnalyzeLog(input);

            // ��������
            Assert.Equal(expectedOutput, result);
        }
    }
}