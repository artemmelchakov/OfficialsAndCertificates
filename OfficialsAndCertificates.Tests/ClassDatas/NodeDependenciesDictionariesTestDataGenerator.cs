using System.Collections;

namespace OfficialsAndCertificates.Tests.ClassDatas
{
    /// <summary>
    /// Генератор входных данных для тестов <see cref="AlgorithmTests"/>.
    /// </summary>
    internal class NodeDependenciesDictionariesTestDataGenerator : IEnumerable<object[]>
    {
        /// <summary>
        /// Входные данные для тестов.
        /// Первый элемент кортежа - зависимость узлов графов в виде словарей, где Key - это id узла, а Value - массив узлов-зависимостей.
        /// Второй элемент кортежа - ожидаемое перечисление узлов после сортировки.
        /// </summary>
        private static readonly IEnumerable<(Dictionary<uint, uint[]>, uint[])> _nodeDependencyDictionaries = new[] 
        {
            (
                new Dictionary<uint, uint[]>
                {
                    { 1, [2] },
                    { 2, [3, 4] }
                },
                new uint[] { 4, 3, 2, 1 }
            ),
            (
                new Dictionary<uint, uint[]>
                {
                    { 1, [2] },
                    { 3, [4] }
                },
                new uint[] { 4, 2, 3, 1 }
            ),
            (
                new Dictionary<uint, uint[]>
                {
                    { 1, [2] },
                    { 2, [3, 4] },
                    { 3, [5, 7] }
                },
                new uint[] { 7, 5, 4, 3, 2, 1 }
            ),
            (
                new Dictionary<uint, uint[]>
                {
                    { 3, [2, 4] },
                    { 5, [3] }
                },
                new uint[] { 4, 2, 3, 5 }
            ),
            (
                new Dictionary<uint, uint[]>
                {
                    { 5, [3] },
                    { 3, [2, 4] }
                },
                new uint[] { 4, 2, 3, 5 }
            ),
            (
                new Dictionary<uint, uint[]>
                {
                    { 2, [3, 4] },
                    { 1, [2] }
                },
                new uint[] { 4, 3, 2, 1 }
            ),
            (
                new Dictionary<uint, uint[]>
                {
                    { 2, [3, 4] },
                    { 1, [2] },
                    { 3, [5, 4] }
                },
                new uint[] { 5, 4, 3, 2, 1 }
            )            
        };

        private readonly IEnumerable<object[]> _nodeDependencyDictionariesObj = 
            _nodeDependencyDictionaries.Select(dataAndExpectedResultTuple => new object[] { dataAndExpectedResultTuple.Item1, dataAndExpectedResultTuple.Item2 });
        public IEnumerator<object[]> GetEnumerator() => _nodeDependencyDictionariesObj.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
