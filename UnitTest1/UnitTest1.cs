using LRUCache;

namespace UnitTest1
{
    public class UnitTest1
    {
        LRUCache<int, int> cache = new LRUCache<int, int>(5);

        [Fact]
        public void TryGetValue()
        {
            cache.Put(3, 5);
            var temp = 0;

            var temp2 = temp;
            cache.TryGetValue(3, out temp2);

            Assert.False(temp2 == temp);
        }
    }
}