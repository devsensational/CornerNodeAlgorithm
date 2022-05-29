using System;
using System.Collections.Generic;

namespace test150x
{
    public class MapDataObject
    {
        public int width;
        public int height;

        public List<byte> mapDataArr = new List<byte>();

    
        

    }
    public class MapDataObjectRes
	{
        public int width;
        public int height;

        public List<int> mapDataArr2 = new List<int>();

        public List<int> mapCountArr = new List<int>();

    }
}