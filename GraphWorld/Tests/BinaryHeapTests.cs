using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWorld.Tests
{
    [TestClass]
    public class BinaryHeapTests
    {
        [TestMethod]
        public void HeapCreated()
        {
            var heap = new Heap<int>();

            heap.AddItems(20, 30 , 10 , 5, 7 , 13);
        }

    }
}
