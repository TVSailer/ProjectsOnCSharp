using Recognizer;

namespace TestFilter
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            double[,] original = { 
                { 2, 5, 6 },
                { 7, 2, 6 },
                { 3, 9, 8 }
            };
            //2,2,3,5,6,6,7,a8,9
            double[,] noOriginal = new double[3,3];

            MedianFilterTask.GetFilter3on3(original, 1, 1, ref noOriginal);
            Assert.AreEqual(6, noOriginal[0,0]);
        }
    }
}