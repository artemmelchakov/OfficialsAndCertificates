using OfficialsAndCertificates.Algorithms;
using OfficialsAndCertificates.Tests.ClassDatas;

namespace OfficialsAndCertificates.Tests
{
    public class AlgorithmTests
    {
        /// <summary>
        /// Тест проверки алгоритма топографической сортировки.
        /// </summary>
        [Theory]
        [ClassData(typeof(NodeDependenciesDictionariesTestDataGenerator))]
        public void TopographicSortingAlgorithmTest1(Dictionary<uint, uint[]> nodeDependencyDictionary, uint[] expected)
        {
            var sortedEnumerable = TopographicSorting.Sort(nodeDependencyDictionary);
            Assert.Equal(expected, sortedEnumerable);
        }
    }
}